using ClosedXML.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace artesanatoCapixaba
{
    public partial class Caixa : Form
    {

        public Caixa()
        {
            InitializeComponent();
            configForm(functions.caixaEstado);
        }

        private void btnAbrirCaixa_Click(object sender, EventArgs e)
        {
            abrirCaixa();
        }

        private void btnFecharCaixa_Click(object sender, EventArgs e)
        {
            fecharCaixa();
        }

        private void txtDinheiroCaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            functions.KeyPressOnlyNumber(sender, e);
        }

        /**********************************************************************/

        private void exportarCaixaFinal()
        {
            double[] valores = getTotalVendas();

            DateTime dataAgora = DateTime.Now;
            double saldoInicial = functions.dinheiroCaixa;
            double totalVendas = valores[0];
            double dinheiroVendas = valores[1];
            double cartaoCreVendas = valores[2];
            double cartaoDebVendas = valores[3];

            if (saveFile.ShowDialog() != DialogResult.Cancel)
            {
                Cursor.Current = Cursors.WaitCursor;

                var workbook = new XLWorkbook();
                var relatorioCaixa = workbook.Worksheets.Add("Relatório de Caixa");
                var relatorioItens = workbook.Worksheets.Add("Relatório de Itens");

                /*Relatório Do Caixa*/
                var col1 = relatorioCaixa.Column("A");
                col1.Width = 28;

                var col2 = relatorioCaixa.Column("B");
                col2.Width = 25;

                var range1 = relatorioCaixa.Range("A1:F100");
                range1.Style.Font.FontSize = 16;

                var range2 = relatorioCaixa.Range("B3:B8");
                range2.Style.NumberFormat.Format = "R$ #,##0.00";

                relatorioCaixa.Cell("A1").Value = "CAIXA DO DIA";
                relatorioCaixa.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                relatorioCaixa.Cell("A1").Style.Font.Bold = true;
                relatorioCaixa.Cell("A1").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 192, 0);
                relatorioCaixa.Cell("A1").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioCaixa.Cell("B1").Value = dataAgora;
                relatorioCaixa.Cell("B1").Style.Font.Bold = true;
                relatorioCaixa.Cell("B1").Style.Font.FontColor = XLColor.Red;
                relatorioCaixa.Cell("B1").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 192, 0);
                relatorioCaixa.Cell("B1").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioCaixa.Cell("A3").Value = "1.Saldo Inicial";
                relatorioCaixa.Cell("A3").Style.Font.Bold = true;
                relatorioCaixa.Cell("A3").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                relatorioCaixa.Cell("A3").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioCaixa.Cell("B3").Value = saldoInicial;
                relatorioCaixa.Cell("B3").Style.Font.Bold = true;
                relatorioCaixa.Cell("B3").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                relatorioCaixa.Cell("B3").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioCaixa.Cell("A4").Value = "2.Vendas";
                relatorioCaixa.Cell("A4").Style.Font.Bold = true;
                relatorioCaixa.Cell("A4").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                relatorioCaixa.Cell("A4").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioCaixa.Cell("B4").Value = totalVendas;
                relatorioCaixa.Cell("B4").Style.Font.Bold = true;
                relatorioCaixa.Cell("B4").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                relatorioCaixa.Cell("B4").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioCaixa.Cell("A5").Value = "2.1.Dinheiro";
                relatorioCaixa.Cell("A5").Style.Font.Bold = true;
                relatorioCaixa.Cell("A5").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                relatorioCaixa.Cell("A5").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 176, 80);
                relatorioCaixa.Cell("A5").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioCaixa.Cell("B5").Value = dinheiroVendas;
                relatorioCaixa.Cell("B5").Style.Font.Bold = true;
                relatorioCaixa.Cell("B5").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                relatorioCaixa.Cell("B5").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 176, 80);
                relatorioCaixa.Cell("B5").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioCaixa.Cell("A6").Value = "2.2.Cartão de Credito";
                relatorioCaixa.Cell("A6").Style.Font.Bold = true;
                relatorioCaixa.Cell("A6").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                relatorioCaixa.Cell("A6").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 176, 80);
                relatorioCaixa.Cell("A6").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioCaixa.Cell("B6").Value = cartaoCreVendas;
                relatorioCaixa.Cell("B6").Style.Font.Bold = true;
                relatorioCaixa.Cell("B6").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                relatorioCaixa.Cell("B6").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 176, 80);
                relatorioCaixa.Cell("B6").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioCaixa.Cell("A7").Value = "2.3.Cartão de Débito";
                relatorioCaixa.Cell("A7").Style.Font.Bold = true;
                relatorioCaixa.Cell("A7").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                relatorioCaixa.Cell("A7").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 176, 80);
                relatorioCaixa.Cell("A7").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioCaixa.Cell("B7").Value = cartaoDebVendas;
                relatorioCaixa.Cell("B7").Style.Font.Bold = true;
                relatorioCaixa.Cell("B7").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                relatorioCaixa.Cell("B7").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 176, 80);
                relatorioCaixa.Cell("B7").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioCaixa.Cell("A8").Value = "3.Saldo Final";
                relatorioCaixa.Cell("A8").Style.Font.Bold = true;
                relatorioCaixa.Cell("A8").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                relatorioCaixa.Cell("A8").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 0, 0);
                relatorioCaixa.Cell("A8").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                relatorioCaixa.Cell("B8").FormulaA1 = $"=SUM(B3:B4)";
                relatorioCaixa.Cell("B8").Style.Font.Bold = true;
                relatorioCaixa.Cell("B8").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                relatorioCaixa.Cell("B8").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 0, 0);
                relatorioCaixa.Cell("B8").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                /*--------------------------------------------------------------------------------------*/

                /*Relatório Dos Itens*/

                var col3 = relatorioItens.Column("A");
                col3.Width = 13;

                var col4 = relatorioItens.Column("B");
                col4.Width = 15;

                var col5 = relatorioItens.Column("C");
                col5.Width = 17;

                var row1 = relatorioItens.Row(1);
                row1.Style.Fill.BackgroundColor = XLColor.Yellow;
                row1.Style.Font.FontColor = XLColor.Red;

                var row2 = relatorioItens.Row(2);
                row2.Style.Fill.BackgroundColor = XLColor.FromArgb(0, 176, 240);
                row2.Style.Font.FontColor = XLColor.Yellow;

                var row3 = relatorioItens.Row(2);
                row1.Style.Fill.BackgroundColor = XLColor.Red;
                row1.Style.Font.FontColor = XLColor.Yellow;

                var range3 = relatorioItens.Range("A1:F100");
                range3.Style.Font.FontSize = 16;


                /*--------------------------------------------------------------------------------------*/

                workbook.SaveAs(saveFile.FileName.ToString() + ".xlsx");

                Cursor.Current = Cursors.Default;

                functions.messageBOXok("Dados Exportados com Sucesso");
            }
    }

        private double[] getTotalVendas()
        {
            string select =
            "SELECT tbl_itensvenda.ValorTotal_Item, tbl_registrovendas.TipoPagamento_Venda" +
            " FROM tbl_produto" +
            " INNER JOIN tbl_itensvenda ON tbl_itensvenda.Codigo_Produto = tbl_produto.Codigo_Produto" +
            " INNER JOIN tbl_artesao ON tbl_artesao.ID_Artesao = tbl_produto.Codigo_Artesao" +
            " INNER JOIN tbl_registrovendas ON tbl_registrovendas.Codigo_Venda = tbl_itensvenda.Codigo_Venda" +
            $" WHERE tbl_registrovendas.Data_Venda BETWEEN '{functions.configDataSql(DateTime.Now.ToShortDateString())} 00:00:00' AND '{functions.configDataSql(DateTime.Now.ToShortDateString())} 23:59:59';";

            MySqlConnection con = functions.connectionSQL();
            MySqlCommand query = new MySqlCommand(select,con);

            var leitor = query.ExecuteReader();

            double[] valorTotal = new double[6];

            int tipoPagamento = 0;

            while (leitor.Read())
            {
                tipoPagamento = Int32.Parse(leitor["TipoPagamento_Venda"].ToString());
                valorTotal[0] += Double.Parse(leitor["ValorTotal_Item"].ToString());

                switch (tipoPagamento)
                {
                    //Dinheiro
                    case 1:
                        valorTotal[1] += Double.Parse(leitor["ValorTotal_Item"].ToString());
                        break;
                    //CC
                    case 2:
                        valorTotal[2] += Double.Parse(leitor["ValorTotal_Item"].ToString());
                        break;
                    //CD
                    case 3:
                        valorTotal[3] += Double.Parse(leitor["ValorTotal_Item"].ToString());
                        break;
                    //CC + Dinheiro
                    case 4:
                        break;
                    //CD + Dinheiro
                    case 5:
                        break;
                    //CC + CD
                    case 6:
                        break;
                }
            }

            leitor.Close();
            con.Close();
            return valorTotal;
        }

        private void fecharCaixa()
        {
            if (functions.messageBOXConfirma("Deseja fechar o caixa?", "Fechando o caixa"))
            {
                configForm(false);

                exportarCaixaFinal();

                Close();
                functions.messageBOXok($"Caixa fechado com sucesso, tenha uma boa noite!");
            }
        }

        private void abrirCaixa()
        {
            if (txtDinheiroCaixa.Text != "")
            {
                functions.dinheiroCaixa = Double.Parse(txtDinheiroCaixa.Text);
                configForm(true);
                Close();       
                functions.messageBOXok($"Caixa aberto com {functions.dinheiroCaixa} reais!!!");
            }
            else
            {
                functions.messageBOXwarning("Informe a quantia inicial para iniciar o caixa!!");
            }
        }

        private void configForm(bool caixaAberto)
        {
            if (caixaAberto)
            {
                functions.caixaEstado = true;
                txtDinheiroCaixa.Text = functions.dinheiroCaixa.ToString();
                txtDinheiroCaixa.Enabled = false;
                txtDinheiroCaixa.ReadOnly = true;
                btnAbrirCaixa.Enabled = false;
                btnAbrirCaixa.BackColor = Color.LightGray;
                btnFecharCaixa.Enabled = true;
                btnFecharCaixa.BackColor = Color.Crimson;
            }
            else
            {
                functions.caixaEstado = false;
                txtDinheiroCaixa.Text = "";
                txtDinheiroCaixa.Focus();
                txtDinheiroCaixa.Enabled = true;
                txtDinheiroCaixa.ReadOnly = false;
                btnAbrirCaixa.Enabled = true;
                btnAbrirCaixa.BackColor = Color.Lime;
                btnFecharCaixa.Enabled = false;
                btnFecharCaixa.BackColor = Color.LightGray;
            }
        }

    }
}
