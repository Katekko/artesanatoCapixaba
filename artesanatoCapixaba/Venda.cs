
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace artesanatoCapixaba
{
    public partial class Venda : Form
    {

        private string valorTotal;
        private string valorRecebido1;
        private string valorRecebido2;

        public Venda()
        {
            InitializeComponent();

            fillCmbTipoProduto();
            fillCmbVendedor();

            txtCodProd.Focus();
            txtDesconto.Enabled = false;
            txtDesconto.BackColor = Color.LightGray;
            txtSegundaOpcao.ReadOnly = true;
            txtSegundaOpcao.Enabled = false;
        }

        /*  Botões e Eventos  */

        private void btnEfutarVenda_Click(object sender, EventArgs e)
        {
            if (efetuarVenda())
            {
                int codVenda = getCodVenda();

                if (addItensNaVenda(codVenda))
                {
                    List<string> codProd = getCodProd(codVenda);
                    List<int> quantProd = getQuantProd(codVenda);

                    if (functions.retirarEstoqueVenda(codProd, quantProd))
                    {
                        clearTxt();
                        functions.messageBOXok("Venda efetuada com sucesso!");
                    }
                }
            }
        }

        private void txtCodProd_Leave(object sender, EventArgs e)
        {
            if (ProdutoExist(txtCodProd))
            {
                if (ProdutoExistEstoque(txtCodProd))
                {
                    txtCodProd.Text = txtCodProd.Text.ToUpper();
                }
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            functions.KeyPressOnlyNumber(sender, e);
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            if (txtQuantidade.Text == "") { txtQuantidade.Focus(); functions.messageBOXwarning("Informe a quantidade!"); return; }

            if(checkEstoque(txtCodProd.Text, Int32.Parse(txtQuantidade.Text)))
            {
                btnAdicionarItem.Enabled = true;
                btnRetirarItem.Enabled = true;
            }                    
        }

        private void txtValorRecebido_Leave(object sender, EventArgs e)
        {
            //if (txtValorRecebido.Text == "") { txtValorRecebido.Focus(); functions.messageBOXwarning("Informe o valor recebido!"); return; }
            int indexTipo = cmbTipoPagamento.SelectedIndex;

            if (!(indexTipo >= 3 && indexTipo <= 5))
            {
                valorRecebido1 = functions.transformCurrent(txtValorRecebido);
                fillTxtTroco();
            }
            else
            {
                valorRecebido1 = functions.transformCurrent(txtValorRecebido);
                double restante = Double.Parse(valorTotal) - Double.Parse(valorRecebido1);
                txtSegundaOpcao.Text = restante.ToString();
                valorRecebido2 = functions.transformCurrent(txtSegundaOpcao);
            }
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            if(checkProdQuant())
            {
                if (addItemGrid())
                {
                    txtCodProd.Text = "";
                    txtCodProd.BackColor = Color.White;
                    txtQuantidade.BackColor = Color.White;
                    txtQuantidade.Text = "";
                    txtDesconto.Text = "";
                    chkDesconto.Checked = false;


                    fillTxtTotal();


                    if (txtValorRecebido.Text != "") fillTxtTroco();
                }
            }
        }

        private void btnRetirarItem_Click(object sender, EventArgs e)
        {
            if (functions.messageBOXConfirma("Deseja realmente excluir este Item?", "Tem certeza disso?"))
            {
                functions.removeSelectedRow(gridItemVenda);
                fillTxtTotal();

                if(txtValorRecebido.Text != "") fillTxtTroco();
            }
        }

        private void cmbTipoPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexTipo = cmbTipoPagamento.SelectedIndex;

            if (indexTipo >= 3 && indexTipo <= 5)
            {
                switch (indexTipo)
                {
                    case 3:
                        lblValorRecebido.Text = "Cartão de Crédito";
                        lblSegundaOpcao.Text = "Dinheiro";
                        break;
                    case 4:
                        lblValorRecebido.Text = "Cartão de Débito";
                        lblSegundaOpcao.Text = "Dinheiro";
                        break;
                    case 5:
                        lblValorRecebido.Text = "Cartão de Crédito";
                        lblSegundaOpcao.Text = "Cartão de Débito";
                        break;
                }              
            }
            else
            {
                lblValorRecebido.Text = "Valor Recebido";
                lblSegundaOpcao.Text = "Segunda Opção";
                txtSegundaOpcao.Text = "";
            }
        }

        private void chkDesconto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDesconto.Checked)
            {
                txtDesconto.Enabled = true;
                txtDesconto.BackColor = Color.White;
            }
            else
            {
                txtDesconto.Enabled = false;
                txtDesconto.BackColor = Color.LightGray;
            } 
        }

        /* ------------------------------------------------------------- */

        private bool checkEstoque(string codProduto, int quantidade)
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand($"SELECT Quantidade_Estoque FROM tbl_estoque WHERE Codigo_Produto = '{codProduto}'", con);
            var leitor = query.ExecuteReader();
            leitor.Read();

            int aux = Int32.Parse(leitor["Quantidade_Estoque"].ToString()) - quantidade;

            if(aux < 0)
            {
                functions.messageBOXwarning($"O estoque apresenta apenas {Int32.Parse(leitor["Quantidade_Estoque"].ToString())}! Escolha outra quantidade!!");
                txtQuantidade.Focus();
                txtQuantidade.BackColor = Color.Red;
                txtQuantidade.ForeColor = Color.Yellow;
                leitor.Close();
                con.Close();
                return false;
            }
            txtQuantidade.BackColor = Color.Chartreuse;
            txtQuantidade.ForeColor = Color.Black;
            leitor.Close();
            con.Close();
            return true;
        }

        private List<int> getQuantProd(int codigoVenda)
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand($"SELECT Quantidade_Produto FROM tbl_itensvenda WHERE Codigo_Venda = {codigoVenda}", con);
            var leitor = query.ExecuteReader();
            List<int> listaQuantProd = new List<int>();

            while (leitor.Read())
            {
                listaQuantProd.Add(Int32.Parse(leitor["Quantidade_Produto"].ToString()));
            }

            leitor.Close();
            con.Close();

            return listaQuantProd;
        }

        private List<string> getCodProd(int codigoVenda)
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand($"SELECT Codigo_Produto FROM tbl_itensvenda WHERE Codigo_Venda = {codigoVenda}", con);
            var leitor = query.ExecuteReader();
            List<string> listaCodProd = new List<string>();

            while (leitor.Read())
            {
                listaCodProd.Add(leitor["Codigo_Produto"].ToString());
            }
      
            leitor.Close();
            con.Close();

            return listaCodProd;
        }

        private int getCodVenda()
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand("SELECT TOP 1 Codigo_Venda FROM tbl_registrovendas ORDER BY Codigo_Venda DESC", con);
            var leitor = query.ExecuteReader();
            leitor.Read();
            int codigoVenda = Int32.Parse(leitor["Codigo_Venda"].ToString());
            leitor.Close();
            con.Close();  
            return codigoVenda;
        }

        private int getIndexVenda()
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand("SELECT TOP 1 Index_Venda FROM tbl_itensvenda ORDER BY Index_Venda DESC", con);
            var leitor = query.ExecuteReader();
            leitor.Read();
            int IndexVenda = Int32.Parse(leitor["Index_Venda"].ToString());
            leitor.Close();
            con.Close();
            return IndexVenda;
        }

        private bool addItensNaVenda(int codVenda)
        {

            foreach (DataGridViewRow Datarow in gridItemVenda.Rows)
            {
                if (Datarow.Cells[0].Value != null)
                {
                    string codProduto = Datarow.Cells[0].Value.ToString();

                    int codArtesão = codProduto[0];
                    
                    int quantItem = Int32.Parse(Datarow.Cells[1].Value.ToString());
                    double valorNovoItem = Double.Parse(Datarow.Cells[2].Value.ToString());
                    double descontoItem = Double.Parse(Datarow.Cells[3].Value.ToString().Replace('%',' '));
                    double valorAntigoItem = Double.Parse(Datarow.Cells[4].Value.ToString());

                    double valorArtesao;
                    double valorLoja;

                    //desconto ativo o valor do artesao vai em cima do valor do desconto e o nosso valor continua o mesmo
                    if (descontoItem != 0)
                    {
                        valorLoja = valorNovoItem * 0.3;
                        valorArtesao = valorNovoItem * 0.7;
                    }
                    else
                    {
                        valorLoja = valorNovoItem * 0.3;
                        valorArtesao = valorNovoItem * 0.7;
                    }

                    getCodVenda();
                    functions.updateChangeDeleteDatabase($"INSERT INTO tbl_itensvenda (Index_Venda, Codigo_Venda, Codigo_Produto, Quantidade_Produto, ValorTotal_Item, ValorArtesao_Item, ValorLoja_Item, Desconto_Item) VALUES ({getIndexVenda() + 1}, {codVenda}, '{codProduto}', {quantItem}, '{valorNovoItem}', {valorArtesao.ToString().Replace(',', '.')}, {valorLoja.ToString().Replace(',','.')}, {descontoItem.ToString().Replace(',', '.')})");
                }
            }

            return true;
        }

        private bool addItemGrid()
        {
            string codProduto = txtCodProd.Text;
            int quantProduto = Int32.Parse(txtQuantidade.Text);
            double valorAntigoItem = getTotalValor();
            double valorNovoItem;
            double valorDesconto;

            Double.TryParse(txtDesconto.Text, out valorDesconto);

            if (chkDesconto.Checked == true)
            {
                if (txtDesconto.Text != "")
                {
                    //com desconto
                    valorNovoItem = (valorAntigoItem - (valorAntigoItem * (Double.Parse(txtDesconto.Text) / 100)));
                    return fillGridItens(codProduto, quantProduto, valorNovoItem, valorAntigoItem, valorDesconto);
                }
                else
                {
                    functions.messageBOXwarning("Coloque um valor para o desconto ou desabilite-o!");
                    return false;
                }
            }
            else
            { 
                //sem desconto
                valorNovoItem = valorAntigoItem;
                return fillGridItens(codProduto, quantProduto, valorNovoItem, valorAntigoItem);
            }
        }

        private bool fillGridItens(string codProduto, int quantProduto, double valorNovoItem, double valorAntigoItem, double descontoItem = 0)
        {
            try
            {
                if(descontoItem == 0)
                {
                    gridItemVenda.Rows.Add(codProduto, quantProduto, valorNovoItem, descontoItem + "%", valorAntigoItem);
                }
                else
                {
                    gridItemVenda.Columns[4].Visible = false;
                    gridItemVenda.Rows.Add(codProduto, quantProduto, valorNovoItem, descontoItem + "%", valorAntigoItem);
                }
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        private double getTotalValor()
        {
            SqlConnection con = functions.connectionSQL();

            SqlCommand query = new SqlCommand($"SELECT * FROM tbl_produto WHERE Codigo_Produto = '{txtCodProd.Text}'", con);

            var leitor = query.ExecuteReader();

            Double precoUnitario = 0;

            while (leitor.Read())
            {
                precoUnitario = Double.Parse(leitor["Preco_Produto"].ToString());
            }
            leitor.Close();
            con.Close();

            return (precoUnitario * Int32.Parse(txtQuantidade.Text));
        }

        private bool checkProdQuant()
        {
            if(txtCodProd.Text == "")
            {
                functions.messageBOXwarning("Preencha o Codigo do Produto!");
                return false;
            }
            if (txtQuantidade.Text == "")
            {
                functions.messageBOXwarning("Preencha o Quantidade de Itens!");
                return false;
            }
            return true;

        }

        private void clearTxt()
        {
            txtCodProd.Clear();
            txtCodProd.Focus();
            txtCodProd.BackColor = Color.White;
            txtQuantidade.Clear();
            txtTotal.Clear();
            txtTroco.Clear();
            txtValorRecebido.Clear();
            gridItemVenda.Rows.Clear();
            gridItemVenda.Refresh();
            txtSegundaOpcao.Clear();
            cmbTipoPagamento.SelectedIndex = -1;
            cmbVendedor.SelectedIndex = -1;
        }

        private void fillTxtTroco()
        {
            if (valorRecebido1 != null && valorTotal != null)
            {
                double troco = Double.Parse(valorRecebido1) - Double.Parse(valorTotal);

                txtTroco.Text = troco.ToString();

                functions.transformCurrent(txtTroco);
            }
        }

        private void fillCmbTipoProduto()
        {
            functions.fillCmb("SELECT Nome_TipoPagamento FROM tbl_tipopagamento", "Nome_TipoPagamento", cmbTipoPagamento);
        }

        private void fillTxtTotal()
        {
            double valorTotal = 0;

            foreach (DataGridViewRow Datarow in gridItemVenda.Rows)
            {
                if (Datarow.Cells[2].Value != null)
                {
                    valorTotal += Double.Parse(Datarow.Cells[2].Value.ToString());
                }
            }

            txtTotal.Text = valorTotal.ToString();
            this.valorTotal = functions.transformCurrent(txtTotal);
        }

        private bool ProdutoExist(TextBox txtbox)
        {
            SqlConnection con = functions.connectionSQL();

            SqlCommand query = new SqlCommand($"SELECT * FROM tbl_produto WHERE Codigo_Produto = '{txtbox.Text}'", con);

            var leitor = query.ExecuteReader();

            if (!leitor.HasRows)
            {
                functions.messageBOXwarning("Codigo do produto Inexistente!");
                txtbox.Focus();
                txtbox.Clear();
                leitor.Close();
                con.Close();
                return false;
            }

            leitor.Close();
            con.Close();
            return true;
        }

        private bool ProdutoExistEstoque(TextBox txtbox)
        {
            SqlConnection con = functions.connectionSQL();

            SqlCommand query = new SqlCommand($"SELECT * FROM tbl_estoque WHERE Codigo_Produto = '{txtbox.Text}'", con);

            var leitor = query.ExecuteReader();

            if (!leitor.HasRows)
            {
                functions.messageBOXwarning("Este produto está em falta no estoque!");
                txtbox.Focus();
                txtbox.Clear();
                leitor.Close();
                con.Close();
                return false;
            }

            txtbox.BackColor = Color.Chartreuse;
            leitor.Close();
            con.Close();
            return true;
        }

        private bool efetuarVenda()
        {
            if (checkTxt())
            {
                int codigoVendedor = getIdVendedor(cmbVendedor.GetItemText(cmbVendedor.SelectedItem));
                int tipoPagamento = getTipoPagamento(cmbTipoPagamento.GetItemText(cmbTipoPagamento.SelectedItem));
                string data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                double valorPrimeiraOpcao;

                int indexTipo = cmbTipoPagamento.SelectedIndex;

                if (!(indexTipo >= 3 && indexTipo <= 5))
                {
                    valorPrimeiraOpcao = Double.Parse(valorRecebido1) - (Double.Parse(valorRecebido1) - Double.Parse(valorTotal));
                }
                else
                {
                    valorPrimeiraOpcao = Double.Parse(valorRecebido1);
                }

                double valorSegundaOpcao;

                Double.TryParse(valorRecebido2, out valorSegundaOpcao);

                 int codVendaAnterior = getCodVenda();

                switch (tipoPagamento)
                {
                    case 4:
                    case 5:
                    case 6:
                        if (insertRegistroVendas(codVendaAnterior + 1,codigoVendedor, valorTotal.ToString().Replace(',', '.'), tipoPagamento, data, valorPrimeiraOpcao.ToString().Replace(',', '.'), valorSegundaOpcao.ToString().Replace(',', '.')))
                        {
                            valorTotal = "";
                            valorRecebido1 = "";
                            valorRecebido2 = "";
                            return true;
                        }
                        break;
                    default:
                        if (insertRegistroVendas(codVendaAnterior + 1, codigoVendedor, valorTotal.ToString().Replace(',', '.'), tipoPagamento, data, valorPrimeiraOpcao.ToString().Replace(',', '.')))
                        {
                            valorTotal = "";
                            valorRecebido1 = "";
                            valorRecebido2 = "";
                            return true;
                        }
                        break;
                }

                return false;
            }

            return false;
        }

        private bool checkTxt()
        {
            if (txtTotal.Text == "" || txtTotal == null)
            {
                functions.messageBOXwarning("Adicione algum produto para vender!");
                return false;
            }

            if (txtValorRecebido.Text == "" || txtValorRecebido == null)
            {
                functions.messageBOXwarning("Preencha o valor recebido!");
                txtValorRecebido.Focus();
                return false;
            }

            if (cmbTipoPagamento.GetItemText(cmbVendedor.SelectedItem) == "" || cmbTipoPagamento.GetItemText(cmbVendedor.SelectedItem) == null)
            {
                functions.messageBOXwarning("Defina um tipo de pagamento para esta venda!");
                cmbTipoPagamento.Focus();
                return false;
            }

            if (cmbVendedor.GetItemText(cmbVendedor.SelectedItem) == "" || cmbVendedor.GetItemText(cmbVendedor.SelectedItem) == null)
            {
                functions.messageBOXwarning("Defina um vendedor para esta venda!");
                cmbVendedor.Focus();
                return false;
            }
            return true;
        }

        private bool insertRegistroVendas(int codigoVenda,int codigoVendedor, string valorArrecadado, int tipoPagamento, string dataVenda, string valorPrimeiraOpcao, string valorSegundaOpcao = "0")
        {
            if(functions.updateChangeDeleteDatabase($"INSERT INTO tbl_registrovendas  (Codigo_Venda, Codigo_Vendedor, Codigo_ResponsavelCaixa, ValorArrecadado_Venda, TipoPagamento_Venda, Data_Venda, ValorPrimeiroTipo_Venda, ValorSegundoTipo_Venda) VALUES ({codigoVenda}, {codigoVendedor}, {functions.getIDusuarioAtual()}, '{valorArrecadado}',  {tipoPagamento},  '{dataVenda}', {valorPrimeiraOpcao}, {valorSegundaOpcao})"))
            {
                return true;
            }
            return false;
        }

        private int getTipoPagamento(string tipoPagamento)
        {
            switch (tipoPagamento)
            {
                case "Dinheiro":
                    return 1;
                case "Cartão de Credito":
                    return 2;
                case "Cartão de Debito":
                    return 3;
                case "CC + Dinheiro":
                    return 4;
                case "CD + Dinheiro":
                    return 5;
                case "CC + CD":
                    return 6;
                default:
                    return 0;
            }
        }

        private int getIdVendedor(string NomeVendedor)
        {
            SqlConnection con = functions.connectionSQL();

            SqlCommand query = new SqlCommand($"SELECT Codigo_Vendedor FROM tbl_vendedor WHERE Nome_Vendedor = '{NomeVendedor}'", con);

            int codVendedor = 0;

            var leitor = query.ExecuteReader();

            while (leitor.Read())
            {
                codVendedor = Int32.Parse(leitor["Codigo_Vendedor"].ToString());
            }

            con.Close();

            return codVendedor;
        }

        private void fillCmbVendedor()
        {
            functions.fillCmb("SELECT Nome_Vendedor FROM tbl_vendedor", "Nome_Vendedor", cmbVendedor);
        }

    }
}
