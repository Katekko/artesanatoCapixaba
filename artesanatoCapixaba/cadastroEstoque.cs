
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
    public partial class cadastroEstoque : Form
    {

        private Produto formProduto;

        public cadastroEstoque(Produto form2 = null)
        {
            InitializeComponent();
           
            if(form2 != null)
            {
                formProduto = form2;
                txtCodProduto.Text = form2.getIdProdutGrid();
                txtCodProduto.Enabled = false;
            }
        }

        /*  Botões e Eventos  */

        private void btnAdicionarEstoque_Click(object sender, EventArgs e)
        {
            if (checkTxt())
            {
                if (updateEstoque())
                {
                    Close();
                }           
            }
        }

        private void txtCodProduto_Leave(object sender, EventArgs e)
        {
            txtCodProduto.Text = txtCodProduto.Text.ToUpper();
            checkCodProdutoExistAndIsFirst(txtCodProduto);
        }

        private void txtQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            functions.KeyPressOnlyNumber(sender, e);
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            string codProduto = txtCodProduto.Text;

            if (functions.messageBOXConfirma($"Tem certeza que deseja  R E T I R A R  {txtQuant.Text} do estoque?", "Adicionando no Estoque"))
            {

                int newQuant = functions.getNewValueToQuant(2, Int32.Parse(txtQuant.Text), txtCodProduto.Text);

                changeEstoqueDatabase($"UPDATE tbl_estoque SET Quantidade_Estoque = {newQuant} WHERE Codigo_Produto = '{codProduto}'");
            } 
        }

        private void txtCodProduto_TextChanged(object sender, EventArgs e)
        {
            if (formProduto != null)
            {
                checkCodProdutoExistAndIsFirst(txtCodProduto);
            }
        }

        /* ------------------------------------------------------------- */

        private bool updateEstoque()
        {
            string codProduto = txtCodProduto.Text;
            int quantidade = Int32.Parse(txtQuant.Text);

            //modo normal
            if (!btnDeletar.Enabled == true)
            {
                changeEstoqueDatabase($"INSERT INTO tbl_estoque VALUES ('{codProduto}', {quantidade})");

                return true;
            }
            //modo editar
            else
            {
                if (functions.messageBOXConfirma($"Tem certeza que deseja  A D C I O N A R  mais {txtQuant.Text} no estoque?", "Adicionando no Estoque"))
                {
                    int newQuant = functions.getNewValueToQuant(1, Int32.Parse(txtQuant.Text), txtCodProduto.Text);

                    changeEstoqueDatabase($"UPDATE tbl_estoque SET Quantidade_Estoque = {newQuant} WHERE Codigo_Produto = '{codProduto}'");

                    return true;
                }
            }
            return false;
        }

        private bool changeEstoqueDatabase(string select)
        {
            SqlConnection con = functions.connectionSQL();
            SqlCommand query = new SqlCommand(select, con);

            try
            {
                query.ExecuteNonQuery();
                functions.messageBOXok("Estoque modificado com sucesso!!");
                con.Close();
                if (formProduto == null)
                {
                    clearTxt();
                }
                
                return true;
            }
            catch(Exception ex)
            {
                functions.messageBOXerror("Erro no insert :" + ex);
                con.Close();
                return false;
            }
        }

        private bool checkTxt()
        {
            if (txtQuant.Text == "" || txtQuant == null)
            {
                functions.messageBOXwarning("Preencha a quantidade!");
                txtQuant.Focus();
                return false;
            }

            return true;
        }

        private void clearTxt()
        {
            txtCodProduto.BackColor = Color.White;
            txtCodProduto.Clear();
            txtQuant.Clear();
            txtCodProduto.Focus();
        }

        private bool checkCodProdutoExistAndIsFirst(TextBox txtbox)
        {
            SqlConnection con = functions.connectionSQL();         

            SqlCommand query = new SqlCommand($"SELECT Codigo_Produto FROM tbl_produto WHERE Codigo_Produto = '{txtbox.Text}'", con);

            var leitor = query.ExecuteReader();
            
            //se o produto não existe
            if (!leitor.HasRows)
            {
                functions.messageBOXwarning("Codigo do produto inexistente!");
                txtbox.BackColor = Color.White;
                txtbox.Focus();
                txtbox.Clear();
                leitor.Close();
                con.Close();
                return false;
            }
            else
            {
                leitor.Close();
                con.Close();
            }
            

            SqlConnection con2 = functions.connectionSQL();
            SqlCommand query2 = new SqlCommand($"SELECT Codigo_Produto FROM tbl_estoque WHERE Codigo_Produto = '{txtbox.Text}'", con2);
            var leitor2 = query2.ExecuteReader();

            //se o produto já existe no estoque
            if (leitor2.HasRows)
            {
                leitor.Close();

                if (formProduto == null)
                {
                    txtbox.BackColor = Color.Orange;
                    functions.messageBOXwarning("Clique no VERDE para ADICIONAR a quantidade e no VERMELHO para RETIRAR a quantidade!");
                }

                btnDeletar.Enabled = true;

                leitor2.Close();
                con2.Close();
                return true;
            }
            else
            {

                btnDeletar.Enabled = false;

                leitor2.Close();
                con2.Close();
            }

            txtbox.BackColor = Color.Chartreuse;
            return true;
        }

        private void deletarItemDoEstoque(string codProd)
        {
            functions.updateChangeDeleteDatabase($"DELETE FROM tbl_estoque WHERE Codigo_Produto = '{codProd}'");
        }

    }
}
