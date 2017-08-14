using System;
using System.Windows.Forms;
using System.Data;
using ClosedXML.Excel;

using System.Collections.Generic;
using System.Drawing;
using System.Data.SqlClient;

namespace artesanatoCapixaba
{
    public partial class menuPrincipal : Form
    {

        string selectGridVendas =
            "SELECT tbl_registrovendas.Codigo_Venda, tbl_vendedor.Nome_Vendedor AS 'Nome', tbl_itensvenda.Codigo_Produto, tbl_itensvenda.Quantidade_Produto, tbl_itensvenda.ValorTotal_Item, tbl_registrovendas.Data_Venda" +
            " FROM tbl_registrovendas " +
            " INNER JOIN tbl_vendedor ON tbl_vendedor.Codigo_Vendedor = tbl_registrovendas.Codigo_Vendedor" +
            " INNER JOIN tbl_itensvenda ON tbl_itensvenda.Codigo_Venda = tbl_registrovendas.Codigo_Venda ";

        public menuPrincipal()
        {
            InitializeComponent();

            ControlBox = false;

            dtpVendasDe.Enabled = false;
            dtpVendasAte.Enabled = false;

            lblUsuario.Text = functions.getUsuarioAtual();

            atualizarGridVendas(selectGridVendas);

        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            functions.closeProgram();
        }

        private void btnArtesao_Click(object sender, EventArgs e)
        {
            Artesao fArtesao = new Artesao();
            functions.configForm(fArtesao);
            fArtesao.Show();
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            Produto fProduto = new Produto();
            functions.configForm(fProduto);
            fProduto.Show();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            Estoque fEstoque = new Estoque();
            functions.configForm(fEstoque);
            fEstoque.Show();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            Venda fVenda = new Venda();
            functions.configForm(fVenda);
            fVenda.Show();
            atualizarGridVendas(selectGridVendas);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            atualizarGridVendas(selectGridVendas + makeWhere());
        }

        private void chkUseData_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseData.Checked)
            {
                dtpVendasDe.Enabled = true;
                dtpVendasAte.Enabled = true;
            }
            else
            {
                dtpVendasDe.Enabled = false;
                dtpVendasAte.Enabled = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() != DialogResult.Cancel)
            {

                Cursor.Current = Cursors.WaitCursor;

                exportarGrid();

                Cursor.Current = Cursors.Default;

                functions.messageBOXok("Dados exportados com sucesso!!!");

            }

        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {
            Caixa fCaixa = new Caixa();
            functions.configForm(fCaixa);
            fCaixa.ShowDialog();
            if (functions.caixaEstado)
            {
                btnVender.Enabled = true;
                btnVender.BackColor = Color.Gold;
            }
            else
            {
                btnVender.Enabled = false;
                btnVender.BackColor = Color.LightGray;
            }
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            Caixa cx = new Caixa();
            cx.exportarCaixaFinal();
        }

        /****************************************************************/

        private void exportarGrid()
        {
            var workbook = new XLWorkbook();
            var relatorioVendas = workbook.Worksheets.Add("Relatório de Vendas");

            var col1 = relatorioVendas.Column("A");
            col1.Width = 16;
            col1.Style.Font.FontSize = 16;
            col1.Style.Font.Bold = true;
            col1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            var col2 = relatorioVendas.Column("B");
            col2.Width = 34;
            col2.Style.Font.FontSize = 16;
            col2.Style.Font.Bold = true;

            var col3 = relatorioVendas.Column("C");
            col3.Width = 15;
            col3.Style.Font.FontSize = 16;
            col3.Style.Font.Bold = true;

            var col4 = relatorioVendas.Column("D");
            col4.Width = 8;
            col4.Style.Font.FontSize = 16;
            col4.Style.Font.Bold = true;

            var col5 = relatorioVendas.Column("E");
            col5.Width = 16;
            col5.Style.Font.FontSize = 16;
            col5.Style.Font.Bold = true;
            col5.Style.NumberFormat.Format = "R$ #,##0.00";

            var col6 = relatorioVendas.Column("F");
            col6.Width = 26;
            col6.Style.Font.FontSize = 16;
            col6.Style.Font.Bold = true;

            var col7 = relatorioVendas.Column("H");
            col7.Width = 9;
            col7.Style.Font.FontSize = 16;
            col7.Style.Font.Bold = true;

            var col8 = relatorioVendas.Column("I");
            col8.Width = 36;
            col8.Style.Font.FontSize = 16;
            col8.Style.Font.Bold = true;

            var range2 = relatorioVendas.Range("A1:F1");
            range2.Style.Fill.BackgroundColor = XLColor.Yellow;
            range2.Style.Font.FontColor = XLColor.Red;
            range2.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            range2.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            var range3 = relatorioVendas.Range("H1:H2");
            range3.Style.Fill.BackgroundColor = XLColor.Yellow;
            range3.Style.Font.FontColor = XLColor.Red;
            range3.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            range3.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            var range4 = relatorioVendas.Range("I1:I2");
            range4.Style.Fill.BackgroundColor = XLColor.Red;
            range4.Style.Font.FontColor = XLColor.Yellow;
            range4.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            range4.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            if (chkUseData.Checked == true)
            {
                relatorioVendas.Cell("I3").Value = dtpVendasDe.Text + " Até " + dtpVendasAte.Text;
            }
            else
            {
                relatorioVendas.Cell("I3").Value = "Todas as vendas registradas";
            }

            relatorioVendas.Cell("I3").Style.Fill.BackgroundColor = XLColor.FromArgb(36, 64, 98);
            relatorioVendas.Cell("I3").Style.Font.FontColor = XLColor.FromArgb(226, 107, 10);
            relatorioVendas.Cell("I3").Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            relatorioVendas.Cell("I3").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            relatorioVendas.Cell("H1").Value = "Total:";
            relatorioVendas.Cell("H1").Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            relatorioVendas.Cell("H1").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            relatorioVendas.Cell("I1").Value = "R$ " + lblTotalResult.Text;
            relatorioVendas.Cell("I1").Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            relatorioVendas.Cell("I1").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            relatorioVendas.Cell("H2").Value = "Itens:";
            relatorioVendas.Cell("H2").Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            relatorioVendas.Cell("H2").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            relatorioVendas.Cell("I2").Value = lblItensVendidosResult.Text;
            relatorioVendas.Cell("I2").Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            relatorioVendas.Cell("I2").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

            relatorioVendas.Cell("A1").Value = "Venda";
            relatorioVendas.Cell("B1").Value = "Vendedor";
            relatorioVendas.Cell("C1").Value = "Produto";
            relatorioVendas.Cell("D1").Value = "Quant";
            relatorioVendas.Cell("E1").Value = "Arrecado";
            relatorioVendas.Cell("F1").Value = "Data";


            for (int i = 0; i < gridVendas.RowCount - 1; i++)
            {
                relatorioVendas.Cell(2 + i, 1).Value = gridVendas.Rows[i].Cells[0].Value.ToString();
                relatorioVendas.Cell(2 + i, 1).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
                relatorioVendas.Cell(2 + i, 1).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioVendas.Cell(2 + i, 2).Value = gridVendas.Rows[i].Cells[1].Value.ToString();
                relatorioVendas.Cell(2 + i, 2).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
                relatorioVendas.Cell(2 + i, 2).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioVendas.Cell(2 + i, 3).Value = gridVendas.Rows[i].Cells[2].Value.ToString();
                relatorioVendas.Cell(2 + i, 3).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
                relatorioVendas.Cell(2 + i, 3).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioVendas.Cell(2 + i, 4).Value = gridVendas.Rows[i].Cells[3].Value.ToString();
                relatorioVendas.Cell(2 + i, 4).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
                relatorioVendas.Cell(2 + i, 4).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioVendas.Cell(2 + i, 5).Value = Double.Parse(gridVendas.Rows[i].Cells[4].Value.ToString());
                relatorioVendas.Cell(2 + i, 5).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
                relatorioVendas.Cell(2 + i, 5).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioVendas.Cell(2 + i, 6).Value = gridVendas.Rows[i].Cells[5].Value.ToString();
                relatorioVendas.Cell(2 + i, 6).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
                relatorioVendas.Cell(2 + i, 6).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            }



            workbook.SaveAs(saveFile.FileName.ToString() + ".xlsx");

        }

        private void atualizarGridVendas(string select)
        {
            configGridVendas();
            fillGridVendas(select);
        }

        private void fillGridVendas(string select)
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand(select, con);

            var leitor = query.ExecuteReader();

            functions.clearGrid(gridVendas);

            double contValor = 0;
            int contItens = 0;

            if (!leitor.HasRows)
            {
                lblTotalResult.Text = "R$ 0,00";
                lblItensVendidosResult.Text = "0 itens";
                functions.messageBOXok($"Nenhuma venda registrada entre {dtpVendasDe.Text} e {dtpVendasAte.Text}!!!");
            }
            else
            {
                while (leitor.Read())
                {
                    //Codigo_Venda, Nome, Codigo_Produto, Quantidade_Produto, ValorTotal_Item, Data_Venda
                    gridVendas.Rows.Add(leitor["Codigo_Venda"], leitor["Nome"], leitor["Codigo_Produto"], leitor["Quantidade_Produto"], Double.Parse(leitor["ValorTotal_Item"].ToString().Replace('.', ',')), leitor["Data_Venda"]);
                    contItens += Int32.Parse(leitor["Quantidade_Produto"].ToString());
                    contValor += Double.Parse(leitor["ValorTotal_Item"].ToString());
                }

                lblTotalResult.Text = "R$ " + contValor;
                lblItensVendidosResult.Text = contItens + " itens";
            }

            leitor.Close();
            con.Close();
        }

        private void configGridVendas()
        {

            gridVendas.ColumnCount = 6;

            gridVendas.Columns[0].Name = "Codigo_Venda";
            gridVendas.Columns[1].Name = "Nome";
            gridVendas.Columns[2].Name = "Codigo_Produto";
            gridVendas.Columns[3].Name = "Quantidade_Produto";
            gridVendas.Columns[4].Name = "ValorTotal_Item";
            gridVendas.Columns[5].Name = "Data_Venda";

            gridVendas.Columns[0].HeaderText = "Venda";
            gridVendas.Columns[1].HeaderText = "Vendedor";
            gridVendas.Columns[2].HeaderText = "Produto";
            gridVendas.Columns[3].HeaderText = "Quant.";
            gridVendas.Columns[4].HeaderText = "Arrecadado";
            gridVendas.Columns[5].HeaderText = "Data Venda";

            gridVendas.Columns[4].DefaultCellStyle.Format = "C2";

            gridVendas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridVendas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridVendas.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridVendas.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridVendas.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridVendas.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private string makeWhere()
        {
            string auxV = "WHERE 1=1 ";

            if (txtVendedor.Text != "")
            {
                auxV += $" AND tbl_vendedor.Nome_Vendedor LIKE '{txtVendedor.Text}%'";
            }

            if (chkUseData.Checked)
            {
                auxV += $" AND (tbl_registrovendas.Data_Venda BETWEEN '{functions.configDataSql(dtpVendasDe.Text)} 0:0:0' AND '{functions.configDataSql(dtpVendasAte.Text)} 23:59:59')";
            }
            return auxV;
        }

        private void preencherValues()
        {
            List<double> listaArtesao = new List<double>();
            List<double> listaLoja = new List<double>();

            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand("SELECT ValorTotal_Item FROM tbl_itensvenda", con);
            var leitor = query.ExecuteReader();

            int i = 0;

            for (i = 0; leitor.Read(); i++)
            {
                listaArtesao.Add(Double.Parse(leitor["ValorTotal_Item"].ToString()) * 0.7);

                listaLoja.Add(Double.Parse(leitor["ValorTotal_Item"].ToString()) * 0.3);
            }

            leitor.Close();
            con.Close();
            for (int j = 0; j < i; j++)
            {
                functions.updateChangeDeleteDatabase($"UPDATE tbl_itensvenda SET ValorArtesao_Item = {listaArtesao[j].ToString().Replace(',', '.')}, ValorLoja_Item = {listaLoja[j].ToString().Replace(',', '.')} WHERE Index_Venda = '{j + 1}'");
            }
        }


    }
}
