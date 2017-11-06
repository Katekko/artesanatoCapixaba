using ClosedXML.Excel;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace artesanatoCapixaba
{
    public partial class relatorioArtesao : Form
    {
        private class Item
        {
            private string name;

            public string Name { get => name; set => name = value; }

            private int quantidade;

            public int Quantidade { get => quantidade; set => quantidade = value; }

            private float valorUnitario;

            public float ValorUnitario { get => valorUnitario; set => valorUnitario = value; }

            private float valorTotal;

            public float ValorTotal { get => valorTotal; set => valorTotal = value; }
        }

        private string selectGridArtesaoItens =
            "SELECT tbl_itensvenda.Codigo_Produto, tbl_itensvenda.Quantidade_Produto, tbl_itensvenda.ValorTotal_Item , tbl_itensvenda.ValorArtesao_Item, tbl_produto.TipoProduto_Produto" +
            " FROM tbl_produto" +
            " INNER JOIN tbl_itensvenda ON tbl_itensvenda.Codigo_Produto = tbl_produto.Codigo_Produto" +
            " INNER JOIN tbl_artesao ON tbl_artesao.ID_Artesao = tbl_produto.Codigo_Artesao" +
            " INNER JOIN tbl_registrovendas ON tbl_registrovendas.Codigo_Venda = tbl_itensvenda.Codigo_Venda";

        int contQuantidade = 0;
        double contValor = 0;

        Dictionary<string, Item> dicItems = new Dictionary<string, Item>();

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

                select = selectGridArtesaoItens + makeWhereItens(codArtesao);
                atualizargridArtesao(select);
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
                txtNomeArtesao.Text = "";
                txtCodArtesao.BackColor = Color.White;

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

            lblTotalItensResult.Text = "";
            lblTotalValorResult.Text = "";
            functions.clearGrid(gridArtesao);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (checkToExport())
            {
                exportGridArtesao2();
            }
        }

        /***********************************************************************/

        private bool checkToExport()
        {
            if (gridArtesao.RowCount <= 1)
            {
                functions.messageBOXwarning("Sem dados para exportar!");
                return false;
            }
            return true;
        }

        private string makeWhereItens(string codArtesao)
        {
            string str = "";

            str += " WHERE tbl_produto.Codigo_Artesao = " + codArtesao;

            str += $" AND tbl_registrovendas.Data_Venda BETWEEN '{functions.configDataSql(dtpDataDe.Text)} 00:00:00' AND '{functions.configDataSql(dtpDataAte.Text)} 23:59:59' ;";

            return str;
        }

        private void atualizargridArtesao(string select)
        {  
            configGridArtesao();
            fillgridArtesao(select); 
        }

        private void fillgridArtesao(string select)
        {
            

            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand(select,con);

            var leitor = query.ExecuteReader();

            functions.clearGrid(gridArtesao);
            contQuantidade = 0;
            contValor = 0;

            if (!leitor.HasRows)
            {
                lblTotalItensResult.Visible = false;
                lblTotalValorResult.Visible = false;
                functions.messageBOXok($"Este artesão não tem nenhuma venda registrada entre {dtpDataDe.Text} e {dtpDataAte.Text}!!!");
            }
            else
            {
                while (leitor.Read())
                {
                    gridArtesao.Rows.Add(leitor["Codigo_Produto"], leitor["Quantidade_Produto"], Double.Parse(leitor["ValorTotal_Item"].ToString()), Double.Parse(leitor["ValorArtesao_Item"].ToString().Replace('.', ',')), leitor["TipoProduto_Produto"].ToString());
                    contQuantidade += Int32.Parse(leitor["Quantidade_Produto"].ToString());
                    contValor += Double.Parse(leitor["ValorArtesao_Item"].ToString());
                }

                lblTotalItensResult.Visible = true;
                lblTotalValorResult.Visible = true;

                lblTotalItensResult.Text = contQuantidade + " itens";
                lblTotalValorResult.Text = "R$ " + contValor;

                lblTotalItensResult.ForeColor = Color.Red;
                lblTotalValorResult.ForeColor = Color.Red;
            }
        
            leitor.Close();
            con.Close();
        }

        private void configGridArtesao()
        {
            gridArtesao.ColumnCount = 5;

            gridArtesao.Columns[0].Name = "Codigo_Produto";
            gridArtesao.Columns[1].Name = "Quantidade_Produto";
            gridArtesao.Columns[2].Name = "ValorTotal_Item";
            gridArtesao.Columns[3].Name = "ValorArtesao_Item";
            gridArtesao.Columns[4].Name = "TipoProduto_Produto";

            gridArtesao.Columns[0].HeaderText = "Produto";
            gridArtesao.Columns[1].HeaderText = "Quantidade";
            gridArtesao.Columns[2].HeaderText = "Valor Total";
            gridArtesao.Columns[3].HeaderText = "Valor P/ Artesão";
            gridArtesao.Columns[4].HeaderText = "Nome do Produto";

            gridArtesao.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridArtesao.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridArtesao.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridArtesao.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridArtesao.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            gridArtesao.Columns[2].DefaultCellStyle.Format = "C2";
            gridArtesao.Columns[3].DefaultCellStyle.Format = "C2";
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

        private void exportGridArtesao2()
        {
            if (saveFile.ShowDialog() != DialogResult.Cancel)
            {
                Cursor.Current = Cursors.WaitCursor;

                var workbook = new XLWorkbook();
                var ws = workbook.Worksheets.Add("Relatorio de Artesão");

                ws.Column("A").Width = 26.43;
                ws.Column("B").Width = 14.14;
                ws.Column("C").Width = 19.43;
                ws.Column("D").Width = 19.43;

                ws.Range("A1:D4").Style.Font.FontSize = 14;

                ws.Range("A1:D1").Merge();
                ws.Range("A1:D1").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
                ws.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("A1").Style.Font.Bold = true;
                ws.Cell("A1").Value = "LOJA ARTESANATO CAPIXABA";

                ws.Range("A2:D2").Merge();
                ws.Range("A2:D2").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
                ws.Cell("A2").Style.Font.Italic = true;
                ws.Cell("A2").Value = $"Artesão: {txtNomeArtesao.Text}";

                ws.Range("A3:D3").Merge();
                ws.Range("A3:D3").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
                ws.Cell("A3").Style.Font.Italic = true;
                ws.Cell("A3").Value = $"Data de medição: {dtpDataDe.Text} até {dtpDataAte.Text}";

                ws.Range("A4:D4").Style.Font.Bold = true;
                ws.Range("A4:D4").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
                ws.Range("A4:D4").Style.Border.SetInsideBorder(XLBorderStyleValues.Thick);
                ws.Cell("A4").Value = "Produto";
                ws.Cell("B4").Value = "Quantidade";
                ws.Cell("C4").Value = "Valor Unitário";
                ws.Cell("D4").Value = "Valor Total";

                PreencherItens();

                Item[] itemV = new Item[dicItems.Count];

                int cont = 0;
                foreach (Item item in dicItems.Values)
                {
                    itemV[cont] = item;
                    cont++;
                }

                for (int i = 0; i < dicItems.Count; i++)
                {
                    ws.Cell(i + 5, 1).Value = itemV[i].Name;
                    ws.Cell(i + 5, 1).Style.Font.FontSize = 14;
                    ws.Cell(i + 5, 1).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);

                    ws.Cell(i + 5, 2).Value = itemV[i].Quantidade;
                    ws.Cell(i + 5, 2).Style.Font.FontSize = 14;
                    ws.Cell(i + 5, 2).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);

                    ws.Cell(i + 5, 3).Value = itemV[i].ValorUnitario;
                    ws.Cell(i + 5, 3).Style.Font.FontSize = 14;
                    ws.Cell(i + 5, 3).Style.NumberFormat.Format = "R$ #,##0.00";
                    ws.Cell(i + 5, 3).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);

                    ws.Cell(i + 5, 4).Value = itemV[i].ValorTotal;
                    ws.Cell(i + 5, 4).Style.Font.FontSize = 14;
                    ws.Cell(i + 5, 4).Style.NumberFormat.Format = "R$ #,##0.00";
                    ws.Cell(i + 5, 4).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);

                }


                var rTotalVendido = ws.Range(dicItems.Count + 5, 1, dicItems.Count + 5, 2);
                rTotalVendido.Merge();
                rTotalVendido.Style.Font.Bold = true;
                rTotalVendido.Style.Font.FontSize = 14;
                rTotalVendido.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
                rTotalVendido.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                rTotalVendido.Value = "Valor Total Vendido";

                var rValorTotalVendido = ws.Range(dicItems.Count + 5, 3, dicItems.Count + 5, 4);
                rValorTotalVendido.Merge();
                rValorTotalVendido.Style.Font.FontSize = 14;
                rValorTotalVendido.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
                rValorTotalVendido.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                rValorTotalVendido.Style.NumberFormat.Format = "R$ #,##0.00";
                rValorTotalVendido.FormulaA1 = $"=SUM(D{dicItems.Count + 4}:D5)";

                var rTotalDoArtesao = ws.Range(dicItems.Count + 6, 1, dicItems.Count + 6, 2);
                rTotalDoArtesao.Merge();
                rTotalDoArtesao.Style.Font.Bold = true;
                rTotalDoArtesao.Style.Font.FontSize = 14;
                rTotalDoArtesao.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
                rTotalDoArtesao.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                rTotalDoArtesao.Value = "Valor do Artesão";

                var rValorTotalDoArtesao = ws.Range(dicItems.Count + 6, 3, dicItems.Count + 6, 4);
                rValorTotalDoArtesao.Merge();
                rValorTotalDoArtesao.Style.Font.FontSize = 14;
                rValorTotalDoArtesao.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thick);
                rValorTotalDoArtesao.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                rValorTotalDoArtesao.Style.NumberFormat.Format = "R$ #,##0.00";
                rValorTotalDoArtesao.FormulaA1 = $"C{dicItems.Count+5} * 0.7";

                workbook.SaveAs(saveFile.FileName.ToString() + ".xlsx");

                Cursor.Current = Cursors.Default;

                functions.messageBOXok("Dados Exportados com Sucesso");
            }
        }

        private void PreencherItens()
        {
            dicItems.Clear();
            for (int i = 0; i < gridArtesao.RowCount - 1; i++)
            {
                string itemK = gridArtesao.Rows[i].Cells[0].Value.ToString(); //key (codigo)
                string itemN = gridArtesao.Rows[i].Cells[4].Value.ToString(); //aqui entra o nome fantasia do item
                int itemQ = Int32.Parse(gridArtesao.Rows[i].Cells[1].Value.ToString()); //quantidade
                float itemVT = float.Parse(gridArtesao.Rows[i].Cells[2].Value.ToString());
                float itemVU = itemVT / itemQ;
                if (!dicItems.ContainsKey(itemK))
                {
                    dicItems.Add(itemK, new Item { Name = itemN, Quantidade = itemQ , ValorTotal = itemVT, ValorUnitario = itemVU});
                }
                else
                {
                    Item item = dicItems[itemK];
                    item.Quantidade += itemQ;
                    item.ValorTotal += itemVT;
                    dicItems[itemK] = item;
                }
            }
        }

        private void exportGridArtesao()
        {
            if (saveFile.ShowDialog() != DialogResult.Cancel)
            {
                Cursor.Current = Cursors.WaitCursor;

                var workbook = new XLWorkbook();
                var ws = workbook.Worksheets.Add("Relatorio de Artesão");

                var col1 = ws.Column("B");
                col1.Width = 6;

                var col2 = ws.Column("C");
                col2.Width = 40;

                var col3 = ws.Column("D");
                col3.Width = 12;

                var col4 = ws.Column("E");
                col4.Width = 16;
                col4.Style.NumberFormat.Format = "R$ #,##0.00";
                col4.DataType = XLCellValues.Number;

                var col5 = ws.Column("F");
                col5.Width = 4;
                col5.DataType = XLCellValues.Number;
                col5.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                var range1 = ws.Range("A1:G16");
                range1.Style.Font.FontSize = 16;

                var range2 = ws.Range("A1:G1");
                range2.Style.Fill.BackgroundColor = XLColor.White;

                ws.Cell("B1").Value = "Relatório do Artesão de " + dtpDataDe.Text + " Até " + dtpDataAte.Text;
                ws.Cell("B1").Style.Font.Bold = true;
                ws.Cell("B1").Style.Font.FontColor = XLColor.Red;
                ws.Cell("B1").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("B2").Value = txtCodArtesao.Text;
                ws.Cell("B2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("B2").Style.Font.Bold = true;
                ws.Cell("B2").Style.Fill.BackgroundColor = XLColor.Aqua;
                ws.Cell("B2").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("C2").Value = txtNomeArtesao.Text;
                ws.Cell("C2").Style.Font.Bold = true;
                ws.Cell("C2").Style.Fill.BackgroundColor = XLColor.White;
                ws.Cell("C2").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                for (int i = 0; i < gridArtesao.RowCount - 1; i++)
                {
                    ws.Cell(i + 2, 4).Value = gridArtesao.Rows[i].Cells[0].Value.ToString();
                    ws.Cell(i + 2, 4).Style.Font.Bold = true;
                    ws.Cell(i + 2, 4).Style.Fill.BackgroundColor = XLColor.YellowGreen;
                    ws.Cell(i + 2, 4).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                    ws.Cell(i + 2, 5).Value = Double.Parse(gridArtesao.Rows[i].Cells[2].Value.ToString());
                    ws.Cell(i + 2, 5).Style.Font.Bold = true;
                    ws.Cell(i + 2, 5).Style.Fill.BackgroundColor = XLColor.Gold;
                    ws.Cell(i + 2, 5).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                    ws.Cell(i + 2, 6).Value = Double.Parse(gridArtesao.Rows[i].Cells[1].Value.ToString());
                    ws.Cell(i + 2, 6).Style.Font.Bold = true;
                    ws.Cell(i + 2, 6).Style.Fill.BackgroundColor = XLColor.LightGray;
                    ws.Cell(i + 2, 6).Style.Font.FontColor = XLColor.Violet;
                    ws.Cell(i + 2, 6).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
                }

                ws.Cell((gridArtesao.RowCount - 1) + 2, 4).Value = "Total:";
                ws.Cell((gridArtesao.RowCount - 1) + 2, 4).Style.Font.Bold = true;
                ws.Cell((gridArtesao.RowCount - 1) + 2, 4).Style.Fill.BackgroundColor = XLColor.Red;
                ws.Cell((gridArtesao.RowCount - 1) + 2, 4).Style.Font.FontColor = XLColor.Yellow;
                ws.Cell((gridArtesao.RowCount - 1) + 2, 4).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell((gridArtesao.RowCount - 1) + 2, 5).FormulaA1 = $"=SUM(E2:E{gridArtesao.RowCount})";
                ws.Cell((gridArtesao.RowCount - 1) + 2, 5).Style.Font.Bold = true;
                ws.Cell((gridArtesao.RowCount - 1) + 2, 5).Style.Fill.BackgroundColor = XLColor.Red;
                ws.Cell((gridArtesao.RowCount - 1) + 2, 5).Style.Font.FontColor = XLColor.Yellow;
                ws.Cell((gridArtesao.RowCount - 1) + 2, 5).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell((gridArtesao.RowCount - 1) + 2, 6).FormulaA1 = $"=SUM(F2:F{gridArtesao.RowCount})";
                ws.Cell((gridArtesao.RowCount - 1) + 2, 6).Style.Font.Bold = true;
                ws.Cell((gridArtesao.RowCount - 1) + 2, 6).Style.Fill.BackgroundColor = XLColor.Red;
                ws.Cell((gridArtesao.RowCount - 1) + 2, 6).Style.Font.FontColor = XLColor.Yellow;
                ws.Cell((gridArtesao.RowCount - 1) + 2, 6).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell((gridArtesao.RowCount - 1) + 3, 4).Value = "Artesão:";
                ws.Cell((gridArtesao.RowCount - 1) + 3, 4).Style.Font.Bold = true;
                ws.Cell((gridArtesao.RowCount - 1) + 3, 4).Style.Fill.BackgroundColor = XLColor.LightGray;
                ws.Cell((gridArtesao.RowCount - 1) + 3, 4).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell((gridArtesao.RowCount - 1) + 3, 5).FormulaA1 = $"=E{gridArtesao.RowCount+1}*0.7";
                ws.Cell((gridArtesao.RowCount - 1) + 3, 5).Style.Font.Bold = true;
                ws.Cell((gridArtesao.RowCount - 1) + 3, 5).Style.Fill.BackgroundColor = XLColor.LightGray;
                ws.Cell((gridArtesao.RowCount - 1) + 3, 5).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell((gridArtesao.RowCount - 1) + 4, 4).Value = "Loja:";
                ws.Cell((gridArtesao.RowCount - 1) + 4, 4).Style.Font.Bold = true;
                ws.Cell((gridArtesao.RowCount - 1) + 4, 4).Style.Fill.BackgroundColor = XLColor.LightGray;
                ws.Cell((gridArtesao.RowCount - 1) + 4, 4).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell((gridArtesao.RowCount - 1) + 4, 5).FormulaA1 = $"=E{gridArtesao.RowCount + 1}*0.3";
                ws.Cell((gridArtesao.RowCount - 1) + 4, 5).Style.Font.Bold = true;
                ws.Cell((gridArtesao.RowCount - 1) + 4, 5).Style.Fill.BackgroundColor = XLColor.LightGray;
                ws.Cell((gridArtesao.RowCount - 1) + 4, 5).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                workbook.SaveAs(saveFile.FileName.ToString()+".xlsx");

                Cursor.Current = Cursors.Default;

                functions.messageBOXok("Dados Exportados com Sucesso");
            }
        }

    }
}
