using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace artesanatoCapixaba
{
    public partial class Venda : Form
    {

        private string valorTotal;
        private string valorRecebido1;
        private string valorRecebido;

        public Venda()
        {
            InitializeComponent();

            fillCmbTipoProduto();
            fillCmbVendedor();

            txtCodProd.Focus();
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

            if (txtSegundaOpcao.Enabled == false)
            {
                valorRecebido = functions.transformCurrent(txtValorRecebido);
                fillTxtTroco();
            }
            else
            {
                valorRecebido1 = functions.transformCurrent(txtValorRecebido);
            }
        }

        private void txtSegundaOpcao_Leave(object sender, EventArgs e)
        {
            if (txtSegundaOpcao.Text == "") { txtSegundaOpcao.Focus(); functions.messageBOXwarning("Informe o valor recebido!"); return; }
            valorRecebido = functions.transformCurrent(txtSegundaOpcao, (Double.Parse(valorRecebido1) + Double.Parse(txtSegundaOpcao.Text)).ToString());
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
                txtSegundaOpcao.Enabled = true;
                txtSegundaOpcao.BackColor = Color.White;

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
                txtSegundaOpcao.Enabled = false;
                txtSegundaOpcao.BackColor = Color.LightGray;
                lblValorRecebido.Text = "Valor Recebido";
                lblSegundaOpcao.Text = "Segunda Opção";
            }
        }

        /* ------------------------------------------------------------- */

        private bool checkEstoque(string codProduto, int quantidade)
        {
            MySqlConnection con = functions.connectionSQL();
            MySqlCommand query = new MySqlCommand($"SELECT Quantidade_Estoque FROM tbl_estoque WHERE Codigo_Produto = '{codProduto}'", con);
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
            MySqlConnection con = functions.connectionSQL();
            MySqlCommand query = new MySqlCommand($"SELECT Quantidade_Produto FROM tbl_itensvenda WHERE Codigo_Venda = {codigoVenda}", con);
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
            MySqlConnection con = functions.connectionSQL();
            MySqlCommand query = new MySqlCommand($"SELECT Codigo_Produto FROM tbl_itensvenda WHERE Codigo_Venda = {codigoVenda}", con);
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
            MySqlConnection con = functions.connectionSQL();
            MySqlCommand query = new MySqlCommand("SELECT Codigo_Venda FROM tbl_registrovendas ORDER BY Codigo_Venda DESC LIMIT 1", con);
            var leitor = query.ExecuteReader();
            leitor.Read();
            int codigoVenda = Int32.Parse(leitor["Codigo_Venda"].ToString());
            leitor.Close();
            con.Close();  
            return codigoVenda;
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
                    double valorItem = Double.Parse(Datarow.Cells[2].Value.ToString());
                    double valorArtesao = valorItem * 0.7;
                    double valorLoja = valorItem * 0.3;

                    functions.updateChangeDeleteDatabase($"INSERT INTO tbl_itensvenda VALUES({codVenda}, '{codProduto}', {quantItem}, '{valorItem}', '{valorArtesao}', '{valorLoja}')");
                }
            }

            return true;
        }

        private bool addItemGrid()
        {
            string codProduto = txtCodProd.Text;
            int quantProduto = Int32.Parse(txtQuantidade.Text);
            double valorItem = getTotalValor();

            return fillGridItens(codProduto, quantProduto, valorItem);
        }

        private bool fillGridItens(string codProduto, int quantProduto, double valorItem)
        {
            try
            {
                gridItemVenda.Rows.Add(codProduto, quantProduto, valorItem);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private double getTotalValor()
        {
            MySqlConnection con = functions.connectionSQL();

            MySqlCommand query = new MySqlCommand($"SELECT * FROM tbl_produto WHERE Codigo_Produto = '{txtCodProd.Text}'", con);

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
            if (valorRecebido != null && valorTotal != null)
            {
                double troco = Double.Parse(valorRecebido) - Double.Parse(valorTotal);

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
            MySqlConnection con = functions.connectionSQL();

            MySqlCommand query = new MySqlCommand($"SELECT * FROM tbl_produto WHERE Codigo_Produto = '{txtbox.Text}'", con);

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
            MySqlConnection con = functions.connectionSQL();

            MySqlCommand query = new MySqlCommand($"SELECT * FROM tbl_estoque WHERE Codigo_Produto = '{txtbox.Text}'", con);

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
                double valorArrecadado = Double.Parse(valorTotal);
                int tipoPagamento = getTipoPagamento(cmbTipoPagamento.GetItemText(cmbTipoPagamento.SelectedItem));
                string data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
    
                if(insertRegistroVendas(codigoVendedor, valorArrecadado.ToString().Replace(',','.'), tipoPagamento, data))
                {
                    return true;
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

        private bool insertRegistroVendas(int codigoVendedor, string valorArrecadado, int tipoPagamento, string dataVenda)
        {
            if(functions.updateChangeDeleteDatabase($"INSERT INTO tbl_registrovendas  ( Codigo_Vendedor, Codigo_ResponsavelCaixa, ValorArrecadado_Venda, TipoPagamento_Venda, Data_Venda) VALUES ( {codigoVendedor}, {functions.getIDusuarioAtual()}, '{valorArrecadado}',  {tipoPagamento},  '{dataVenda}')"))
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
                case "Outros":
                    return 4;
                default:
                    return 0;
            }
        }

        private int getIdVendedor(string NomeVendedor)
        {
            MySqlConnection con = functions.connectionSQL();

            MySqlCommand query = new MySqlCommand($"SELECT Codigo_Vendedor FROM tbl_vendedor WHERE Nome_Vendedor = '{NomeVendedor}'", con);

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
