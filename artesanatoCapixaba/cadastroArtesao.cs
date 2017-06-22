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
    public partial class cadastroArtesao : Form 
    {

        private static Artesao formArtesaoEditar = null;

        public cadastroArtesao(Artesao form = null)
        {
            InitializeComponent();
           
            if(form != null)
            {
                formArtesaoEditar = form;

                configFormAtualizarArtesao();
            }

        }

        private void btnCriarArtesao_Click(object sender, EventArgs e)
        {
            string cod = txtCod.Text.ToString();
            string nome = txtNome.Text.ToString();
            string CPF = txtCpf.Text.ToString();
            string municipio = txtMunicipio.Text.ToString();
            string nunSICAB = txtNunSICAB.Text.ToString();
            string materiaPrima = txtMatPrima.Text.ToString();
            //DateTime dataNasc = functions.setTxtBoxToDate(txtDataNascimento);
            string tecnica = txtTecnica.Text.ToString();

            if (formArtesaoEditar == null)
            {
                insertCadArtesao(cod, nome, CPF, municipio, nunSICAB, materiaPrima, tecnica);
            }
            else
            {
                updateCadArtesao(cod, nome, CPF, municipio, nunSICAB, materiaPrima, tecnica);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            clearTxt();
        }

        private void KeyPressOnlyNumber(object sender, KeyPressEventArgs e)
        {
            functions.KeyPressOnlyNumber(sender, e);
        }

        private void txtCod_LostFocus(object sender, System.EventArgs e)
        {
            if(checkExistInDB(txtCod.Text.ToString(), "", "")) txtCod.Focus();
        }

        private void txtCPF_LostFocus(object sender, System.EventArgs e)
        {
            if (formArtesaoEditar == null)
            {
                if (checkExistInDB("", txtCpf.Text.ToString(), "")) txtCpf.Focus();
            }
            else
            {
                if (checkExistInDB(txtCod.Text.ToString(), txtCpf.Text.ToString(), "")) txtCpf.Focus();
            }
        }

        private void txtNumSICAB_LostFocus(object sender, System.EventArgs e)
        {
            if (formArtesaoEditar == null)
            {
                if (checkExistInDB("", "", txtNunSICAB.Text.ToString())) txtNunSICAB.Focus();
            }
            else
            {
                if (checkExistInDB(txtCod.Text.ToString(), "", txtNunSICAB.Text.ToString())) txtNunSICAB.Focus();
            }         
        }

        private void cadastroArtesao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formArtesaoEditar != null)
            {
                formArtesaoEditar.atualizarGridArtesao("SELECT * FROM tbl_artesao");
            }
        }

        /***********************************************************************/

        public void configFormAtualizarArtesao()
        {
            btnLimpar.Enabled = false;
            txtCod.Enabled = false;
            boxInfo.Text = "EDITANDO AS INFORMAÇÕES";
            btnCriarArtesao.Text = "ATUALIZAR ARTESÃO";
            string[] info = formArtesaoEditar.getArrayInfo();

            txtCod.Text = info[0];
            txtNome.Text = info[1];
            txtCpf.Text = info[2];
            txtMunicipio.Text = info[3];
            txtNunSICAB.Text = info[4];
            txtMatPrima.Text = info[5];
            txtTecnica.Text = info[6];
        }

        public static bool checkExistInDB(string ID_Artesao, string CPF_Artesao, string NunSICAB_Artesao)
        {
            MySqlConnection con = functions.connectionSQL();
            MySqlCommand query;

            if (formArtesaoEditar == null)
            {
                query = new MySqlCommand($"SELECT ID_Artesao, CPF_Artesao, NunSICAB_Artesao FROM tbl_artesao WHERE ID_Artesao = '{ID_Artesao}' OR CPF_Artesao = '{CPF_Artesao}' OR NunSICAB_Artesao = '{NunSICAB_Artesao}'", con);
            }
            else
            {
                query = new MySqlCommand($"SELECT ID_Artesao, CPF_Artesao, NunSICAB_Artesao FROM tbl_artesao WHERE (CPF_Artesao = '{CPF_Artesao}' OR NunSICAB_Artesao = '{NunSICAB_Artesao}') AND ID_Artesao != '{ID_Artesao}' ", con);
            }

            var leitor = query.ExecuteReader();

            if (leitor.HasRows)
            {
                if (ID_Artesao != "")
                {
                    functions.messageBOXwarning("Codigo do artesão já cadastrado! Escolha outro.");

                    leitor.Close();
                    con.Close();

                    return true;
                }
                else if (CPF_Artesao != "")
                {
                    functions.messageBOXwarning("CPF já cadastrado! Escolha outro.");

                    leitor.Close();
                    con.Close();

                    return true;
                }
                else if (NunSICAB_Artesao != "")
                {
                    functions.messageBOXwarning("Numero SICAB já cadastrado! Escolha outro.");

                    leitor.Close();
                    con.Close();

                    return true;
                }
            }

            leitor.Close();
            con.Close();

            return false;
        }

        private void clearTxt()
        {
            txtCod.Clear();
            txtNome.Clear();
            txtCpf.Clear();
            txtMunicipio.Clear();
            txtNunSICAB.Clear();
            txtMatPrima.Clear();
            txtDataNascimento.Clear();
            txtTecnica.Clear();
            txtCod.Focus();
        }

        private void insertCadArtesao(string cod, string nome, string CPF, string municipio, string nunSICAB, string materiaPrima, string tecnica)
        {
            if (functions.updateChangeDeleteDatabase($"INSERT INTO tbl_artesao (ID_Artesao, Nome_Artesao, CPF_Artesao, Municipio_Artesao, NunSICAB_Artesao, MateriaPrima_Artesao, Tecnica_Artesao) VALUES( {cod}, '{nome}', {CPF}, '{municipio}', {nunSICAB}, '{materiaPrima}', '{tecnica}' )"))
            {
                clearTxt();
                functions.messageBOXok($"Artesão Criado com sucesso!!!!");
            }

        }

        private void updateCadArtesao(string cod, string nome, string CPF, string municipio, string nunSICAB, string materiaPrima, string tecnica)
        {
            if(functions.updateChangeDeleteDatabase($"UPDATE tbl_artesao SET Nome_Artesao = '{nome}', CPF_Artesao = {CPF}, Municipio_Artesao = '{municipio}', NunSICAB_Artesao = {nunSICAB}, MateriaPrima_Artesao = '{materiaPrima}', Tecnica_Artesao = '{tecnica}'  WHERE ID_Artesao = {cod};"))
            {
                functions.messageBOXok($"Artesão Atualizado com sucesso!!!!");
                formArtesaoEditar = null;
                Close();
            }
        }


    }
}
