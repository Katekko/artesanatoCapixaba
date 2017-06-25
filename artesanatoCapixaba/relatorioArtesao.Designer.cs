namespace artesanatoCapixaba
{
    partial class relatorioArtesao
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
            this.boxFiltros = new System.Windows.Forms.GroupBox();
            this.lblDe = new System.Windows.Forms.Label();
            this.lblTipoRelatorio = new System.Windows.Forms.Label();
            this.cmbTipoRelatorio = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtCodArtesao = new System.Windows.Forms.TextBox();
            this.lblCodArtesao = new System.Windows.Forms.Label();
            this.dtpDataAte = new System.Windows.Forms.DateTimePicker();
            this.lblAte = new System.Windows.Forms.Label();
            this.dtpDataDe = new System.Windows.Forms.DateTimePicker();
            this.boxGridArtesao = new System.Windows.Forms.GroupBox();
            this.gridArtesao = new System.Windows.Forms.DataGridView();
            this.boxFiltros.SuspendLayout();
            this.boxGridArtesao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridArtesao)).BeginInit();
            this.SuspendLayout();
            // 
            // boxFiltros
            // 
            this.boxFiltros.Controls.Add(this.lblDe);
            this.boxFiltros.Controls.Add(this.lblTipoRelatorio);
            this.boxFiltros.Controls.Add(this.cmbTipoRelatorio);
            this.boxFiltros.Controls.Add(this.btnExport);
            this.boxFiltros.Controls.Add(this.btnPesquisar);
            this.boxFiltros.Controls.Add(this.txtCodArtesao);
            this.boxFiltros.Controls.Add(this.lblCodArtesao);
            this.boxFiltros.Controls.Add(this.dtpDataAte);
            this.boxFiltros.Controls.Add(this.lblAte);
            this.boxFiltros.Controls.Add(this.dtpDataDe);
            this.boxFiltros.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxFiltros.Location = new System.Drawing.Point(12, 12);
            this.boxFiltros.Name = "boxFiltros";
            this.boxFiltros.Size = new System.Drawing.Size(370, 179);
            this.boxFiltros.TabIndex = 0;
            this.boxFiltros.TabStop = false;
            this.boxFiltros.Text = "Filtros";
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDe.Location = new System.Drawing.Point(9, 101);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(40, 19);
            this.lblDe.TabIndex = 21;
            this.lblDe.Text = "De:";
            // 
            // lblTipoRelatorio
            // 
            this.lblTipoRelatorio.AutoSize = true;
            this.lblTipoRelatorio.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoRelatorio.Location = new System.Drawing.Point(31, 63);
            this.lblTipoRelatorio.Name = "lblTipoRelatorio";
            this.lblTipoRelatorio.Size = new System.Drawing.Size(154, 19);
            this.lblTipoRelatorio.TabIndex = 20;
            this.lblTipoRelatorio.Text = "Tipo Relatório:";
            // 
            // cmbTipoRelatorio
            // 
            this.cmbTipoRelatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRelatorio.FormattingEnabled = true;
            this.cmbTipoRelatorio.Items.AddRange(new object[] {
            "Total para Receber",
            "Itens vendidos"});
            this.cmbTipoRelatorio.Location = new System.Drawing.Point(191, 60);
            this.cmbTipoRelatorio.Name = "cmbTipoRelatorio";
            this.cmbTipoRelatorio.Size = new System.Drawing.Size(169, 27);
            this.cmbTipoRelatorio.TabIndex = 19;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Lime;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(193, 137);
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
            this.btnPesquisar.Location = new System.Drawing.Point(10, 136);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(169, 32);
            this.btnPesquisar.TabIndex = 4;
            this.btnPesquisar.Text = "P E S Q U I S A R";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtCodArtesao
            // 
            this.txtCodArtesao.Location = new System.Drawing.Point(191, 26);
            this.txtCodArtesao.Name = "txtCodArtesao";
            this.txtCodArtesao.Size = new System.Drawing.Size(169, 26);
            this.txtCodArtesao.TabIndex = 0;
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
            // dtpDataAte
            // 
            this.dtpDataAte.CustomFormat = "dd/MM/yyyy";
            this.dtpDataAte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataAte.Location = new System.Drawing.Point(232, 99);
            this.dtpDataAte.Name = "dtpDataAte";
            this.dtpDataAte.Size = new System.Drawing.Size(128, 26);
            this.dtpDataAte.TabIndex = 3;
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.Location = new System.Drawing.Point(185, 101);
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
            this.dtpDataDe.Location = new System.Drawing.Point(51, 99);
            this.dtpDataDe.Name = "dtpDataDe";
            this.dtpDataDe.Size = new System.Drawing.Size(128, 26);
            this.dtpDataDe.TabIndex = 2;
            // 
            // boxGridArtesao
            // 
            this.boxGridArtesao.Controls.Add(this.gridArtesao);
            this.boxGridArtesao.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxGridArtesao.Location = new System.Drawing.Point(13, 197);
            this.boxGridArtesao.Name = "boxGridArtesao";
            this.boxGridArtesao.Size = new System.Drawing.Size(369, 326);
            this.boxGridArtesao.TabIndex = 0;
            this.boxGridArtesao.TabStop = false;
            this.boxGridArtesao.Text = "Info";
            // 
            // gridArtesao
            // 
            this.gridArtesao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridArtesao.Location = new System.Drawing.Point(9, 26);
            this.gridArtesao.MultiSelect = false;
            this.gridArtesao.Name = "gridArtesao";
            this.gridArtesao.ReadOnly = true;
            this.gridArtesao.Size = new System.Drawing.Size(350, 285);
            this.gridArtesao.TabIndex = 6;
            // 
            // relatorioArtesao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 536);
            this.Controls.Add(this.boxGridArtesao);
            this.Controls.Add(this.boxFiltros);
            this.Name = "relatorioArtesao";
            this.Text = "Artesanato Capixaba - Relatório Artesão";
            this.boxFiltros.ResumeLayout(false);
            this.boxFiltros.PerformLayout();
            this.boxGridArtesao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridArtesao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxFiltros;
        private System.Windows.Forms.GroupBox boxGridArtesao;
        private System.Windows.Forms.DateTimePicker dtpDataAte;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.DateTimePicker dtpDataDe;
        private System.Windows.Forms.TextBox txtCodArtesao;
        private System.Windows.Forms.Label lblCodArtesao;
        private System.Windows.Forms.Label lblTipoRelatorio;
        private System.Windows.Forms.ComboBox cmbTipoRelatorio;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DataGridView gridArtesao;
        private System.Windows.Forms.Label lblDe;
    }
}