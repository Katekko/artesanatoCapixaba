using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace artesanatoCapixaba
{
    public partial class Estoque : Form
    {
        public Estoque()
        {
            InitializeComponent();

            atualizarGridEstoque("SELECT * FROM tbl_estoque");

            fillCmbTipoProduto();

        }

        /*  Botões e Eventos  */

        private void btnAdicionarEstoque_Click(object sender, EventArgs e)
        {
            cadastroEstoque fCadEstoque = new cadastroEstoque();
            fCadEstoque.ShowDialog();
            atualizarGridEstoque("SELECT * FROM tbl_estoque");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            atualizarGridEstoque($"SELECT tbl_estoque.Codigo_Produto AS 'CodigoP', tbl_estoque.Quantidade_Estoque AS 'Estoque' FROM tbl_Estoque INNER JOIN tbl_produto ON tbl_produto.Codigo_Produto = tbl_estoque.Codigo_Produto {makeWhere()}");
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            string codProd;

            if (gridEstoque.SelectedRows.Count > 0)
            {
                codProd = gridEstoque.Rows[gridEstoque.SelectedRows[0].Index].Cells[0].Value.ToString();

                if (functions.messageBOXConfirma("Deseja realmente excluir esse produto do estoque?", "Tem certeza disso?"))
                {
                    if (functions.updateChangeDeleteDatabase($"DELETE FROM tbl_estoque WHERE Codigo_Produto = '{codProd}'"))
                    {
                        functions.removeSelectedRow(gridEstoque);
                        functions.messageBOXok("Estoque totalmente deletado!");
                    }
                }
            }
            else
            {
                functions.messageBOXwarning("Selecione uma linha para deletar!");
            }
        }

        /* ------------------------------------------------------------- */
        public void configGridEstoque()
        {
            gridEstoque.Columns[0].HeaderText = "Codigo Produto";
            gridEstoque.Columns[1].HeaderText = "Quantidade";

            gridEstoque.Columns[0].Width = 230;
            gridEstoque.Columns[1].Width = 200;
        }

        public void fillGridEstoque(string select)
        {
            MySqlConnection con = functions.connectionSQL();

            try
            {
                MySqlCommand query = new MySqlCommand(select, con);
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                DataSet ds = new DataSet();
                da.Fill(ds);

                gridEstoque.DataSource = ds;
                gridEstoque.DataMember = ds.Tables[0].TableName;
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

        public void atualizarGridEstoque(string select)
        {
            fillGridEstoque(select);
            configGridEstoque();
        }

        private string makeWhere()
        {
            string auxV = "WHERE 1=1 ";

            if (txtCodProd.Text != "")
            {
                auxV += " AND tbl_estoque.Codigo_Produto LIKE '" + txtCodProd.Text + "%'";
            }

            if (cmbTipoProduto.GetItemText(cmbTipoProduto.SelectedItem) != "" && cmbTipoProduto.GetItemText(cmbTipoProduto.SelectedItem) != "Nenhum")
            {
                auxV += " AND tbl_produto.TipoProduto_Produto = '" + cmbTipoProduto.GetItemText(cmbTipoProduto.SelectedItem) + "'";
            }


            if (cmbTipoProduto.GetItemText(cmbTipoProduto.SelectedItem) == "Nenhum")
            {
                //adiciona nada
            }

            return auxV;
        }

        private void fillCmbTipoProduto()
        {
            functions.fillCmb("SELECT * FROM tbl_tipoproduto", "Nome_TipoProduto", cmbTipoProduto);
        }


    }
}
