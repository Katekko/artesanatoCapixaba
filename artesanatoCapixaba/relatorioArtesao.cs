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
    public partial class relatorioArtesao : Form
    {

        private string selectGridArtesaoTotal = "";
        private string selectGridArtesaoItens =
            "SELECT tbl_artesao.Nome_Artesao, tbl_itensvenda.Codigo_Produto, Quantidade_Produto, ValorTotal_Item , ValorArtesao_Item" +
            " FROM tbl_produto" +
            " INNER JOIN tbl_itensvenda ON tbl_itensvenda.Codigo_Produto = tbl_produto.Codigo_Produto" +
            " INNER JOIN tbl_artesao ON tbl_artesao.ID_Artesao = tbl_produto.Codigo_Artesao" +
            " WHERE tbl_produto.Codigo_Artesao = ";

        public relatorioArtesao()
        {
            InitializeComponent();
        }

        /***********************************************************************/

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string codArtesao = txtCodArtesao.Text;
            string select = "";

            if (txtCodArtesao.Text != "")
            {
                switch (cmbTipoRelatorio.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        select = selectGridArtesaoItens + codArtesao;
                        atualizargridArtesao(select);
                        break;
                    default:
                        functions.messageBOXwarning("Selecione um tipo de relátorio!");
                        break;
                }
            }
            else
            {
                functions.messageBOXwarning("Selecione o artesão!");
                txtCodArtesao.Focus();
            }

        }

        private void txtCodArtesao_Leave(object sender, EventArgs e)
        {
            if (!checkExistArtesao(txtCodArtesao.Text))
            {
                functions.messageBOXwarning("Artesão inexistente, escolha outro!");
                txtCodArtesao.Focus();
                txtCodArtesao.Text = "";
                txtCodArtesao.BackColor = Color.White;
            }
            txtCodArtesao.BackColor = Color.Chartreuse;
        }

        /***********************************************************************/

        private void atualizargridArtesao(string select)
        {
            fillgridArtesao(select);
            configGridArtesao();
        }

        private void fillgridArtesao(string select)
        {
            functions.fillGridFromSelect(select, gridArtesao);
        }

        private void configGridArtesao()
        {
            gridArtesao.Columns[3].DefaultCellStyle.Format = "C2";
            gridArtesao.Columns[4].DefaultCellStyle.Format = "C2";

            gridArtesao.Columns[0].HeaderText = "Artesão";
            gridArtesao.Columns[1].HeaderText = "Produto";
            gridArtesao.Columns[2].HeaderText = "Quantidade";
            gridArtesao.Columns[3].HeaderText = "Valor Total";
            gridArtesao.Columns[4].HeaderText = "Valor P/ Artesão";

            gridArtesao.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridArtesao.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridArtesao.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridArtesao.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridArtesao.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private bool checkExistArtesao(string ID_Artesao)
        {
            MySqlConnection con = functions.connectionSQL();
            MySqlCommand query;

            query = new MySqlCommand($"SELECT ID_Artesao FROM tbl_artesao WHERE ID_Artesao = '{ID_Artesao}'", con);


            var leitor = query.ExecuteReader();

            if (leitor.HasRows)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }


    }
}
