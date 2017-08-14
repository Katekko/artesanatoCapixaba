using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace artesanatoCapixaba
{
    public partial class Pagamento : Form
    {

        private double valorPago;

        private string selectGridPagamento =
            "SELECT tbl_pagamentoArtesao.Codigo_Artesao, tbl_artesao.Nome_Artesao, tbl_pagamentoArtesao.Valor_Pagamento, tbl_pagamentoArtesao.Data_Pagamento" +
            " FROM tbl_PagamentoArtesao " +
            " INNER JOIN tbl_artesao ON tbl_pagamentoArtesao.Codigo_Artesao = tbl_artesao.ID_Artesao";

        public Pagamento()
        {
            InitializeComponent();
            atualizargridArtesao(selectGridPagamento);
        }

        private void btnEfetuarPagamento_Click(object sender, EventArgs e)
        {
            efetuarPagamento();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string codArtesao = txtCodArtPesq.Text;
            string select = "";

            select = selectGridPagamento + makeWherePagamento(codArtesao);
            atualizargridArtesao(select);

        }

        private void txtCodArtesao_KeyPress(object sender, KeyPressEventArgs e)
        {
            functions.KeyPressOnlyNumber(sender, e);
        }

        private void txtCodArtesao_Leave(object sender, EventArgs e)
        {
            TextBox send = (TextBox)sender;
            string nome = send.Name;
            bool aux = true;

            if(nome != "txtCodArtPesq")
            {
                aux = true;
            }
            else
            {
                aux = false;
            }

            if (aux)
            {
                if (txtCodArtesao.Text != "")
                {
                    if (!checkExistArtesao(txtCodArtesao.Text))
                    {
                        functions.messageBOXwarning("Artesão inexistente, escolha outro!");
                        txtCodArtesao.Text = "";
                        txtNomeArtesao.Text = "";
                        txtCodArtesao.BackColor = Color.Red;
                    }
                    else
                    {
                        txtCodArtesao.BackColor = Color.Chartreuse;

                        SqlConnection con = functions.connectionSQL();
                        SqlCommand query = new SqlCommand($"SELECT Nome_Artesao FROM tbl_artesao WHERE ID_Artesao = '{txtCodArtesao.Text}'", con);

                        var leitor = query.ExecuteReader();

                        while (leitor.Read())
                        {
                            txtNomeArtesao.Text = leitor["Nome_Artesao"].ToString();
                        }

                        leitor.Close();
                        con.Close();
                    }
                }
            }
            else
            {
                if (txtCodArtPesq.Text != "")
                {
                    if (!checkExistArtesao(txtCodArtPesq.Text))
                    {
                        functions.messageBOXwarning("Artesão inexistente, escolha outro!");
                        txtCodArtPesq.Text = "";
                        txtNomeArtPesq.Text = "";
                        txtCodArtPesq.BackColor = Color.Red;
                    }
                    else
                    {
                        txtCodArtPesq.BackColor = Color.Chartreuse;

                        SqlConnection con = functions.connectionSQL();
                        SqlCommand query = new SqlCommand($"SELECT Nome_Artesao FROM tbl_artesao WHERE ID_Artesao = '{txtCodArtesao.Text}'", con);

                        var leitor = query.ExecuteReader();

                        while (leitor.Read())
                        {
                            txtNomeArtPesq.Text = leitor["Nome_Artesao"].ToString();
                        }

                        leitor.Close();
                        con.Close();
                    }
                }
            }
        }

        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            functions.KeyPressOnlyNumber(sender, e);
        }

        private void txtValorPago_Leave(object sender, EventArgs e)
        {
            Double.TryParse(functions.transformCurrent(txtValorPago), out valorPago);
        }

        /*--------------------------------------------------------------------------------*/

        private string makeWherePagamento(string codArtesao)
        {
            string str = " WHERE ";

            if(txtCodArtPesq.Text != "")
            {
                str += " tbl_PagamentoArtesao.Codigo_Artesao = " + codArtesao + " AND ";
            }

            str += $" tbl_PagamentoArtesao.Data_Pagamento BETWEEN '{functions.configDataSql(dtpDataDe.Text)} 00:00:00' AND '{functions.configDataSql(dtpDataAte.Text)} 23:59:59' ;";

            return str;
        }

        private void atualizargridArtesao(string select)
        {
            configGridPagamento();
            fillgridPagamento(select);
        }

        private void fillgridPagamento(string select)
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand(select, con);

            var leitor = query.ExecuteReader();

            functions.clearGrid(gridPagamentos);

            if (!leitor.HasRows)
            {
                functions.messageBOXok($"Este artesão não tem nenhum pagamento registrado entre {dtpDataDe.Text} e {dtpDataAte.Text}!!!");
            }
            else
            {
                while (leitor.Read())
                {
                    DateTime newdate = (DateTime)leitor["Data_Pagamento"];
                    string novaData = newdate.ToShortDateString();
                    gridPagamentos.Rows.Add(leitor["Codigo_Artesao"], leitor["Nome_Artesao"],Double.Parse(leitor["Valor_Pagamento"].ToString().Replace('.', ',')), novaData);
                }
            }

            leitor.Close();
            con.Close();
        }

        private void configGridPagamento()
        {
            gridPagamentos.ColumnCount = 4;

            gridPagamentos.Columns[0].Name = "Codigo_Artesao";
            gridPagamentos.Columns[1].Name = "Nome_Artesao";
            gridPagamentos.Columns[2].Name = "Valor_Pagamento";
            gridPagamentos.Columns[3].Name = "Data_Pagamento";

            gridPagamentos.Columns[0].HeaderText = "Codigo";
            gridPagamentos.Columns[1].HeaderText = "Nome do Artesão";
            gridPagamentos.Columns[2].HeaderText = "Valor";
            gridPagamentos.Columns[3].HeaderText = "Data";

            gridPagamentos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridPagamentos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridPagamentos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridPagamentos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            gridPagamentos.Columns[2].DefaultCellStyle.Format = "C2";
        }

        private bool checkExistArtesao(string ID_Artesao)
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query;

            query = new SqlCommand($"SELECT ID_Artesao FROM tbl_artesao WHERE ID_Artesao = '{ID_Artesao}'", con);


            var leitor = query.ExecuteReader();

            if (leitor.HasRows)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

        public void efetuarPagamento()
        {
            int codArtesao = Int32.Parse(txtCodArtesao.Text);
            double valor = valorPago;
            string dataPagamento = functions.configDataSql(dtpDataPagamento.Text);

            if(functions.updateChangeDeleteDatabase($"INSERT INTO tbl_PagamentoArtesao VALUES ({codArtesao},{valor.ToString().Replace(',', '.')},'{dataPagamento}')"))
            {
                txtCodArtesao.Text = "";
                txtCodArtesao.BackColor = Color.White;
                txtNomeArtesao.Text = "";
                txtValorPago.Text = "";
                dtpDataPagamento.Text = DateTime.Now.ToShortDateString();
                functions.messageBOXok("Pagamento registrado com Q U A L I D A D E  e  S I N C R O N I A");
            }
            else
            {
                functions.messageBOXwarning("Erros acontecem, perdoe nosso programador! Mas verifique sua internet, está funcionando?");
            }
        }

        public static bool checkExistInDB(string ID_Artesao)
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query;

            query = new SqlCommand($"SELECT ID_Artesao FROM tbl_artesao WHERE ID_Artesao != '{ID_Artesao}' ", con);

            var leitor = query.ExecuteReader();

            if (!leitor.HasRows)
            {
                functions.messageBOXwarning("Artesão inexistente, escolha outro!");
            }

            leitor.Close();
            con.Close();

            return false;
        }
    }
}
