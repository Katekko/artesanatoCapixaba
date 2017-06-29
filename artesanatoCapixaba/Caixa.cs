using ClosedXML.Excel;
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
                var ws = workbook.Worksheets.Add("Relatorio de Caixa");

                var col1 = ws.Column("A");
                col1.Width = 28;

                var col2 = ws.Column("B");
                col2.Width = 25;

                var range1 = ws.Range("A1:F100");
                range1.Style.Font.FontSize = 16;

                var range2 = ws.Range("B3:B8");
                range2.Style.NumberFormat.Format = "R$ #,##0.00";

                ws.Cell("A1").Value = "CAIXA DO DIA";
                ws.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell("A1").Style.Font.Bold = true;
                ws.Cell("A1").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 192, 0);
                ws.Cell("A1").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("B1").Value = dataAgora;
                ws.Cell("B1").Style.Font.Bold = true;
                ws.Cell("B1").Style.Font.FontColor = XLColor.Red;
                ws.Cell("B1").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 192, 0);
                ws.Cell("B1").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("A3").Value = "1.Saldo Inicial";
                ws.Cell("A3").Style.Font.Bold = true;
                ws.Cell("A3").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws.Cell("A3").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("B3").Value = saldoInicial;
                ws.Cell("B3").Style.Font.Bold = true;
                ws.Cell("B3").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws.Cell("B3").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("A4").Value = "2.Vendas";
                ws.Cell("A4").Style.Font.Bold = true;
                ws.Cell("A4").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws.Cell("A4").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("B4").Value = totalVendas;
                ws.Cell("B4").Style.Font.Bold = true;
                ws.Cell("B4").Style.Fill.BackgroundColor = XLColor.FromArgb(189, 215, 238);
                ws.Cell("B4").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("A5").Value = "2.1.Dinheiro";
                ws.Cell("A5").Style.Font.Bold = true;
                ws.Cell("A5").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                ws.Cell("A5").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 176, 80);
                ws.Cell("A5").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("B5").Value = dinheiroVendas;
                ws.Cell("B5").Style.Font.Bold = true;
                ws.Cell("B5").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                ws.Cell("B5").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 176, 80);
                ws.Cell("B5").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("A6").Value = "2.2.Cartão de Credito";
                ws.Cell("A6").Style.Font.Bold = true;
                ws.Cell("A6").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                ws.Cell("A6").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 176, 80);
                ws.Cell("A6").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("B6").Value = cartaoCreVendas;
                ws.Cell("B6").Style.Font.Bold = true;
                ws.Cell("B6").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                ws.Cell("B6").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 176, 80);
                ws.Cell("B6").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("A7").Value = "2.3.Cartão de Débito";
                ws.Cell("A7").Style.Font.Bold = true;
                ws.Cell("A7").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                ws.Cell("A7").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 176, 80);
                ws.Cell("A7").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("B7").Value = cartaoDebVendas;
                ws.Cell("B7").Style.Font.Bold = true;
                ws.Cell("B7").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                ws.Cell("B7").Style.Fill.BackgroundColor = XLColor.FromArgb(0, 176, 80);
                ws.Cell("B7").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("A8").Value = "3.Saldo Final";
                ws.Cell("A8").Style.Font.Bold = true;
                ws.Cell("A8").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                ws.Cell("A8").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 0, 0);
                ws.Cell("A8").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                ws.Cell("B8").FormulaA1 = $"=SUM(B3:B4)";
                ws.Cell("B8").Style.Font.Bold = true;
                ws.Cell("B8").Style.Font.FontColor = XLColor.FromArgb(255, 255, 0);
                ws.Cell("B8").Style.Fill.BackgroundColor = XLColor.FromArgb(255, 0, 0);
                ws.Cell("B8").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
              
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
