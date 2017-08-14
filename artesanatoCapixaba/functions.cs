using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace artesanatoCapixaba
{
    class functions
    {
        private static SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["connString"]);

        private static string usuarioAtual;

        public static bool caixaEstado = false;
        public static double dinheiroCaixa;

        public static string getUsuarioAtual()
        {
            return usuarioAtual;
        }

        public static int getIDusuarioAtual()
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand($"SELECT ID_Usuario FROM tbl_Usuario WHERE Nome_Usuario = '{getUsuarioAtual()}'", con);
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

        public static SqlConnection connectionSQL()
        {
            try
            {
                connection.Open();
            }
            catch(Exception ex)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

                messageBOXerror(ex.ToString());
            }

            return connection;
        }

        public static void closeProgram()
        {
            if(caixaEstado == true)
            {
                messageBOXwarning("O caixa se encontra aberto, feche o caixa primeiro para depois fechar o programa!");
            }
            else
            {
                connection.Close();
                Application.Exit();
            }           
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
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand(select, con);

            try
            {
                SqlDataReader leitor = query.ExecuteReader();

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

            SqlConnection con = connectionSQL();

            SqlCommand query = new SqlCommand(querys, con);

            try
            {
                query.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                functions.messageBOXerror(ex.Message);
                con.Close();
                return false;
            }
        }

        public static int getNewValueToQuant(int opcao, int valor, string codProduto)
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand($"SELECT Quantidade_Estoque FROM tbl_estoque WHERE Codigo_Produto = '{codProduto}'", con);
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
            SqlConnection con = functions.connectionSQL();

            try
            {
                SqlCommand query = new SqlCommand(select, con);
                SqlDataAdapter da = new SqlDataAdapter(query);
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
            SqlConnection con = connectionSQL();
            SqlCommand query = new SqlCommand($"SELECT Codigo_Artesao FROM tbl_produto WHERE Codigo_Produto = '{codProduto}'",con);
            var leitor = query.ExecuteReader();

            leitor.Read();

            int idArtesao = Int32.Parse(leitor["Codigo_Artesao"].ToString());

            leitor.Close();
            con.Close();
            
            return idArtesao;
        }

        public static void clearGrid(DataGridView grid)
        {
            grid.DataSource = null;
            grid.Rows.Clear();
        }
    }
}
