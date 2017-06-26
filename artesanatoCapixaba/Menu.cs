using System;
using System.Windows.Forms;
using System.Data;
using ClosedXML.Excel;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace artesanatoCapixaba
{
    public partial class menuPrincipal : Form
    {

        string selectGridVendas =
            "SELECT tbl_registrovendas.Codigo_Venda, tbl_vendedor.Nome_Vendedor AS 'Nome', tbl_itensvenda.Codigo_Produto, tbl_itensvenda.Quantidade_Produto, tbl_itensvenda.ValorTotal_Item, tbl_registrovendas.Data_Venda" +
            " FROM tbl_registrovendas " +
            " INNER JOIN tbl_vendedor ON tbl_vendedor.Codigo_Vendedor = tbl_registrovendas.Codigo_Vendedor" +
            " INNER JOIN tbl_itensvenda ON tbl_itensvenda.Codigo_Venda = tbl_registrovendas.Codigo_Venda" +
            " ";

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
            fEstoque.ShowDialog();
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

                DataTable dt = new DataTable();

                foreach (DataGridViewColumn column in gridVendas.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }

                foreach (DataGridViewRow row in gridVendas.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        try
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(dt, $"Relatório de Vendas");
                    for(int i = 1; i < gridVendas.RowCount + 1; i++)
                    {
                        for(int j = 5; j< gridVendas.RowCount; j = j + 4)
                        {
                            ws.Cell(i, j).Style.NumberFormat.Format = "R$ #,##0.00";
                        }
                    }
                    
                    wb.SaveAs(saveFile.FileName.ToString());

                    Cursor.Current = Cursors.Default;

                    functions.messageBOXok("Dados exportados com sucesso!!!");
                }
            }

        }

        /****************************************************************/

        private void atualizarGridVendas(string select)
        {
            fillGridVendas(select);
            configGridVendas();
        }

        private void fillGridVendas(string select)
        {
            functions.fillGridFromSelect(select, gridVendas);
        }

        private void configGridVendas()
        {
            gridVendas.Columns[4].DefaultCellStyle.Format = "C2";

            gridVendas.Columns[0].HeaderText = "Venda";
            gridVendas.Columns[1].HeaderText = "Vendedor";
            gridVendas.Columns[2].HeaderText = "Produto";
            gridVendas.Columns[3].HeaderText = "Quant.";
            gridVendas.Columns[4].HeaderText = "Arrecadado";
            gridVendas.Columns[5].HeaderText = "Data Venda";

            //gridVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            gridVendas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridVendas.Columns[1].Width = 210;
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

            MySqlConnection con = functions.connectionSQL();
            MySqlCommand query = new MySqlCommand("SELECT ValorTotal_Item FROM tbl_itensvenda", con);
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
