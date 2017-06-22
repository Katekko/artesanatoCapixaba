namespace artesanatoCapixaba
{
    partial class cadastroEstoque
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
            this.boxAdicionarEs = new System.Windows.Forms.GroupBox();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.txtQuant = new System.Windows.Forms.TextBox();
            this.btnAdicionarEstoque = new System.Windows.Forms.Button();
            this.lblQuant = new System.Windows.Forms.Label();
            this.txtCodProduto = new System.Windows.Forms.TextBox();
            this.lblCodProdut = new System.Windows.Forms.Label();
            this.boxAdicionarEs.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxAdicionarEs
            // 
            this.boxAdicionarEs.BackColor = System.Drawing.Color.SlateBlue;
            this.boxAdicionarEs.Controls.Add(this.btnDeletar);
            this.boxAdicionarEs.Controls.Add(this.txtQuant);
            this.boxAdicionarEs.Controls.Add(this.btnAdicionarEstoque);
            this.boxAdicionarEs.Controls.Add(this.lblQuant);
            this.boxAdicionarEs.Controls.Add(this.txtCodProduto);
            this.boxAdicionarEs.Controls.Add(this.lblCodProdut);
            this.boxAdicionarEs.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxAdicionarEs.Location = new System.Drawing.Point(12, 4);
            this.boxAdicionarEs.Name = "boxAdicionarEs";
            this.boxAdicionarEs.Size = new System.Drawing.Size(204, 246);
            this.boxAdicionarEs.TabIndex = 4;
            this.boxAdicionarEs.TabStop = false;
            this.boxAdicionarEs.Text = "Adicionar Estoque";
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeletar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletar.Enabled = false;
            this.btnDeletar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletar.Location = new System.Drawing.Point(13, 197);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(174, 31);
            this.btnDeletar.TabIndex = 4;
            this.btnDeletar.Text = "R E T I R A R";
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // txtQuant
            // 
            this.txtQuant.Location = new System.Drawing.Point(13, 109);
            this.txtQuant.Name = "txtQuant";
            this.txtQuant.Size = new System.Drawing.Size(174, 26);
            this.txtQuant.TabIndex = 2;
            this.txtQuant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuant_KeyPress);
            // 
            // btnAdicionarEstoque
            // 
            this.btnAdicionarEstoque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAdicionarEstoque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarEstoque.Location = new System.Drawing.Point(13, 151);
            this.btnAdicionarEstoque.Name = "btnAdicionarEstoque";
            this.btnAdicionarEstoque.Size = new System.Drawing.Size(174, 31);
            this.btnAdicionarEstoque.TabIndex = 3;
            this.btnAdicionarEstoque.Text = "A D I C I O N A R";
            this.btnAdicionarEstoque.UseVisualStyleBackColor = false;
            this.btnAdicionarEstoque.Click += new System.EventHandler(this.btnAdicionarEstoque_Click);
            // 
            // lblQuant
            // 
            this.lblQuant.AutoSize = true;
            this.lblQuant.Location = new System.Drawing.Point(9, 87);
            this.lblQuant.Name = "lblQuant";
            this.lblQuant.Size = new System.Drawing.Size(108, 19);
            this.lblQuant.TabIndex = 9;
            this.lblQuant.Text = "Quantidade:";
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.Location = new System.Drawing.Point(13, 49);
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.Size = new System.Drawing.Size(174, 26);
            this.txtCodProduto.TabIndex = 1;
            this.txtCodProduto.TextChanged += new System.EventHandler(this.txtCodProduto_TextChanged);
            this.txtCodProduto.Leave += new System.EventHandler(this.txtCodProduto_Leave);
            // 
            // lblCodProdut
            // 
            this.lblCodProdut.AutoSize = true;
            this.lblCodProdut.Location = new System.Drawing.Point(9, 23);
            this.lblCodProdut.Name = "lblCodProdut";
            this.lblCodProdut.Size = new System.Drawing.Size(161, 19);
            this.lblCodProdut.TabIndex = 0;
            this.lblCodProdut.Text = "Codigo do Produto:";
            // 
            // cadastroEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(228, 262);
            this.Controls.Add(this.boxAdicionarEs);
            this.Name = "cadastroEstoque";
            this.Text = "cadastroEstoque";
            this.boxAdicionarEs.ResumeLayout(false);
            this.boxAdicionarEs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxAdicionarEs;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.TextBox txtQuant;
        private System.Windows.Forms.Button btnAdicionarEstoque;
        private System.Windows.Forms.Label lblQuant;
        private System.Windows.Forms.TextBox txtCodProduto;
        private System.Windows.Forms.Label lblCodProdut;
    }
}