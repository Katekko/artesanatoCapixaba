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

        private void exportarRelatorio()
        {

        }


        private void fecharCaixa()
        {
            if (functions.messageBOXConfirma("Deseja fechar o caixa?", "Fechando o caixa"))
            {
                configForm(false);
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
