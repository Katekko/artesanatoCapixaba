namespace artesanatoCapixaba
{
    partial class Artesao
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
            this.gridArtesao = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnCadastrarArtesao = new System.Windows.Forms.Button();
            this.lblEditar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtTecnica = new System.Windows.Forms.TextBox();
            this.lblTecnica = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.txtNunSICAB = new System.Windows.Forms.TextBox();
            this.lblNumSICAB = new System.Windows.Forms.Label();
            this.txtMatPrima = new System.Windows.Forms.TextBox();
            this.lblMatPrima = new System.Windows.Forms.Label();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.lblCod = new System.Windows.Forms.Label();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.boxContent.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridArtesao)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxContent
            // 
            this.boxContent.Controls.Add(this.groupBox2);
            this.boxContent.Controls.Add(this.groupBox1);
            this.boxContent.Location = new System.Drawing.Point(12, 4);
            this.boxContent.Name = "boxContent";
            this.boxContent.Size = new System.Drawing.Size(764, 618);
            this.boxContent.TabIndex = 0;
            this.boxContent.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridArtesao);
            this.groupBox2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 338);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações dos Artesões";
            // 
            // gridArtesao
            // 
            this.gridArtesao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridArtesao.Location = new System.Drawing.Point(11, 25);
            this.gridArtesao.MultiSelect = false;
            this.gridArtesao.Name = "gridArtesao";
            this.gridArtesao.ReadOnly = true;
            this.gridArtesao.Size = new System.Drawing.Size(717, 299);
            this.gridArtesao.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRelatorio);
            this.groupBox1.Controls.Add(this.btnDeletar);
            this.groupBox1.Controls.Add(this.btnCadastrarArtesao);
            this.groupBox1.Controls.Add(this.lblEditar);
            this.groupBox1.Controls.Add(this.btnLimpar);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.txtTecnica);
            this.groupBox1.Controls.Add(this.lblTecnica);
            this.groupBox1.Controls.Add(this.txtCPF);
            this.groupBox1.Controls.Add(this.lblCPF);
            this.groupBox1.Controls.Add(this.txtNunSICAB);
            this.groupBox1.Controls.Add(this.lblNumSICAB);
            this.groupBox1.Controls.Add(this.txtMatPrima);
            this.groupBox1.Controls.Add(this.lblMatPrima);
            this.groupBox1.Controls.Add(this.txtMunicipio);
            this.groupBox1.Controls.Add(this.lblMunicipio);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Controls.Add(this.txtCod);
            this.groupBox1.Controls.Add(this.lblCod);
            this.groupBox1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 262);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.Red;
            this.btnDeletar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletar.Location = new System.Drawing.Point(6, 104);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(169, 62);
            this.btnDeletar.TabIndex = 2;
            this.btnDeletar.Text = "D E L E T A R";
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnCadastrarArtesao
            // 
            this.btnCadastrarArtesao.BackColor = System.Drawing.Color.LimeGreen;
            this.btnCadastrarArtesao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastrarArtesao.Location = new System.Drawing.Point(6, 26);
            this.btnCadastrarArtesao.Name = "btnCadastrarArtesao";
            this.btnCadastrarArtesao.Size = new System.Drawing.Size(169, 62);
            this.btnCadastrarArtesao.TabIndex = 1;
            this.btnCadastrarArtesao.Text = " C A D A S T R A R  ";
            this.btnCadastrarArtesao.UseVisualStyleBackColor = false;
            this.btnCadastrarArtesao.Click += new System.EventHandler(this.btnCadastrarArtesao_Click);
            // 
            // lblEditar
            // 
            this.lblEditar.BackColor = System.Drawing.Color.Fuchsia;
            this.lblEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEditar.Location = new System.Drawing.Point(6, 182);
            this.lblEditar.Name = "lblEditar";
            this.lblEditar.Size = new System.Drawing.Size(169, 62);
            this.lblEditar.TabIndex = 3;
            this.lblEditar.Text = "E D I T A R";
            this.lblEditar.UseVisualStyleBackColor = false;
            this.lblEditar.Click += new System.EventHandler(this.lblEditar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.Firebrick;
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.Location = new System.Drawing.Point(542, 25);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(169, 62);
            this.btnLimpar.TabIndex = 4;
            this.btnLimpar.Text = "L I M P A R";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.Location = new System.Drawing.Point(542, 182);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(169, 62);
            this.btnPesquisar.TabIndex = 13;
            this.btnPesquisar.Text = "P E S Q U I S A R";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtTecnica
            // 
            this.txtTecnica.Location = new System.Drawing.Point(321, 211);
            this.txtTecnica.Name = "txtTecnica";
            this.txtTecnica.Size = new System.Drawing.Size(174, 26);
            this.txtTecnica.TabIndex = 12;
            this.txtTecnica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressEnter);
            // 
            // lblTecnica
            // 
            this.lblTecnica.AutoSize = true;
            this.lblTecnica.Location = new System.Drawing.Point(239, 214);
            this.lblTecnica.Name = "lblTecnica";
            this.lblTecnica.Size = new System.Drawing.Size(78, 19);
            this.lblTecnica.TabIndex = 11;
            this.lblTecnica.Text = "Técnica:";
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(321, 115);
            this.txtCPF.MaxLength = 11;
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(174, 26);
            this.txtCPF.TabIndex = 9;
            this.txtCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressOnlyNumb);
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Location = new System.Drawing.Point(268, 118);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(49, 19);
            this.lblCPF.TabIndex = 9;
            this.lblCPF.Text = "CPF:";
            // 
            // txtNunSICAB
            // 
            this.txtNunSICAB.Location = new System.Drawing.Point(321, 83);
            this.txtNunSICAB.MaxLength = 14;
            this.txtNunSICAB.Name = "txtNunSICAB";
            this.txtNunSICAB.Size = new System.Drawing.Size(174, 26);
            this.txtNunSICAB.TabIndex = 8;
            this.txtNunSICAB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressOnlyNumb);
            // 
            // lblNumSICAB
            // 
            this.lblNumSICAB.AutoSize = true;
            this.lblNumSICAB.Location = new System.Drawing.Point(229, 86);
            this.lblNumSICAB.Name = "lblNumSICAB";
            this.lblNumSICAB.Size = new System.Drawing.Size(88, 19);
            this.lblNumSICAB.TabIndex = 7;
            this.lblNumSICAB.Text = "Nº SICAB:";
            // 
            // txtMatPrima
            // 
            this.txtMatPrima.Location = new System.Drawing.Point(321, 179);
            this.txtMatPrima.Name = "txtMatPrima";
            this.txtMatPrima.Size = new System.Drawing.Size(174, 26);
            this.txtMatPrima.TabIndex = 11;
            this.txtMatPrima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressEnter);
            // 
            // lblMatPrima
            // 
            this.lblMatPrima.AutoSize = true;
            this.lblMatPrima.Location = new System.Drawing.Point(186, 182);
            this.lblMatPrima.Name = "lblMatPrima";
            this.lblMatPrima.Size = new System.Drawing.Size(131, 19);
            this.lblMatPrima.TabIndex = 5;
            this.lblMatPrima.Text = "Matéria Prima:";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Location = new System.Drawing.Point(321, 147);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(174, 26);
            this.txtMunicipio.TabIndex = 10;
            this.txtMunicipio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressEnter);
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Location = new System.Drawing.Point(219, 150);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(98, 19);
            this.lblMunicipio.TabIndex = 3;
            this.lblMunicipio.Text = "Município:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(321, 51);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(174, 26);
            this.txtNome.TabIndex = 7;
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressEnter);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(255, 54);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(62, 19);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome:";
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(321, 19);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(79, 26);
            this.txtCod.TabIndex = 6;
            this.txtCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressOnlyNumb);
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(245, 22);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(72, 19);
            this.lblCod.TabIndex = 0;
            this.lblCod.Text = "Código:";
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.BackColor = System.Drawing.Color.Gold;
            this.btnRelatorio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRelatorio.Location = new System.Drawing.Point(542, 104);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(169, 62);
            this.btnRelatorio.TabIndex = 5;
            this.btnRelatorio.Text = "R E L A T Ó R I O";
            this.btnRelatorio.UseVisualStyleBackColor = false;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // Artesao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(786, 629);
            this.Controls.Add(this.boxContent);
            this.Name = "Artesao";
            this.Text = "Artesanato Capixaba - Artesão";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressEnter);
            this.boxContent.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridArtesao)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxContent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.TextBox txtMatPrima;
        private System.Windows.Forms.Label lblMatPrima;
        private System.Windows.Forms.Button lblEditar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.TextBox txtTecnica;
        private System.Windows.Forms.Label lblTecnica;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.TextBox txtNunSICAB;
        private System.Windows.Forms.Label lblNumSICAB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridArtesao;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnCadastrarArtesao;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnRelatorio;
    }
}