namespace artesanatoCapixaba
{
    partial class cadastroTipoProduto
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
            this.boxInfo = new System.Windows.Forms.GroupBox();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.boxProduto = new System.Windows.Forms.GroupBox();
            this.gridTipoDeProduto = new System.Windows.Forms.DataGridView();
            this.txtSigla = new System.Windows.Forms.TextBox();
            this.btnCriarTipoDeProduto = new System.Windows.Forms.Button();
            this.lblSigla = new System.Windows.Forms.Label();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.lblTProduto = new System.Windows.Forms.Label();
            this.boxInfo.SuspendLayout();
            this.boxProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTipoDeProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // boxInfo
            // 
            this.boxInfo.BackColor = System.Drawing.Color.Snow;
            this.boxInfo.Controls.Add(this.btnDeletar);
            this.boxInfo.Controls.Add(this.boxProduto);
            this.boxInfo.Controls.Add(this.txtSigla);
            this.boxInfo.Controls.Add(this.btnCriarTipoDeProduto);
            this.boxInfo.Controls.Add(this.lblSigla);
            this.boxInfo.Controls.Add(this.txtProduto);
            this.boxInfo.Controls.Add(this.lblTProduto);
            this.boxInfo.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxInfo.Location = new System.Drawing.Point(12, 12);
            this.boxInfo.Name = "boxInfo";
            this.boxInfo.Size = new System.Drawing.Size(540, 246);
            this.boxInfo.TabIndex = 1;
            this.boxInfo.TabStop = false;
            this.boxInfo.Text = "Cadastro de Tipo do Produto";
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeletar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletar.Location = new System.Drawing.Point(13, 200);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(174, 31);
            this.btnDeletar.TabIndex = 4;
            this.btnDeletar.Text = "D E L E T A R";
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // boxProduto
            // 
            this.boxProduto.Controls.Add(this.gridTipoDeProduto);
            this.boxProduto.Location = new System.Drawing.Point(215, 25);
            this.boxProduto.Name = "boxProduto";
            this.boxProduto.Size = new System.Drawing.Size(313, 205);
            this.boxProduto.TabIndex = 12;
            this.boxProduto.TabStop = false;
            this.boxProduto.Text = "Produtos";
            // 
            // gridTipoDeProduto
            // 
            this.gridTipoDeProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTipoDeProduto.Location = new System.Drawing.Point(6, 22);
            this.gridTipoDeProduto.Name = "gridTipoDeProduto";
            this.gridTipoDeProduto.Size = new System.Drawing.Size(301, 174);
            this.gridTipoDeProduto.TabIndex = 5;
            // 
            // txtSigla
            // 
            this.txtSigla.Location = new System.Drawing.Point(13, 113);
            this.txtSigla.Name = "txtSigla";
            this.txtSigla.Size = new System.Drawing.Size(174, 26);
            this.txtSigla.TabIndex = 2;
            this.txtSigla.Leave += new System.EventHandler(this.txtSigla_Leave);
            // 
            // btnCriarTipoDeProduto
            // 
            this.btnCriarTipoDeProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCriarTipoDeProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCriarTipoDeProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriarTipoDeProduto.Location = new System.Drawing.Point(13, 154);
            this.btnCriarTipoDeProduto.Name = "btnCriarTipoDeProduto";
            this.btnCriarTipoDeProduto.Size = new System.Drawing.Size(174, 31);
            this.btnCriarTipoDeProduto.TabIndex = 3;
            this.btnCriarTipoDeProduto.Text = "C R I A R";
            this.btnCriarTipoDeProduto.UseVisualStyleBackColor = false;
            this.btnCriarTipoDeProduto.Click += new System.EventHandler(this.btnCriarTipoDeProduto_Click);
            // 
            // lblSigla
            // 
            this.lblSigla.AutoSize = true;
            this.lblSigla.Location = new System.Drawing.Point(9, 91);
            this.lblSigla.Name = "lblSigla";
            this.lblSigla.Size = new System.Drawing.Size(55, 19);
            this.lblSigla.TabIndex = 9;
            this.lblSigla.Text = "Sigla:";
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(13, 51);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(174, 26);
            this.txtProduto.TabIndex = 1;
            this.txtProduto.Leave += new System.EventHandler(this.txtProduto_Leave);
            // 
            // lblTProduto
            // 
            this.lblTProduto.AutoSize = true;
            this.lblTProduto.Location = new System.Drawing.Point(9, 29);
            this.lblTProduto.Name = "lblTProduto";
            this.lblTProduto.Size = new System.Drawing.Size(140, 19);
            this.lblTProduto.TabIndex = 0;
            this.lblTProduto.Text = "Tipo do Produto:";
            // 
            // cadastroTipoProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(565, 274);
            this.Controls.Add(this.boxInfo);
            this.Name = "cadastroTipoProduto";
            this.Text = "Artesanato Capixaba - Cadastro de Tipo do Produto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.cadastroTipoProduto_FormClosed);
            this.boxInfo.ResumeLayout(false);
            this.boxInfo.PerformLayout();
            this.boxProduto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTipoDeProduto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxInfo;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.GroupBox boxProduto;
        private System.Windows.Forms.DataGridView gridTipoDeProduto;
        private System.Windows.Forms.TextBox txtSigla;
        private System.Windows.Forms.Button btnCriarTipoDeProduto;
        private System.Windows.Forms.Label lblSigla;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Label lblTProduto;
    }
}