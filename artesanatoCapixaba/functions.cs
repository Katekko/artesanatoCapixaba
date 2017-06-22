using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace artesanatoCapixaba
{
    class functions
    {
        private static string server = "localhost";
        private static string database = "db_artesanatocapixaba";
        private static string uid = "root";
        private static string password = "102030";
        private static string connString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        private static MySqlConnection connection = new MySqlConnection(connString);


        private static string usuarioAtual;

        public static string getUsuarioAtual()
        {
            return usuarioAtual;
        }

        public static int getIDusuarioAtual()
        {
            MySqlConnection con = functions.connectionSQL();
            MySqlCommand query = new MySqlCommand($"SELECT ID_Usuario FROM tbl_Usuario WHERE Nome_Usuario = '{getUsuarioAtual()}'", con);
            var leitor = query.ExecuteReader();
            int idUSU = 0;
            while (leitor.Read())
            {
                idUSU =  Int32.Parse(leitor["ID_Usuario"].ToString());
            }

            leitor.Close();
            con.Close();

            return idUSU;
        }

        public static void setUsuarioAtual(string USUATUAL)
        {
            usuarioAtual = USUATUAL;
        }

        public static MySqlConnection connectionSQL()
        {
            try
            {
                connection.Open();
            }
            catch
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return connection;
        }

        public static void closeProgram()
        {
            connection.Close();
            Application.Exit();
        }

        public static void KeyPressOnlyNumber(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if(e.Handled == true)
            {
                messageBOXwarning("Apenas numeros nesse campo!");
            }
        }

        public static void onlyLetters(object sender, EventArgs e, TextBox txtbox)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtbox.Text, "^[a-zA-Z]"))
            {
                if (txtbox.Text != "")
                {
                    messageBOXwarning("Apenas letras nesse campo!");
                    txtbox.Clear();
                    txtbox.Focus();
                }
            }
        }

        public static DateTime setTxtBoxToDate(TextBox txtBox)
        {
            System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
            dateInfo.ShortDatePattern = "dd/MM/yyyy";

            return Convert.ToDateTime(txtBox.Text, dateInfo);
        }

        public static bool isClear(string txt)
        {
            if(txt == "" || txt == null)
            {
                return true;
            }
            return false;
        }

        public static void messageBOXerror(string txtMenssagem)
        {
            MessageBox.Show(txtMenssagem, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void messageBOXwarning(string txtMenssagem)
        {
            MessageBox.Show(txtMenssagem, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void messageBOXok(string txtMenssagem)
        {
            MessageBox.Show(txtMenssagem, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static bool messageBOXConfirma(string txtMenssagem, string txtTitle)
        {
            DialogResult dr =  MessageBox.Show(txtMenssagem, txtTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);  

            if(dr == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void removeSelectedRow(DataGridView datagrid)
        {
            try
            {
                datagrid.Rows.RemoveAt(datagrid.SelectedRows[0].Index);
            }
            catch
            {
                messageBOXwarning("Escolha um item valido para excluir!");
            }
           
        }

        public static void fillCmb(string select, string nomeColuna, ComboBox combobox)
        {
            MySqlConnection con = functions.connectionSQL();
            MySqlCommand query = new MySqlCommand(select, con);

            try
            {
                MySqlDataReader leitor = query.ExecuteReader();

                combobox.Items.Clear();

                while (leitor.Read())
                {
                    combobox.Items.Add(leitor[nomeColuna]);
                }

                combobox.Items.Add("Nenhum");
            }
            catch (Exception ex)
            {
                functions.messageBOXerror("Erro ao inserir elementos no combo. -- " + ex);
            }
            finally
            {
                con.Close();
            }

        }

        public static string transformCurrent(TextBox txtbox, string txtBoxTxt = "")
        {
            string str;

            if (txtBoxTxt == "")
            {
                 str = txtbox.Text;
            }
            else
            {
                str = txtBoxTxt;
            }

            Double value;
            if (Double.TryParse(txtbox.Text, out value))
            {
                txtbox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            }
            else
            {
                txtbox.Text = String.Empty;
            }

            return str;
        }

        public static bool updateChangeDeleteDatabase(string querys)
        {

            MySqlConnection con = connectionSQL();

            MySqlCommand query = new MySqlCommand(querys, con);

            try
            {
                query.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                functions.messageBOXerror(ex.Message);
                con.Close();
                return false;
            }
        }

        public static int getNewValueToQuant(int opcao, int valor, string codProduto)
        {
            MySqlConnection con = functions.connectionSQL();
            MySqlCommand query = new MySqlCommand($"SELECT Quantidade_Estoque FROM tbl_estoque WHERE Codigo_Produto = '{codProduto}'", con);
            var leitor = query.ExecuteReader();

            int quantidadeAntiga = 0;
            int quantidadeNova = 0;

            switch (opcao)
            {
                //adicionando
                case 1:

                    while (leitor.Read())
                    {
                        quantidadeAntiga = Int32.Parse(leitor["Quantidade_Estoque"].ToString());
                    }

                    quantidadeNova = quantidadeAntiga + valor;

                    break;

                //retirando
                case 2:

                    while (leitor.Read())
                    {
                        quantidadeAntiga = Int32.Parse(leitor["Quantidade_Estoque"].ToString());
                    }

                    quantidadeNova = quantidadeAntiga - valor;

                    if (quantidadeNova <= 0)
                    {
                        if(messageBOXConfirma("Deseja vender o ultimo produto?", "Ultimo produto restante"))
                        {
                            con.Close();

                            quantidadeNova = 0;

                            updateChangeDeleteDatabase($"DELETE FROM tbl_estoque WHERE Codigo_Produto = '{codProduto}'");

                            messageBOXok("Ultimo produto retirado com sucesso!");
                        }
                        else
                        {
                            quantidadeNova = quantidadeAntiga;
                        }
                    }

                    break;
            }

            leitor.Close();
            con.Close();
            return quantidadeNova;
        }

        public static void configForm(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void fillGridFromSelect(string select, DataGridView grid)
        {
            MySqlConnection con = functions.connectionSQL();

            try
            {
                MySqlCommand query = new MySqlCommand(select, con);
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                DataSet ds = new DataSet();
                da.Fill(ds);

                grid.DataSource = ds;
                grid.DataMember = ds.Tables[0].TableName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel inserir os dados na grid, chame o desenvolvedor. --" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        public static string configDataSql(string data)
        {
            Char delimiter = '/';
            String[] str = data.Split(delimiter);

            string dia = str[0];
            string mes = str[1];
            string ano = str[2];

            return $"{ano}/{mes}/{dia}";
        }

        public static bool retirarEstoqueVenda(List<string> codProd, List<int> quantProd)
        {
            for(int i = 0; i < codProd.Count; i++)
            {

                functions.updateChangeDeleteDatabase($"UPDATE tbl_estoque SET Quantidade_Estoque = {getNewValueToQuant(2,quantProd[i], codProd[i])} WHERE Codigo_Produto = '{codProd[i]}'");
            }

            return true;
        }

        public static int getArtesao(string codProduto)
        {
            MySqlConnection con = connectionSQL();
            MySqlCommand query = new MySqlCommand($"SELECT Codigo_Artesao FROM tbl_produto WHERE Codigo_Produto = '{codProduto}'",con);
            var leitor = query.ExecuteReader();

            leitor.Read();

            int idArtesao = Int32.Parse(leitor["Codigo_Artesao"].ToString());

            leitor.Close();
            con.Close();
            
            return idArtesao;
        }
    }
}
