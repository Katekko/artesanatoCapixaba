
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace artesanatoCapixaba
{
    public partial class Artesao : Form
    {

        public Artesao()
        {
            InitializeComponent();

            atualizarGridArtesao($"SELECT * FROM tbl_artesao");
        }

        private void btnCadastrarArtesao_Click(object sender, EventArgs e)
        {
            cadastroArtesao cadArtesao = new cadastroArtesao();
            functions.configForm(cadArtesao);
            cadArtesao.ShowDialog();
            atualizarGridArtesao("SELECT * FROM tbl_artesao");
        }

        private void btnConfirmarPagamento_Click(object sender, EventArgs e)
        {
            Pagamento fPagamento = new Pagamento();
            functions.configForm(fPagamento);
            fPagamento.ShowDialog();
        }

        private void KeyPressOnlyNumb(object sender, KeyPressEventArgs e)
        {
            functions.KeyPressOnlyNumber(sender, e);

            if (e.KeyChar == (char)13)
            {
                atualizarGridArtesao($"SELECT * FROM tbl_artesao {makeWhere()}");
            }
        }

        private void KeyPressEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                string query = $"SELECT * FROM tbl_artesao {makeWhere()}";

                fillGridArtesao(query);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM tbl_artesao {makeWhere()}";

            fillGridArtesao(query);
        }

        private void lblEditar_Click(object sender, EventArgs e)
        {
            if (gridArtesao.SelectedRows.Count > 0)
            {
                cadastroArtesao formCadArtesao = new cadastroArtesao(this);
                functions.configForm(formCadArtesao);
                formCadArtesao.ShowDialog();
                atualizarGridArtesao("SELECT * FROM tbl_artesao");
            }
            else
            {
                functions.messageBOXwarning("Selecione um artesão para editar!");
            }
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            relatorioArtesao fRelatorioArtesao = new relatorioArtesao();
            functions.configForm(fRelatorioArtesao);
            fRelatorioArtesao.Show();
        }

        /****************************************************************/

        public string[] getArrayInfo()
        {
            string[] info = new string[7];

            for (int i = 0; i < info.Length; i++)
            {
                info[i] = gridArtesao.Rows[gridArtesao.SelectedRows[0].Index].Cells[i].Value.ToString();
            }

            return info;
        }

        public void configGridArtesao()
        {
            gridArtesao.Columns[0].HeaderText = "Cod";
            gridArtesao.Columns[1].HeaderText = "Nome";
            gridArtesao.Columns[2].HeaderText = "CPF";
            gridArtesao.Columns[3].HeaderText = "Municipio";
            gridArtesao.Columns[4].HeaderText = "SICAB";
            gridArtesao.Columns[5].HeaderText = "Material";
            gridArtesao.Columns[6].HeaderText = "Técnica";

            gridArtesao.Columns[0].Width = 40;
            gridArtesao.Columns[1].Width = 150;
            gridArtesao.Columns[2].Width = 160;
            //gridArtesao.Columns[3].Width = ;
            gridArtesao.Columns[4].Width = 150;
            gridArtesao.Columns[5].Width = 130;
            gridArtesao.Columns[6].Width = 95;
        }

        public void fillGridArtesao(string select)
        {
            SqlConnection con = functions.connectionSQL();

            try
            {
                SqlCommand query = new SqlCommand(select , con);
                SqlDataAdapter da = new SqlDataAdapter(query);
                DataSet ds = new DataSet();
                da.Fill(ds);

                gridArtesao.DataSource = ds;
                gridArtesao.DataMember = ds.Tables[0].TableName;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Não foi possivel inserir os dados na grid, chame o desenvolvedor. --" + ex);
            }
            finally
            {
                con.Close();
            }

        }

        private void clearTxt()
        {
            txtCod.Clear();
            txtMatPrima.Clear();
            txtMunicipio.Clear();
            txtNome.Clear();
            txtTecnica.Clear();
            txtNunSICAB.Clear();
            txtCPF.Clear();
        }

        private string makeWhere()
        {
            string auxV = "WHERE 1=1 ";

            if (txtCod.Text != "")
            {
                auxV += " AND ID_Artesao = " + txtCod.Text;
            }

            if (txtNome.Text != "")
            {
                auxV += " AND Nome_Artesao LIKE '" + txtNome.Text + "%'";
            }

            if (txtCPF.Text != "")
            {
                auxV += " AND CPF_Artesao LIKE '" + txtCPF.Text + "%'";
            }

            if (txtMunicipio.Text != "")
            { 
                auxV += " AND Municipio_Artesao LIKE '" + txtMunicipio.Text + "%'";
            }

            if (txtNunSICAB.Text != "")
            {
                auxV += " AND NunSICAB_Artesao LIKE '" + txtNunSICAB.Text + "%'";
            }

            if (txtMatPrima.Text != "")
            {
                auxV += " AND MateriaPrima_Artesao LIKE '" + txtMatPrima.Text + "%'";
            }

            if (txtTecnica.Text != "")
            {
                auxV += " AND Tecnica_Artesao LIKE '" + txtTecnica.Text + "%'";
            }

            return auxV;
        }

        public void atualizarGridArtesao(string select)
        {
            fillGridArtesao(select);
            configGridArtesao();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            string ID;

            if (gridArtesao.SelectedRows.Count > 0)
            {
                ID = gridArtesao.Rows[gridArtesao.SelectedRows[0].Index].Cells[0].Value.ToString();

                if (functions.messageBOXConfirma("Deseja realmente excluir este Artesão?", "Tem certeza disso?"))
                {
                    if (functions.messageBOXConfirma($"Este artesão apresenta {getQuantItensCad(ID)} produtos cadastrados e {getQuantItensCadEstoque(ID)} no estoque. Deseja excluir mesmo assim?", "Tem muita certeza disso?"))
                    {
                        if (functions.updateChangeDeleteDatabase($"DELETE FROM tbl_estoque WHERE Codigo_Produto LIKE '{ID}%'"))
                        {
                            if (functions.updateChangeDeleteDatabase($"DELETE FROM tbl_produto WHERE Codigo_Artesao = {ID}"))
                            {
                                if (functions.updateChangeDeleteDatabase($"DELETE FROM tbl_artesao WHERE ID_Artesao = '{ID}'"))
                                {
                                    functions.removeSelectedRow(gridArtesao);
                                    functions.messageBOXok("Artesao deletado com sucesso!");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                functions.messageBOXwarning("Selecione uma linha para deletar!");
            }
        }

        private int getQuantItensCad(string ID)
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand($"SELECT * FROM tbl_produto WHERE Codigo_Artesao = {ID}",con);
            var leitor = query.ExecuteReader();
            int cont = 0;
            while (leitor.Read())
            {
                cont++;
            }
            leitor.Close();
            con.Close();
            return cont;
        }

        private int getQuantItensCadEstoque(string ID)
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand($"SELECT * FROM tbl_estoque WHERE Codigo_Produto LIKE '{ID}%'",con);
            var leitor = query.ExecuteReader();
            int cont = 0;
            while (leitor.Read())
            {
                cont++;
            }
            leitor.Close();
            con.Close();
            return cont;
        }


    }
}
