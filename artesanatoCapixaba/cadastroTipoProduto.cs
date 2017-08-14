
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
    public partial class cadastroTipoProduto : Form
    {

        public cadastroProduto formCadastroProduto;

        public cadastroTipoProduto(cadastroProduto form)
        {
            InitializeComponent();

            formCadastroProduto = form;

            formCadastroProduto.Enabled = false;

            atualizarGridTipoProduto("SELECT * FROM tbl_tipoproduto");
        }

        /*  Botões e Eventos  */

        private void cadastroTipoProduto_FormClosed(object sender, FormClosedEventArgs e)
        {
            formCadastroProduto.Enabled = true;
        }

        private void btnCriarTipoDeProduto_Click(object sender, EventArgs e)
        {
            string sigla = txtSigla.Text.ToUpper();
            string tipoProduto = txtProduto.Text;

            if (functions.isClear(sigla))
            {
                MessageBox.Show("A sigla não pode ser vazia!");
                txtSigla.Focus();
                return;
            }

            if (functions.isClear(tipoProduto))
            {
                MessageBox.Show("O nome não pode estar vazio!");
                txtProduto.Focus();
                return;
            }

            if (checkExistInDB(sigla, tipoProduto))
            {
                return;
            }

            insertDataBase(sigla, tipoProduto);
            atualizarGridTipoProduto("SELECT * FROM tbl_tipoproduto");
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            string sigla;

            if (gridTipoDeProduto.SelectedRows.Count > 0)
            {
                sigla = gridTipoDeProduto.Rows[gridTipoDeProduto.SelectedRows[0].Index].Cells[0].Value.ToString();

                if (functions.messageBOXConfirma("Deseja realmente excluir esse tipo de produto?", "Tem certeza disso?"))
                {
                    if (functions.updateChangeDeleteDatabase($"DELETE FROM tbl_tipoproduto WHERE Sigla_TipoProduto = '{sigla}'"))
                    {
                        functions.removeSelectedRow(gridTipoDeProduto);
                        functions.messageBOXok("Tipo de produto deletado com sucesso!"); 
                    }
                }
            }
            else
            {
                functions.messageBOXwarning("Selecione uma linha para deletar!");
            }
        }

        private void txtProduto_Leave(object sender, EventArgs e)
        {
            functions.onlyLetters(sender, e, txtProduto);
        }

        private void txtSigla_Leave(object sender, EventArgs e)
        {
            functions.onlyLetters(sender, e, txtSigla);
        }
       
        /* ------------------------------------------------------------- */

        private void insertDataBase(string sigla, string tipoProduto)
        {
            try
            {
                SqlConnection con = functions.connectionSQL();

                SqlCommand query = new SqlCommand($"INSERT INTO tbl_tipoproduto VALUES ('{sigla}', '{tipoProduto}')", con);

                query.ExecuteNonQuery();

                con.Close();

                clearTxT();

                functions.messageBOXok("Tipo de produto criado com sucesso!");               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        public static bool checkExistInDB(string Sigla, string tipoProduto)
        {
            SqlConnection con = functions.connectionSQL();

            SqlCommand query = new SqlCommand($"SELECT Sigla_TipoProduto, Nome_TipoProduto FROM tbl_tipoProduto WHERE Sigla_TipoProduto = '{Sigla}' OR Nome_TipoProduto = '{tipoProduto}'", con);

            var leitor = query.ExecuteReader();

            if (leitor.HasRows)
            {
                if (Sigla != "")
                {
                    functions.messageBOXwarning("Sigla já cadastrada! Escolha outra.");
                    leitor.Close();
                    con.Close();

                    return true;
                }
                else if (tipoProduto != "")
                {
                    functions.messageBOXwarning("Tipo de Produto já cadastrado! Escolha outro.");
                    leitor.Close();
                    con.Close();

                    return true;
                }
            }
            leitor.Close();
            con.Close();
            return false;
        }

        private void clearTxT()
        {
            txtProduto.Clear();
            txtSigla.Clear();
            txtProduto.Focus();
        }

        public void configGridTipoProduto()
        {
            gridTipoDeProduto.Columns[0].HeaderText = "Sigla";
            gridTipoDeProduto.Columns[1].HeaderText = "Nome Produto";

            gridTipoDeProduto.Columns[1].Width = 155;
        }

        public void fillGridTipoProduto(string select)
        {
            SqlConnection con = functions.connectionSQL();

            try
            {
                SqlCommand query = new SqlCommand(select, con);
                SqlDataAdapter da = new SqlDataAdapter(query);
                DataSet ds = new DataSet();
                da.Fill(ds);

                gridTipoDeProduto.DataSource = ds;
                gridTipoDeProduto.DataMember = ds.Tables[0].TableName;
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

        public void atualizarGridTipoProduto(string select)
        {
            fillGridTipoProduto(select);
            configGridTipoProduto();
        }

    }
}
