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
            "SELECT tbl_itensvenda.Codigo_Produto, Quantidade_Produto, ValorTotal_Item , ValorArtesao_Item" +
            " FROM tbl_itensvenda" +
            " INNER JOIN tbl_produto ON tbl_produto.Codigo_Produto = tbl_itensvenda.Codigo_Produto" +
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
            gridArtesao.Columns[2].DefaultCellStyle.Format = "C2";
            gridArtesao.Columns[3].DefaultCellStyle.Format = "C2";

            gridArtesao.Columns[0].HeaderText = "Produto";
            gridArtesao.Columns[1].HeaderText = "Quantidade";
            gridArtesao.Columns[2].HeaderText = "Valor Total";
            gridArtesao.Columns[3].HeaderText = "Valor P/ Artesão";

            gridArtesao.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridArtesao.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridArtesao.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridArtesao.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

    }
}
