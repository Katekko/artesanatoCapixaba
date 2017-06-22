using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace artesanatoCapixaba
{
    public partial class Produto : Form
    {
        public Produto()
        {
            InitializeComponent();

            fillCmbTipoProduto();

            atualizarGridProduto($"SELECT tbl_produto.Codigo_Artesao AS 'Codigo', tbl_artesao.Nome_Artesao AS 'Nome', tbl_produto.Codigo_Produto, tbl_produto.TipoProduto_Produto, tbl_produto.Preco_Produto FROM tbl_produto INNER JOIN tbl_artesao ON tbl_artesao.ID_Artesao = tbl_produto.Codigo_Artesao ORDER BY Codigo_Artesao, Codigo_Produto;");
        }


        /*  Botões e Eventos  */

        private void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            cadastroProduto fCadProduto = new cadastroProduto();
            fCadProduto.ShowDialog();  
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            atualizarGridProduto($"SELECT tbl_produto.Codigo_Artesao AS 'Codigo', tbl_artesao.Nome_Artesao AS 'Nome', tbl_produto.Codigo_Produto, tbl_produto.TipoProduto_Produto, tbl_produto.Preco_Produto FROM tbl_produto INNER JOIN tbl_artesao ON tbl_artesao.ID_Artesao = tbl_produto.Codigo_Artesao {makeWhere()}");
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            string ID;

            if (gridProduto.SelectedRows.Count > 0)
            {
                ID = gridProduto.Rows[gridProduto.SelectedRows[0].Index].Cells[2].Value.ToString();

                if (functions.messageBOXConfirma("Deseja realmente excluir esse produto?", "Tem certeza disso?"))
                {
                    if (functions.updateChangeDeleteDatabase($"DELETE FROM tbl_produto WHERE Codigo_Produto = '{ID}'"))
                    {
                        functions.removeSelectedRow(gridProduto);
                        functions.messageBOXok("Produto deletado com sucesso!");
                    }
                }
            }
            else
            {
                functions.messageBOXwarning("Selecione uma linha para deletar!");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridProduto.SelectedRows.Count > 0)
            {
                cadastroProduto formCadProduta = new cadastroProduto(this);
                formCadProduta.ShowDialog();
                atualizarGridProduto("SELECT tbl_produto.Codigo_Artesao AS 'Codigo', tbl_artesao.Nome_Artesao AS 'Nome', tbl_produto.Codigo_Produto, tbl_produto.TipoProduto_Produto, tbl_produto.Preco_Produto FROM tbl_produto INNER JOIN tbl_artesao ON tbl_artesao.ID_Artesao = tbl_produto.Codigo_Artesao ORDER BY Codigo_Artesao, Codigo_Produto;");
            }
            else
            {
                functions.messageBOXwarning("Selecione um produto para editar!");
            }
        }

        private void btnAddEstoque_Click(object sender, EventArgs e)
        {          
            if (gridProduto.SelectedRows.Count > 0)
            {
                cadastroEstoque fEstoque = new cadastroEstoque(this);
                fEstoque.ShowDialog();
            }
            else
            {
                functions.messageBOXwarning("Selecione um produto para adicionar no estoque!");
            }
        }

        /* ------------------------------------------------------------- */

        public string[] getArrayInfo()
        {
            string[] info = new string[5];

            for (int i = 0; i < info.Length; i++)
            {
                info[i] = gridProduto.Rows[gridProduto.SelectedRows[0].Index].Cells[i].Value.ToString();
            }

            return info;
        }

        public string getIdProdutGrid()
        {
            return gridProduto.Rows[gridProduto.SelectedRows[0].Index].Cells[2].Value.ToString();
        }

        private string makeWhere()
        {
            string auxV = "WHERE 1=1 ";

            if (txtCodArt.Text != "")
            {
                auxV += " AND Codigo_Artesao LIKE " + txtCodArt.Text;
            }

            if (txtCodProduto.Text != "")
            {
                auxV += " AND Codigo_Produto LIKE '" + txtCodProduto.Text + "%'";
            }

            if (cmbTipoProduto.GetItemText(cmbTipoProduto.SelectedItem) != "Nenhum" && cmbTipoProduto.GetItemText(cmbTipoProduto.SelectedItem) != "")
            {
                auxV += " AND TipoProduto_Produto = '" + cmbTipoProduto.GetItemText(cmbTipoProduto.SelectedItem) + "'";
            }

            return auxV;
        }

        public void configGridProduto()
        {
            gridProduto.Columns[0].HeaderText = "Artesão";
            gridProduto.Columns[1].HeaderText = "Nome do Artesão";
            gridProduto.Columns[2].HeaderText = "Produto";
            gridProduto.Columns[3].HeaderText = "Tipo do Produto";
            gridProduto.Columns[4].HeaderText = "Preço";

            gridProduto.Columns[0].Width = 100;
            gridProduto.Columns[1].Width = 200;
            gridProduto.Columns[2].Width = 100;
            gridProduto.Columns[3].Width = 180;
            gridProduto.Columns[4].Width = 140;

            gridProduto.Columns[4].DefaultCellStyle.Format = "C2";
        }

        public void fillGridProduto(string select)
        {
            MySqlConnection con = functions.connectionSQL();

            try
            {
                MySqlCommand query = new MySqlCommand(select, con);
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                DataSet ds = new DataSet();
                da.Fill(ds);

                gridProduto.DataSource = ds;
                gridProduto.DataMember = ds.Tables[0].TableName;
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

        public void atualizarGridProduto(string select)
        {
            fillGridProduto(select);
            configGridProduto();
        }

        private void fillCmbTipoProduto()
        {
            functions.fillCmb("SELECT * FROM tbl_tipoproduto ORDER BY Nome_TipoProduto", "Nome_TipoProduto", cmbTipoProduto);
        }

        private void clearTxt()
        {
            txtCodArt.Clear();
            txtCodProduto.Clear();
        }


    }
}
