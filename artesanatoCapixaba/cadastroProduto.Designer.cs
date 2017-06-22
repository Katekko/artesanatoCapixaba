namespace artesanatoCapixaba
{
    partial class cadastroProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boxContent = new System.Windows.Forms.GroupBox();
            this.btnCriarTipoDeProduto = new System.Windows.Forms.Button();
            this.boxInfo = new System.Windows.Forms.GroupBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblSigla = new System.Windows.Forms.Label();
            this.btnCriarProduto = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblTipoProduto = new System.Windows.Forms.Label();
            this.txtNunProduto = new System.Windows.Forms.TextBox();
            this.lblNumProduto = new System.Windows.Forms.Label();
            this.txtSigla = new System.Windows.Forms.TextBox();
            this.txtPreço = new System.Windows.Forms.TextBox();
            this.lblPreco = new System.Windows.Forms.Label();
            this.txtCodArt = new System.Windows.Forms.TextBox();
            this.lblCodArt = new System.Windows.Forms.Label();
            this.boxContent.SuspendLayout();
            this.boxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxContent
            // 
            this.boxContent.BackColor = System.Drawing.Color.MediumTurquoise;
            this.boxContent.Controls.Add(this.btnCriarTipoDeProduto);
            this.boxContent.Controls.Add(this.boxInfo);
            this.boxContent.Location = new System.Drawing.Point(12, 3);
            this.boxContent.Name = "boxContent";
            this.boxContent.Size = new System.Drawing.Size(608, 267);
            this.boxContent.TabIndex = 2;
            this.boxContent.TabStop = false;
            // 
            // btnCriarTipoDeProduto
            // 
            this.btnCriarTipoDeProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnCriarTipoDeProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCriarTipoDeProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriarTipoDeProduto.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriarTipoDeProduto.Location = new System.Drawing.Point(10, 12);
            this.btnCriarTipoDeProduto.Name = "btnCriarTipoDeProduto";
            this.btnCriarTipoDeProduto.Size = new System.Drawing.Size(582, 32);
            this.btnCriarTipoDeProduto.TabIndex = 8;
            this.btnCriarTipoDeProduto.Text = "C R I A R    T I P O    D E    P R O D U T O";
            this.btnCriarTipoDeProduto.UseVisualStyleBackColor = false;
            this.btnCriarTipoDeProduto.Click += new System.EventHandler(this.btnCriarTipoDeProduto_Click);
            // 
            // boxInfo
            // 
            this.boxInfo.BackColor = System.Drawing.Color.MediumTurquoise;
            this.boxInfo.Controls.Add(this.cmbTipo);
            this.boxInfo.Controls.Add(this.lblSigla);
            this.boxInfo.Controls.Add(this.btnCriarProduto);
            this.boxInfo.Controls.Add(this.btnLimpar);
            this.boxInfo.Controls.Add(this.lblTipoProduto);
            this.boxInfo.Controls.Add(this.txtNunProduto);
            this.boxInfo.Controls.Add(this.lblNumProduto);
            this.boxInfo.Controls.Add(this.txtSigla);
            this.boxInfo.Controls.Add(this.txtPreço);
            this.boxInfo.Controls.Add(this.lblPreco);
            this.boxInfo.Controls.Add(this.txtCodArt);
            this.boxInfo.Controls.Add(this.lblCodArt);
            this.boxInfo.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxInfo.Location = new System.Drawing.Point(10, 45);
            this.boxInfo.Name = "boxInfo";
            this.boxInfo.Size = new System.Drawing.Size(582, 207);
            this.boxInfo.TabIndex = 0;
            this.boxInfo.TabStop = false;
            this.boxInfo.Text = "Informações";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(126, 66);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(174, 27);
            this.cmbTipo.TabIndex = 3;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // lblSigla
            // 
            this.lblSigla.AutoSize = true;
            this.lblSigla.Location = new System.Drawing.Point(330, 70);
            this.lblSigla.Name = "lblSigla";
            this.lblSigla.Size = new System.Drawing.Size(55, 19);
            this.lblSigla.TabIndex = 17;
            this.lblSigla.Text = "Sigla:";
            // 
            // btnCriarProduto
            // 
            this.btnCriarProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCriarProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCriarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriarProduto.Location = new System.Drawing.Point(29, 149);
            this.btnCriarProduto.Name = "btnCriarProduto";
            this.btnCriarProduto.Size = new System.Drawing.Size(271, 44);
            this.btnCriarProduto.TabIndex = 5;
            this.btnCriarProduto.Text = "C R I A R  P R O D U T O";
            this.btnCriarProduto.UseVisualStyleBackColor = false;
            this.btnCriarProduto.Click += new System.EventHandler(this.btnCriarProduto_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.Red;
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpar.Location = new System.Drawing.Point(334, 149);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(230, 44);
            this.btnLimpar.TabIndex = 6;
            this.btnLimpar.Text = "L I M P A R";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // lblTipoProduto
            // 
            this.lblTipoProduto.AutoSize = true;
            this.lblTipoProduto.Location = new System.Drawing.Point(74, 70);
            this.lblTipoProduto.Name = "lblTipoProduto";
            this.lblTipoProduto.Size = new System.Drawing.Size(51, 19);
            this.lblTipoProduto.TabIndex = 9;
            this.lblTipoProduto.Text = "Tipo:";
            // 
            // txtNunProduto
            // 
            this.txtNunProduto.Location = new System.Drawing.Point(126, 108);
            this.txtNunProduto.Name = "txtNunProduto";
            this.txtNunProduto.Size = new System.Drawing.Size(174, 26);
            this.txtNunProduto.TabIndex = 4;
            this.txtNunProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNunProduto_KeyPress);
            // 
            // lblNumProduto
            // 
            this.lblNumProduto.AutoSize = true;
            this.lblNumProduto.Location = new System.Drawing.Point(25, 111);
            this.lblNumProduto.Name = "lblNumProduto";
            this.lblNumProduto.Size = new System.Drawing.Size(100, 19);
            this.lblNumProduto.TabIndex = 7;
            this.lblNumProduto.Text = "Nº Produto:";
            // 
            // txtSigla
            // 
            this.txtSigla.Enabled = false;
            this.txtSigla.Location = new System.Drawing.Point(390, 67);
            this.txtSigla.Name = "txtSigla";
            this.txtSigla.ReadOnly = true;
            this.txtSigla.Size = new System.Drawing.Size(174, 26);
            this.txtSigla.TabIndex = 5;
            // 
            // txtPreço
            // 
            this.txtPreço.Location = new System.Drawing.Point(390, 26);
            this.txtPreço.Name = "txtPreço";
            this.txtPreço.Size = new System.Drawing.Size(174, 26);
            this.txtPreço.TabIndex = 2;
            this.txtPreço.Leave += new System.EventHandler(this.txtPreço_Leave);
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new System.Drawing.Point(329, 29);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(60, 19);
            this.lblPreco.TabIndex = 3;
            this.lblPreco.Text = "Preço:";
            // 
            // txtCodArt
            // 
            this.txtCodArt.BackColor = System.Drawing.SystemColors.Window;
            this.txtCodArt.Location = new System.Drawing.Point(126, 25);
            this.txtCodArt.Name = "txtCodArt";
            this.txtCodArt.Size = new System.Drawing.Size(174, 26);
            this.txtCodArt.TabIndex = 1;
            this.txtCodArt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodArt_KeyPress);
            this.txtCodArt.Leave += new System.EventHandler(this.txtCodArt_Leave);
            // 
            // lblCodArt
            // 
            this.lblCodArt.AutoSize = true;
            this.lblCodArt.Location = new System.Drawing.Point(9, 29);
            this.lblCodArt.Name = "lblCodArt";
            this.lblCodArt.Size = new System.Drawing.Size(116, 19);
            this.lblCodArt.TabIndex = 0;
            this.lblCodArt.Text = "Cód. Artesão:";
            // 
            // cadastroProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(634, 282);
            this.Controls.Add(this.boxContent);
            this.Name = "cadastroProduto";
            this.Text = "Artesanato Capixaba - Cadastro de Produto";
            this.EnabledChanged += new System.EventHandler(this.cadastroProduto_EnabledChanged);
            this.boxContent.ResumeLayout(false);
            this.boxInfo.ResumeLayout(false);
            this.boxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxContent;
        private System.Windows.Forms.Button btnCriarTipoDeProduto;
        private System.Windows.Forms.GroupBox boxInfo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblSigla;
        private System.Windows.Forms.Button btnCriarProduto;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblTipoProduto;
        private System.Windows.Forms.TextBox txtNunProduto;
        private System.Windows.Forms.Label lblNumProduto;
        private System.Windows.Forms.TextBox txtSigla;
        private System.Windows.Forms.TextBox txtPreço;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.TextBox txtCodArt;
        private System.Windows.Forms.Label lblCodArt;
    }
}