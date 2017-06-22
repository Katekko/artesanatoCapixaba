using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace artesanatoCapixaba
{
    public partial class Login : Form
    {

        private string login;
        private string senha;


        private MySqlConnection connection;

        public Login()
        {
            InitializeComponent();

            this.MaximizeBox = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connection = functions.connectionSQL(); ;

            if (checkLogin())
            {
                Hide();

                menuPrincipal menu = new menuPrincipal();

                functions.configForm(menu);

                menu.ShowDialog();
                
            }
            else
            {
                lblError.Show();
                lblError.Text = "Credenciais erradas, tente novamente!";
                txtLogin.Focus();
                clearTxt();
            }

            
            
        }

        private bool checkLogin()
        {

            this.login = txtLogin.Text.ToString().ToLower();
            this.senha = txtSenha.Text.ToString().ToLower();

            MySqlCommand query = new MySqlCommand("SELECT Nome_Usuario, Senha_Usuario FROM tbl_Usuario;", connection);

            var leitor = query.ExecuteReader();


            while (leitor.Read())
            {
                if (this.login == leitor.GetString(0).ToLower() && this.senha == leitor.GetString(1).ToLower())
                {
                    functions.setUsuarioAtual(login);

                    leitor.Close();
                    connection.Close();

                    return true;
                }
                
            }

            connection.Close();
            leitor.Close();

            return false;
        }

        private void clearTxt()
        {
            txtLogin.Clear();
            txtSenha.Clear();
        }

    }
}
