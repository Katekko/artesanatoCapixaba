
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace artesanatoCapixaba
{
    public partial class cadastroProduto : Form
    {

        private string preco;
        public Produto formProduto;
        private string codigoFinalAntigo;

        public cadastroProduto(Produto form = null)
        {
            InitializeComponent();
            functions.configForm(this);
            fillCmbTipoProduto();

            if(form != null)
            {
                formProduto = form;
                configFormCadProd();
            }
           
        }

        /*  Botões e Eventos  */

        private void configFormCadProd()
        {
            string[] info = formProduto.getArrayInfo();
            string codigoFinal = info[2];
            codigoFinalAntigo = info[2];




            string tipoProduto = "";
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand($"SELECT * FROM tbl_produto WHERE Codigo_Produto = '{codigoFinal}'", con);

            var leitor = query.ExecuteReader();

            while (leitor.Read())
            {
                txtCodArt.Text = leitor["Codigo_Artesao"].ToString();
                txtNunProduto.Text = leitor["Numero_Produto"].ToString();
                txtSigla.Text = leitor["SiglaTipoProduto_Produto"].ToString();
                tipoProduto = leitor["TipoProduto_Produto"].ToString();
                txtPreço.Text = leitor["Preco_Produto"].ToString();
                preco = txtPreço.Text;
                Double value;
                if (Double.TryParse(txtPreço.Text, out value))
                {
                    txtPreço.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
                }
                else
                {
                    txtPreço.Text = String.Empty;
                }
                
            }
            leitor.Close();
            con.Close();

            if (cmbTipo.FindStringExact(tipoProduto) != -1)
            {
                cmbTipo.SelectedIndex = cmbTipo.FindStringExact(tipoProduto);
            }

            btnCriarProduto.Text = "ATUALIZAR PRODUTO";
            btnLimpar.Enabled = false;
            btnLimpar.BackColor = Color.Gray;
            btnCriarTipoDeProduto.Enabled = false;
            btnCriarTipoDeProduto.BackColor = Color.Gray;
        }

        private void cadastroProduto_EnabledChanged(object sender, EventArgs e)
        {
            fillCmbTipoProduto();
        }

        private void btnCriarTipoDeProduto_Click(object sender, EventArgs e)
        {
            cadastroTipoProduto fCadTipoProduto = new cadastroTipoProduto(this);

            fCadTipoProduto.ShowDialog();
        }

        private void btnCriarProduto_Click(object sender, EventArgs e)
        {
            if (checkTxt())
            {
                functions.transformCurrent(txtPreço);

                int codArtesao = Int32.Parse(txtCodArt.Text);
                string tipoProduto = cmbTipo.GetItemText(cmbTipo.SelectedItem);
                string siglaProduto = txtSigla.Text;
                int numeroProduto = Int32.Parse(txtNunProduto.Text);

                string precoProduto = preco.Replace(',', '.');
                
                string codFinal = codArtesao + siglaProduto + numeroProduto;

                
                if (formProduto == null)
                {
                    if (!checkProdutoExist(codFinal))
                    {
                        if (insertTableProdutos(codFinal, codArtesao, tipoProduto, siglaProduto, numeroProduto, precoProduto))
                        {
                            functions.messageBOXok("Produto cadastrado com sucesso!");
                            clearTxt();
                        }
                    }
                }
                else
                {
                    if (!checkProdutoExist(codFinal))
                    {
                        if (updateProdutos(codFinal, codArtesao, tipoProduto, siglaProduto, numeroProduto, precoProduto))
                        {
                            functions.messageBOXok("Produto atualizado com sucesso!");
                            Close();
                        }
                    }
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            clearTxt();
        }

        private void txtCodArt_KeyPress(object sender, KeyPressEventArgs e)
        {
            functions.KeyPressOnlyNumber(sender, e);
        }

        private void txtNunProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            functions.KeyPressOnlyNumber(sender, e);
        }

        private void txtPreço_Leave(object sender, EventArgs e)
        {
            preco = txtPreço.Text;
            functions.transformCurrent(txtPreço);
        }

        private void txtCodArt_Leave(object sender, EventArgs e)
        {
            checkArtesaoExist(txtCodArt);
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = functions.connectionSQL();

            try
            {
                SqlCommand query = new SqlCommand($"SELECT Sigla_TipoProduto FROM tbl_tipoproduto WHERE Nome_TipoProduto = '{cmbTipo.GetItemText(cmbTipo.SelectedItem)}'", con);

                SqlDataReader leitor = query.ExecuteReader();

                if(!leitor.HasRows) txtSigla.Text = "";

                while (leitor.Read())
                {
                    txtSigla.Text = leitor["Sigla_TipoProduto"].ToString();
                }
            }
            catch (Exception ex)
            {
                functions.messageBOXerror(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        /* ------------------------------------------------------------- */

        private bool checkTxt()
        {
            if(txtCodArt.Text == "" || txtCodArt == null)
            {
                functions.messageBOXwarning("Preencha o Codigo do Artesão!");
                txtCodArt.Focus();
                return false;
            }

            if (txtPreço.Text == "" || txtPreço == null)
            {
                functions.messageBOXwarning("Preencha o Preço do produto!");
                txtPreço.Focus();
                return false;
            }

            if (txtSigla.Text == "" || txtSigla == null)
            {
                functions.messageBOXwarning("Escolha o tipo do produto!");
                cmbTipo.Focus();
                return false;
            }

            if (txtNunProduto.Text == "" || txtNunProduto == null)
            {
                functions.messageBOXwarning("Preencha o Numero do Produto!");
                txtNunProduto.Focus();
                return false;
            }

            return true;
        }

        private void fillCmbTipoProduto()
        {
            functions.fillCmb("SELECT * FROM tbl_tipoproduto ORDER BY Nome_TipoProduto", "Nome_TipoProduto", cmbTipo);
        }

        private void clearTxt()
        {
            txtCodArt.Clear();
            txtNunProduto.Clear();
            txtPreço.Clear();
            txtSigla.Clear();
            txtCodArt.Focus();
            txtCodArt.BackColor = Color.White;
            cmbTipo.SelectedIndex = cmbTipo.FindStringExact("Nenhum");
        }

        private bool insertTableProdutos(string codFinal, int codArtesao, string tipoProduto, string siglaProduto, int numeroProduto, string precoProduto)
        {
        
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand($"INSERT INTO tbl_Produto (Codigo_Produto, Codigo_Artesao, SiglaTipoProduto_Produto, Numero_Produto, TipoProduto_Produto, Preco_Produto) VALUES ('{codFinal}', {codArtesao}, '{siglaProduto}', {numeroProduto}, '{tipoProduto}', '{precoProduto}')", con);

            try
            {
                query.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch(Exception ex)
            {
                functions.messageBOXerror("Erro na query: " + ex);
                con.Close();
                return false;
            }

        }

        private bool updateProdutos(string codFinal, int codArtesao, string tipoProduto, string siglaProduto, int numeroProduto, string precoProduto)
        { 
            return functions.updateChangeDeleteDatabase($"UPDATE tbl_produto SET Codigo_Produto = '{codFinal}', Codigo_Artesao = {codArtesao}, SiglaTipoProduto_Produto = '{siglaProduto}', Numero_Produto = {numeroProduto}, TipoProduto_Produto = '{tipoProduto}', Preco_Produto = '{precoProduto}'  WHERE Codigo_Produto = '{codigoFinalAntigo}'");
        }

        private bool checkArtesaoExist(TextBox txtbox)
        {
            SqlConnection con = functions.connectionSQL();

            SqlCommand query = new SqlCommand($"SELECT * FROM tbl_Artesao WHERE ID_Artesao = '{txtbox.Text}'", con);

            var leitor = query.ExecuteReader();

            if (!leitor.HasRows)
            {
                functions.messageBOXwarning("Codigo de artesão inexistente, escolha um que exista!");
                txtbox.Focus();
                txtbox.BackColor = Color.White;
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

        private bool checkProdutoExist(string codProduto)
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query;

            if (formProduto == null)
            {
                query = new SqlCommand($"SELECT * FROM tbl_Produto WHERE Codigo_Produto = '{codProduto}'", con);
            }
            else
            {
                query = new SqlCommand($"SELECT * FROM tbl_Produto WHERE Codigo_Produto = '{codProduto}' AND Codigo_Produto != '{codigoFinalAntigo}'", con);
            }

            var leitor = query.ExecuteReader();

            if (leitor.HasRows)
            {
                functions.messageBOXwarning("Este produto já está cadastrado!");
                leitor.Close();
                con.Close();
                return true;
            }

            leitor.Close();
            con.Close();
            return false;
        }



    }
}
