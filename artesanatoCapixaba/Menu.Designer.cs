namespace artesanatoCapixaba
{
    partial class menuPrincipal
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
            this.btnSair = new System.Windows.Forms.Button();
            this.boxVendasFuncionarioAtual = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.chkUseData = new System.Windows.Forms.CheckBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.dtpVendasAte = new System.Windows.Forms.DateTimePicker();
            this.lblAte = new System.Windows.Forms.Label();
            this.dtpVendasDe = new System.Windows.Forms.DateTimePicker();
            this.gridVendas = new System.Windows.Forms.DataGridView();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.boxMenu = new System.Windows.Forms.GroupBox();
            this.btnFuncionario = new System.Windows.Forms.Button();
            this.btnProduto = new System.Windows.Forms.Button();
            this.btnArtesao = new System.Windows.Forms.Button();
            this.btnEstoque = new System.Windows.Forms.Button();
            this.btnVender = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.btnCaixa = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalResult = new System.Windows.Forms.Label();
            this.lblItensVendidosResult = new System.Windows.Forms.Label();
            this.lblItensVendidos = new System.Windows.Forms.Label();
            this.boxContent.SuspendLayout();
            this.boxVendasFuncionarioAtual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVendas)).BeginInit();
            this.boxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxContent
            // 
            this.boxContent.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.boxContent.Controls.Add(this.lblItensVendidosResult);
            this.boxContent.Controls.Add(this.lblItensVendidos);
            this.boxContent.Controls.Add(this.lblTotalResult);
            this.boxContent.Controls.Add(this.lblTotal);
            this.boxContent.Controls.Add(this.btnSair);
            this.boxContent.Controls.Add(this.btnFuncionario);
            this.boxContent.Controls.Add(this.boxVendasFuncionarioAtual);
            this.boxContent.Controls.Add(this.lblUsuario);
            this.boxContent.Controls.Add(this.lblLogin);
            this.boxContent.Controls.Add(this.boxMenu);
            this.boxContent.Location = new System.Drawing.Point(12, 7);
            this.boxContent.Name = "boxContent";
            this.boxContent.Size = new System.Drawing.Size(1074, 681);
            this.boxContent.TabIndex = 1;
            this.boxContent.TabStop = false;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Crimson;
            this.btnSair.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(30, 603);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(128, 58);
            this.btnSair.TabIndex = 10;
            this.btnSair.Text = "S A I R";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btn_Sair_Click);
            // 
            // boxVendasFuncionarioAtual
            // 
            this.boxVendasFuncionarioAtual.Controls.Add(this.btnExport);
            this.boxVendasFuncionarioAtual.Controls.Add(this.chkUseData);
            this.boxVendasFuncionarioAtual.Controls.Add(this.btnPesquisar);
            this.boxVendasFuncionarioAtual.Controls.Add(this.txtVendedor);
            this.boxVendasFuncionarioAtual.Controls.Add(this.lblVendedor);
            this.boxVendasFuncionarioAtual.Controls.Add(this.gridVendas);
            this.boxVendasFuncionarioAtual.Controls.Add(this.dtpVendasAte);
            this.boxVendasFuncionarioAtual.Controls.Add(this.lblAte);
            this.boxVendasFuncionarioAtual.Controls.Add(this.dtpVendasDe);
            this.boxVendasFuncionarioAtual.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxVendasFuncionarioAtual.Location = new System.Drawing.Point(180, 20);
            this.boxVendasFuncionarioAtual.Name = "boxVendasFuncionarioAtual";
            this.boxVendasFuncionarioAtual.Size = new System.Drawing.Size(881, 647);
            this.boxVendasFuncionarioAtual.TabIndex = 3;
            this.boxVendasFuncionarioAtual.TabStop = false;
            this.boxVendasFuncionarioAtual.Text = "Vendas";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Lime;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(761, 20);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 26);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "E X P O R T";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chkUseData
            // 
            this.chkUseData.AutoSize = true;
            this.chkUseData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkUseData.Location = new System.Drawing.Point(150, 13);
            this.chkUseData.Name = "chkUseData";
            this.chkUseData.Size = new System.Drawing.Size(15, 14);
            this.chkUseData.TabIndex = 12;
            this.chkUseData.UseVisualStyleBackColor = true;
            this.chkUseData.CheckedChanged += new System.EventHandler(this.chkUseData_CheckedChanged);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(609, 20);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(146, 26);
            this.btnPesquisar.TabIndex = 9;
            this.btnPesquisar.Text = "P E S Q U I S A R";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtVendedor
            // 
            this.txtVendedor.Location = new System.Drawing.Point(439, 21);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(152, 26);
            this.txtVendedor.TabIndex = 8;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedor.Location = new System.Drawing.Point(324, 25);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(109, 19);
            this.lblVendedor.TabIndex = 11;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // dtpVendasAte
            // 
            this.dtpVendasAte.CustomFormat = "dd/MM/yyyy";
            this.dtpVendasAte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVendasAte.Location = new System.Drawing.Point(182, 23);
            this.dtpVendasAte.Name = "dtpVendasAte";
            this.dtpVendasAte.Size = new System.Drawing.Size(128, 26);
            this.dtpVendasAte.TabIndex = 7;
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.Location = new System.Drawing.Point(140, 30);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(39, 19);
            this.lblAte.TabIndex = 8;
            this.lblAte.Text = "Até";
            // 
            // dtpVendasDe
            // 
            this.dtpVendasDe.CalendarFont = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpVendasDe.CustomFormat = "dd/MM/yyyy";
            this.dtpVendasDe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVendasDe.Location = new System.Drawing.Point(7, 23);
            this.dtpVendasDe.Name = "dtpVendasDe";
            this.dtpVendasDe.Size = new System.Drawing.Size(127, 26);
            this.dtpVendasDe.TabIndex = 6;
            // 
            // gridVendas
            // 
            this.gridVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVendas.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gridVendas.Location = new System.Drawing.Point(6, 55);
            this.gridVendas.Name = "gridVendas";
            this.gridVendas.ReadOnly = true;
            this.gridVendas.Size = new System.Drawing.Size(866, 586);
            this.gridVendas.TabIndex = 6;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(88, 20);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(70, 19);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Admins";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(11, 20);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(71, 19);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Login:";
            // 
            // boxMenu
            // 
            this.boxMenu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.boxMenu.Controls.Add(this.btnCaixa);
            this.boxMenu.Controls.Add(this.btnProduto);
            this.boxMenu.Controls.Add(this.btnArtesao);
            this.boxMenu.Controls.Add(this.btnEstoque);
            this.boxMenu.Controls.Add(this.btnVender);
            this.boxMenu.Location = new System.Drawing.Point(12, 55);
            this.boxMenu.Name = "boxMenu";
            this.boxMenu.Size = new System.Drawing.Size(162, 317);
            this.boxMenu.TabIndex = 0;
            this.boxMenu.TabStop = false;
            // 
            // btnFuncionario
            // 
            this.btnFuncionario.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnFuncionario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFuncionario.Enabled = false;
            this.btnFuncionario.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuncionario.Location = new System.Drawing.Point(30, 541);
            this.btnFuncionario.Name = "btnFuncionario";
            this.btnFuncionario.Size = new System.Drawing.Size(128, 56);
            this.btnFuncionario.TabIndex = 5;
            this.btnFuncionario.Text = "F U N C ";
            this.btnFuncionario.UseVisualStyleBackColor = false;
            // 
            // btnProduto
            // 
            this.btnProduto.BackColor = System.Drawing.Color.LimeGreen;
            this.btnProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduto.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduto.Location = new System.Drawing.Point(7, 135);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(146, 52);
            this.btnProduto.TabIndex = 4;
            this.btnProduto.Text = "P R O D U T O ";
            this.btnProduto.UseVisualStyleBackColor = false;
            this.btnProduto.Click += new System.EventHandler(this.btnProduto_Click);
            // 
            // btnArtesao
            // 
            this.btnArtesao.BackColor = System.Drawing.Color.Fuchsia;
            this.btnArtesao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArtesao.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArtesao.Location = new System.Drawing.Point(5, 251);
            this.btnArtesao.Name = "btnArtesao";
            this.btnArtesao.Size = new System.Drawing.Size(148, 52);
            this.btnArtesao.TabIndex = 3;
            this.btnArtesao.Text = "A R T E S Ã O ";
            this.btnArtesao.UseVisualStyleBackColor = false;
            this.btnArtesao.Click += new System.EventHandler(this.btnArtesao_Click);
            // 
            // btnEstoque
            // 
            this.btnEstoque.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEstoque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstoque.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstoque.Location = new System.Drawing.Point(7, 193);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(146, 52);
            this.btnEstoque.TabIndex = 2;
            this.btnEstoque.Text = "E S T O Q U E ";
            this.btnEstoque.UseVisualStyleBackColor = false;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);
            // 
            // btnVender
            // 
            this.btnVender.BackColor = System.Drawing.Color.Gold;
            this.btnVender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVender.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVender.Location = new System.Drawing.Point(8, 77);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(145, 52);
            this.btnVender.TabIndex = 1;
            this.btnVender.Text = "V E N D E R";
            this.btnVender.UseVisualStyleBackColor = false;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // saveFile
            // 
            this.saveFile.Filter = "Excel Files(2010)|*.xlsx";
            this.saveFile.InitialDirectory = "C:";
            this.saveFile.Title = "Save as Excel File";
            // 
            // btnCaixa
            // 
            this.btnCaixa.BackColor = System.Drawing.Color.Yellow;
            this.btnCaixa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaixa.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaixa.Location = new System.Drawing.Point(7, 19);
            this.btnCaixa.Name = "btnCaixa";
            this.btnCaixa.Size = new System.Drawing.Size(146, 52);
            this.btnCaixa.TabIndex = 6;
            this.btnCaixa.Text = "C A I X A";
            this.btnCaixa.UseVisualStyleBackColor = false;
            this.btnCaixa.Click += new System.EventHandler(this.btnCaixa_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(26, 393);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 19);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total:";
            // 
            // lblTotalResult
            // 
            this.lblTotalResult.AutoSize = true;
            this.lblTotalResult.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalResult.ForeColor = System.Drawing.Color.Red;
            this.lblTotalResult.Location = new System.Drawing.Point(79, 393);
            this.lblTotalResult.Name = "lblTotalResult";
            this.lblTotalResult.Size = new System.Drawing.Size(67, 19);
            this.lblTotalResult.TabIndex = 12;
            this.lblTotalResult.Text = "R$ 0,00";
            // 
            // lblItensVendidosResult
            // 
            this.lblItensVendidosResult.AutoSize = true;
            this.lblItensVendidosResult.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItensVendidosResult.ForeColor = System.Drawing.Color.Red;
            this.lblItensVendidosResult.Location = new System.Drawing.Point(79, 428);
            this.lblItensVendidosResult.Name = "lblItensVendidosResult";
            this.lblItensVendidosResult.Size = new System.Drawing.Size(18, 19);
            this.lblItensVendidosResult.TabIndex = 14;
            this.lblItensVendidosResult.Text = "0";
            // 
            // lblItensVendidos
            // 
            this.lblItensVendidos.AutoSize = true;
            this.lblItensVendidos.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItensVendidos.Location = new System.Drawing.Point(28, 428);
            this.lblItensVendidos.Name = "lblItensVendidos";
            this.lblItensVendidos.Size = new System.Drawing.Size(54, 19);
            this.lblItensVendidos.TabIndex = 13;
            this.lblItensVendidos.Text = "Itens:";
            // 
            // menuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1100, 698);
            this.Controls.Add(this.boxContent);
            this.Name = "menuPrincipal";
            this.Text = "Artesanato Capixaba - Menu";
            this.boxContent.ResumeLayout(false);
            this.boxContent.PerformLayout();
            this.boxVendasFuncionarioAtual.ResumeLayout(false);
            this.boxVendasFuncionarioAtual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVendas)).EndInit();
            this.boxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxContent;
        private System.Windows.Forms.GroupBox boxMenu;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button btnFuncionario;
        private System.Windows.Forms.Button btnProduto;
        private System.Windows.Forms.Button btnArtesao;
        private System.Windows.Forms.Button btnEstoque;
        private System.Windows.Forms.GroupBox boxVendasFuncionarioAtual;
        private System.Windows.Forms.DataGridView gridVendas;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DateTimePicker dtpVendasDe;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.DateTimePicker dtpVendasAte;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.CheckBox chkUseData;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.Button btnCaixa;
        private System.Windows.Forms.Label lblTotalResult;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblItensVendidosResult;
        private System.Windows.Forms.Label lblItensVendidos;
    }
}

