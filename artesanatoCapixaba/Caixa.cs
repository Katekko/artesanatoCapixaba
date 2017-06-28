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
            configForm();
        }

        private void btnAbrirCaixa_Click(object sender, EventArgs e)
        {

        }

        private void txtDinheiroCaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            functions.KeyPressOnlyNumber(sender, e);
        }

        /**********************************************************************/

        private void configForm()
        {
            bool caixaAberto = functions.caixa;

            if (caixaAberto)
            {
                txtDinheiroCaixa.Enabled = false;
                txtDinheiroCaixa.ReadOnly = true;
                btnAbrirCaixa.Enabled = false;
                btnAbrirCaixa.BackColor = Color.LightGray;
                btnFecharCaixa.Enabled = true;
                btnFecharCaixa.BackColor = Color.Crimson;
            }
            else
            {
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
