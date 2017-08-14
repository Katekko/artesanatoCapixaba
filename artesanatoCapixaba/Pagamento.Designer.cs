namespace artesanatoCapixaba
{
    partial class Pagamento
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
            this.boxGridPagamento = new System.Windows.Forms.GroupBox();
            this.gridPagamentos = new System.Windows.Forms.DataGridView();
            this.boxFiltros = new System.Windows.Forms.GroupBox();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtNomeArtesao = new System.Windows.Forms.TextBox();
            this.lblNomeArtesao = new System.Windows.Forms.Label();
            this.lblDataPagamento = new System.Windows.Forms.Label();
            this.btnEfetuarPagamento = new System.Windows.Forms.Button();
            this.txtCodArtesao = new System.Windows.Forms.TextBox();
            this.lblCodArtesao = new System.Windows.Forms.Label();
            this.dtpDataPagamento = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNomeArtPesq = new System.Windows.Forms.TextBox();
            this.lblNomeArtPesq = new System.Windows.Forms.Label();
            this.lblDe = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtCodArtPesq = new System.Windows.Forms.TextBox();
            this.lblCodArtPesq = new System.Windows.Forms.Label();
            this.dtpDataAte = new System.Windows.Forms.DateTimePicker();
            this.lblAte = new System.Windows.Forms.Label();
            this.dtpDataDe = new System.Windows.Forms.DateTimePicker();
            this.boxGridPagamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPagamentos)).BeginInit();
            this.boxFiltros.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxGridPagamento
            // 
            this.boxGridPagamento.Controls.Add(this.gridPagamentos);
            this.boxGridPagamento.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxGridPagamento.Location = new System.Drawing.Point(7, 200);
            this.boxGridPagamento.Name = "boxGridPagamento";
            this.boxGridPagamento.Size = new System.Drawing.Size(370, 287);
            this.boxGridPagamento.TabIndex = 1;
            this.boxGridPagamento.TabStop = false;
            this.boxGridPagamento.Text = "Info";
            // 
            // gridPagamentos
            // 
            this.gridPagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPagamentos.Location = new System.Drawing.Point(10, 23);
            this.gridPagamentos.MultiSelect = false;
            this.gridPagamentos.Name = "gridPagamentos";
            this.gridPagamentos.ReadOnly = true;
            this.gridPagamentos.Size = new System.Drawing.Size(350, 253);
            this.gridPagamentos.TabIndex = 5;
            // 
            // boxFiltros
            // 
            this.boxFiltros.Controls.Add(this.txtValorPago);
            this.boxFiltros.Controls.Add(this.lblValor);
            this.boxFiltros.Controls.Add(this.txtNomeArtesao);
            this.boxFiltros.Controls.Add(this.lblNomeArtesao);
            this.boxFiltros.Controls.Add(this.lblDataPagamento);
            this.boxFiltros.Controls.Add(this.btnEfetuarPagamento);
            this.boxFiltros.Controls.Add(this.txtCodArtesao);
            this.boxFiltros.Controls.Add(this.lblCodArtesao);
            this.boxFiltros.Controls.Add(this.dtpDataPagamento);
            this.boxFiltros.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxFiltros.Location = new System.Drawing.Point(12, 496);
            this.boxFiltros.Name = "boxFiltros";
            this.boxFiltros.Size = new System.Drawing.Size(374, 205);
            this.boxFiltros.TabIndex = 2;
            this.boxFiltros.TabStop = false;
            this.boxFiltros.Text = "Pagar Artesão";
            // 
            // txtValorPago
            // 
            this.txtValorPago.Location = new System.Drawing.Point(191, 90);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(169, 26);
            this.txtValorPago.TabIndex = 1;
            this.txtValorPago.Leave += new System.EventHandler(this.txtValorPago_Leave);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(64, 93);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(121, 19);
            this.lblValor.TabIndex = 25;
            this.lblValor.Text = "Valor Pago:";
            // 
            // txtNomeArtesao
            // 
            this.txtNomeArtesao.Enabled = false;
            this.txtNomeArtesao.Location = new System.Drawing.Point(191, 58);
            this.txtNomeArtesao.Name = "txtNomeArtesao";
            this.txtNomeArtesao.ReadOnly = true;
            this.txtNomeArtesao.Size = new System.Drawing.Size(169, 26);
            this.txtNomeArtesao.TabIndex = 23;
            // 
            // lblNomeArtesao
            // 
            this.lblNomeArtesao.AutoSize = true;
            this.lblNomeArtesao.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeArtesao.Location = new System.Drawing.Point(37, 61);
            this.lblNomeArtesao.Name = "lblNomeArtesao";
            this.lblNomeArtesao.Size = new System.Drawing.Size(148, 19);
            this.lblNomeArtesao.TabIndex = 22;
            this.lblNomeArtesao.Text = "Nome Artesão:";
            // 
            // lblDataPagamento
            // 
            this.lblDataPagamento.AutoSize = true;
            this.lblDataPagamento.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataPagamento.Location = new System.Drawing.Point(125, 125);
            this.lblDataPagamento.Name = "lblDataPagamento";
            this.lblDataPagamento.Size = new System.Drawing.Size(60, 19);
            this.lblDataPagamento.TabIndex = 21;
            this.lblDataPagamento.Text = "Data:";
            // 
            // btnEfetuarPagamento
            // 
            this.btnEfetuarPagamento.BackColor = System.Drawing.Color.Lime;
            this.btnEfetuarPagamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEfetuarPagamento.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEfetuarPagamento.Location = new System.Drawing.Point(10, 159);
            this.btnEfetuarPagamento.Name = "btnEfetuarPagamento";
            this.btnEfetuarPagamento.Size = new System.Drawing.Size(348, 32);
            this.btnEfetuarPagamento.TabIndex = 3;
            this.btnEfetuarPagamento.Text = "Efetuar Pagamento";
            this.btnEfetuarPagamento.UseVisualStyleBackColor = false;
            this.btnEfetuarPagamento.Click += new System.EventHandler(this.btnEfetuarPagamento_Click);
            // 
            // txtCodArtesao
            // 
            this.txtCodArtesao.Location = new System.Drawing.Point(191, 26);
            this.txtCodArtesao.Name = "txtCodArtesao";
            this.txtCodArtesao.Size = new System.Drawing.Size(169, 26);
            this.txtCodArtesao.TabIndex = 0;
            this.txtCodArtesao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorPago_KeyPress);
            this.txtCodArtesao.Leave += new System.EventHandler(this.txtCodArtesao_Leave);
            // 
            // lblCodArtesao
            // 
            this.lblCodArtesao.AutoSize = true;
            this.lblCodArtesao.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodArtesao.Location = new System.Drawing.Point(23, 29);
            this.lblCodArtesao.Name = "lblCodArtesao";
            this.lblCodArtesao.Size = new System.Drawing.Size(162, 19);
            this.lblCodArtesao.TabIndex = 18;
            this.lblCodArtesao.Text = "Codigo Artesão:";
            // 
            // dtpDataPagamento
            // 
            this.dtpDataPagamento.CalendarFont = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataPagamento.CustomFormat = "dd/MM/yyyy";
            this.dtpDataPagamento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataPagamento.Location = new System.Drawing.Point(191, 122);
            this.dtpDataPagamento.Name = "dtpDataPagamento";
            this.dtpDataPagamento.Size = new System.Drawing.Size(167, 26);
            this.dtpDataPagamento.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.boxGridPagamento);
            this.groupBox3.Location = new System.Drawing.Point(8, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 494);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNomeArtPesq);
            this.groupBox2.Controls.Add(this.lblNomeArtPesq);
            this.groupBox2.Controls.Add(this.lblDe);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.btnPesquisar);
            this.groupBox2.Controls.Add(this.txtCodArtPesq);
            this.groupBox2.Controls.Add(this.lblCodArtPesq);
            this.groupBox2.Controls.Add(this.dtpDataAte);
            this.groupBox2.Controls.Add(this.lblAte);
            this.groupBox2.Controls.Add(this.dtpDataDe);
            this.groupBox2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 193);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros";
            // 
            // txtNomeArtPesq
            // 
            this.txtNomeArtPesq.Enabled = false;
            this.txtNomeArtPesq.Location = new System.Drawing.Point(191, 68);
            this.txtNomeArtPesq.Name = "txtNomeArtPesq";
            this.txtNomeArtPesq.ReadOnly = true;
            this.txtNomeArtPesq.Size = new System.Drawing.Size(169, 26);
            this.txtNomeArtPesq.TabIndex = 23;
            // 
            // lblNomeArtPesq
            // 
            this.lblNomeArtPesq.AutoSize = true;
            this.lblNomeArtPesq.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeArtPesq.Location = new System.Drawing.Point(37, 71);
            this.lblNomeArtPesq.Name = "lblNomeArtPesq";
            this.lblNomeArtPesq.Size = new System.Drawing.Size(148, 19);
            this.lblNomeArtPesq.TabIndex = 22;
            this.lblNomeArtPesq.Text = "Nome Artesão:";
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDe.Location = new System.Drawing.Point(9, 111);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(40, 19);
            this.lblDe.TabIndex = 21;
            this.lblDe.Text = "De:";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Lime;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(193, 147);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(167, 31);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "E X P O R T";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(10, 146);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(169, 32);
            this.btnPesquisar.TabIndex = 4;
            this.btnPesquisar.Text = "P E S Q U I S A R";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtCodArtPesq
            // 
            this.txtCodArtPesq.Location = new System.Drawing.Point(191, 26);
            this.txtCodArtPesq.Name = "txtCodArtPesq";
            this.txtCodArtPesq.Size = new System.Drawing.Size(169, 26);
            this.txtCodArtPesq.TabIndex = 0;
            this.txtCodArtPesq.Leave += new System.EventHandler(this.txtCodArtesao_Leave);
            // 
            // lblCodArtPesq
            // 
            this.lblCodArtPesq.AutoSize = true;
            this.lblCodArtPesq.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodArtPesq.Location = new System.Drawing.Point(23, 29);
            this.lblCodArtPesq.Name = "lblCodArtPesq";
            this.lblCodArtPesq.Size = new System.Drawing.Size(162, 19);
            this.lblCodArtPesq.TabIndex = 18;
            this.lblCodArtPesq.Text = "Codigo Artesão:";
            // 
            // dtpDataAte
            // 
            this.dtpDataAte.CustomFormat = "dd/MM/yyyy";
            this.dtpDataAte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataAte.Location = new System.Drawing.Point(232, 109);
            this.dtpDataAte.Name = "dtpDataAte";
            this.dtpDataAte.Size = new System.Drawing.Size(128, 26);
            this.dtpDataAte.TabIndex = 3;
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.Location = new System.Drawing.Point(185, 111);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(45, 19);
            this.lblAte.TabIndex = 15;
            this.lblAte.Text = "Até:";
            // 
            // dtpDataDe
            // 
            this.dtpDataDe.CalendarFont = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataDe.CustomFormat = "dd/MM/yyyy";
            this.dtpDataDe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataDe.Location = new System.Drawing.Point(51, 109);
            this.dtpDataDe.Name = "dtpDataDe";
            this.dtpDataDe.Size = new System.Drawing.Size(128, 26);
            this.dtpDataDe.TabIndex = 2;
            // 
            // Pagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 714);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.boxFiltros);
            this.Name = "Pagamento";
            this.Text = "Pagamento";
            this.boxGridPagamento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPagamentos)).EndInit();
            this.boxFiltros.ResumeLayout(false);
            this.boxFiltros.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxGridPagamento;
        private System.Windows.Forms.DataGridView gridPagamentos;
        private System.Windows.Forms.GroupBox boxFiltros;
        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtNomeArtesao;
        private System.Windows.Forms.Label lblNomeArtesao;
        private System.Windows.Forms.Label lblDataPagamento;
        private System.Windows.Forms.Button btnEfetuarPagamento;
        private System.Windows.Forms.TextBox txtCodArtesao;
        private System.Windows.Forms.Label lblCodArtesao;
        private System.Windows.Forms.DateTimePicker dtpDataPagamento;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNomeArtPesq;
        private System.Windows.Forms.Label lblNomeArtPesq;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtCodArtPesq;
        private System.Windows.Forms.Label lblCodArtPesq;
        private System.Windows.Forms.DateTimePicker dtpDataAte;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.DateTimePicker dtpDataDe;
    }
}