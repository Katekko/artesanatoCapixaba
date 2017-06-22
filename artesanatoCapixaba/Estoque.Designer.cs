namespace artesanatoCapixaba
{
    partial class Estoque
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridEstoque = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipoProduto = new System.Windows.Forms.ComboBox();
            this.btnAdicionarEstoque = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblTipoProduto = new System.Windows.Forms.Label();
            this.txtCodProd = new System.Windows.Forms.TextBox();
            this.lblCodProd = new System.Windows.Forms.Label();
            this.boxContent.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEstoque)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxContent
            // 
            this.boxContent.Controls.Add(this.groupBox2);
            this.boxContent.Controls.Add(this.groupBox1);
            this.boxContent.Location = new System.Drawing.Point(4, -2);
            this.boxContent.Name = "boxContent";
            this.boxContent.Size = new System.Drawing.Size(505, 548);
            this.boxContent.TabIndex = 2;
            this.boxContent.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridEstoque);
            this.groupBox2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 340);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estoque Atual";
            // 
            // gridEstoque
            // 
            this.gridEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEstoque.Location = new System.Drawing.Point(6, 25);
            this.gridEstoque.Name = "gridEstoque";
            this.gridEstoque.ReadOnly = true;
            this.gridEstoque.Size = new System.Drawing.Size(472, 309);
            this.gridEstoque.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipoProduto);
            this.groupBox1.Controls.Add(this.btnAdicionarEstoque);
            this.groupBox1.Controls.Add(this.btnDeletar);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.lblTipoProduto);
            this.groupBox1.Controls.Add(this.txtCodProd);
            this.groupBox1.Controls.Add(this.lblCodProd);
            this.groupBox1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 193);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // cmbTipoProduto
            // 
            this.cmbTipoProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoProduto.FormattingEnabled = true;
            this.cmbTipoProduto.Location = new System.Drawing.Point(160, 93);
            this.cmbTipoProduto.Name = "cmbTipoProduto";
            this.cmbTipoProduto.Size = new System.Drawing.Size(169, 27);
            this.cmbTipoProduto.TabIndex = 3;
            // 
            // btnAdicionarEstoque
            // 
            this.btnAdicionarEstoque.BackColor = System.Drawing.Color.SlateBlue;
            this.btnAdicionarEstoque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarEstoque.Location = new System.Drawing.Point(354, 25);
            this.btnAdicionarEstoque.Name = "btnAdicionarEstoque";
            this.btnAdicionarEstoque.Size = new System.Drawing.Size(124, 49);
            this.btnAdicionarEstoque.TabIndex = 5;
            this.btnAdicionarEstoque.Text = "ADICIONAR";
            this.btnAdicionarEstoque.UseVisualStyleBackColor = false;
            this.btnAdicionarEstoque.Click += new System.EventHandler(this.btnAdicionarEstoque_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.Red;
            this.btnDeletar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletar.Location = new System.Drawing.Point(354, 82);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(124, 49);
            this.btnDeletar.TabIndex = 7;
            this.btnDeletar.Text = "DELETAR";
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.Location = new System.Drawing.Point(7, 137);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(472, 49);
            this.btnPesquisar.TabIndex = 4;
            this.btnPesquisar.Text = "P E S Q U I S A R";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // lblTipoProduto
            // 
            this.lblTipoProduto.AutoSize = true;
            this.lblTipoProduto.Location = new System.Drawing.Point(11, 97);
            this.lblTipoProduto.Name = "lblTipoProduto";
            this.lblTipoProduto.Size = new System.Drawing.Size(140, 19);
            this.lblTipoProduto.TabIndex = 7;
            this.lblTipoProduto.Text = "Tipo do Produto:";
            // 
            // txtCodProd
            // 
            this.txtCodProd.Location = new System.Drawing.Point(160, 37);
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.Size = new System.Drawing.Size(169, 26);
            this.txtCodProd.TabIndex = 1;
            // 
            // lblCodProd
            // 
            this.lblCodProd.AutoSize = true;
            this.lblCodProd.Location = new System.Drawing.Point(13, 40);
            this.lblCodProd.Name = "lblCodProd";
            this.lblCodProd.Size = new System.Drawing.Size(138, 19);
            this.lblCodProd.TabIndex = 0;
            this.lblCodProd.Text = "Código Produto:";
            // 
            // Estoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 553);
            this.Controls.Add(this.boxContent);
            this.Name = "Estoque";
            this.Text = "Artesanato Capixaba - Estoque";
            this.boxContent.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEstoque)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxContent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridEstoque;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTipoProduto;
        private System.Windows.Forms.Button btnAdicionarEstoque;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblTipoProduto;
        private System.Windows.Forms.TextBox txtCodProd;
        private System.Windows.Forms.Label lblCodProd;
    }
}