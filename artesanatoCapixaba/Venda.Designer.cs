namespace artesanatoCapixaba
{
    partial class Venda
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
            this.boxEfetuarVenda = new System.Windows.Forms.GroupBox();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.cmbVendedor = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnEfutarVenda = new System.Windows.Forms.Button();
            this.txtTroco = new System.Windows.Forms.TextBox();
            this.lblTroco = new System.Windows.Forms.Label();
            this.boxGridVendas = new System.Windows.Forms.GroupBox();
            this.gridItemVenda = new System.Windows.Forms.DataGridView();
            this.boxPagamento = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSegundaOpcao = new System.Windows.Forms.Label();
            this.txtSegundaOpcao = new System.Windows.Forms.TextBox();
            this.lblTipoPagamento = new System.Windows.Forms.Label();
            this.cmbTipoPagamento = new System.Windows.Forms.ComboBox();
            this.lblValorRecebido = new System.Windows.Forms.Label();
            this.txtValorRecebido = new System.Windows.Forms.TextBox();
            this.boxItems = new System.Windows.Forms.GroupBox();
            this.btnRetirarItem = new System.Windows.Forms.Button();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.lblCodProd = new System.Windows.Forms.Label();
            this.txtCodProd = new System.Windows.Forms.TextBox();
            this.lblQuant = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.chkDesconto = new System.Windows.Forms.CheckBox();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.Codigo_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorAntigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boxContent.SuspendLayout();
            this.boxEfetuarVenda.SuspendLayout();
            this.boxGridVendas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemVenda)).BeginInit();
            this.boxPagamento.SuspendLayout();
            this.boxItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxContent
            // 
            this.boxContent.BackColor = System.Drawing.Color.LightGray;
            this.boxContent.Controls.Add(this.boxEfetuarVenda);
            this.boxContent.Controls.Add(this.boxGridVendas);
            this.boxContent.Controls.Add(this.boxPagamento);
            this.boxContent.Controls.Add(this.boxItems);
            this.boxContent.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxContent.Location = new System.Drawing.Point(12, -1);
            this.boxContent.Name = "boxContent";
            this.boxContent.Size = new System.Drawing.Size(793, 400);
            this.boxContent.TabIndex = 3;
            this.boxContent.TabStop = false;
            // 
            // boxEfetuarVenda
            // 
            this.boxEfetuarVenda.Controls.Add(this.lblVendedor);
            this.boxEfetuarVenda.Controls.Add(this.cmbVendedor);
            this.boxEfetuarVenda.Controls.Add(this.lblTotal);
            this.boxEfetuarVenda.Controls.Add(this.txtTotal);
            this.boxEfetuarVenda.Controls.Add(this.btnEfutarVenda);
            this.boxEfetuarVenda.Controls.Add(this.txtTroco);
            this.boxEfetuarVenda.Controls.Add(this.lblTroco);
            this.boxEfetuarVenda.Location = new System.Drawing.Point(16, 274);
            this.boxEfetuarVenda.Name = "boxEfetuarVenda";
            this.boxEfetuarVenda.Size = new System.Drawing.Size(764, 115);
            this.boxEfetuarVenda.TabIndex = 20;
            this.boxEfetuarVenda.TabStop = false;
            this.boxEfetuarVenda.Text = "Efetuar Venda";
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(12, 28);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(90, 19);
            this.lblVendedor.TabIndex = 17;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Location = new System.Drawing.Point(108, 25);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(172, 27);
            this.cmbVendedor.TabIndex = 8;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(320, 28);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 19);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(382, 25);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(137, 26);
            this.txtTotal.TabIndex = 155;
            // 
            // btnEfutarVenda
            // 
            this.btnEfutarVenda.BackColor = System.Drawing.Color.Chartreuse;
            this.btnEfutarVenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEfutarVenda.Location = new System.Drawing.Point(6, 58);
            this.btnEfutarVenda.Name = "btnEfutarVenda";
            this.btnEfutarVenda.Size = new System.Drawing.Size(750, 49);
            this.btnEfutarVenda.TabIndex = 9;
            this.btnEfutarVenda.Text = "E F E T U A R   V E N D A";
            this.btnEfutarVenda.UseVisualStyleBackColor = false;
            this.btnEfutarVenda.Click += new System.EventHandler(this.btnEfutarVenda_Click);
            // 
            // txtTroco
            // 
            this.txtTroco.Enabled = false;
            this.txtTroco.Location = new System.Drawing.Point(618, 25);
            this.txtTroco.Name = "txtTroco";
            this.txtTroco.Size = new System.Drawing.Size(127, 26);
            this.txtTroco.TabIndex = 155;
            // 
            // lblTroco
            // 
            this.lblTroco.AutoSize = true;
            this.lblTroco.Location = new System.Drawing.Point(552, 28);
            this.lblTroco.Name = "lblTroco";
            this.lblTroco.Size = new System.Drawing.Size(60, 19);
            this.lblTroco.TabIndex = 14;
            this.lblTroco.Text = "Troco:";
            // 
            // boxGridVendas
            // 
            this.boxGridVendas.Controls.Add(this.gridItemVenda);
            this.boxGridVendas.Location = new System.Drawing.Point(423, 16);
            this.boxGridVendas.Name = "boxGridVendas";
            this.boxGridVendas.Size = new System.Drawing.Size(357, 257);
            this.boxGridVendas.TabIndex = 7;
            this.boxGridVendas.TabStop = false;
            this.boxGridVendas.Text = "Itens da Venda";
            // 
            // gridItemVenda
            // 
            this.gridItemVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItemVenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo_Produto,
            this.Quantidade_Produto,
            this.ValorTotal_Item,
            this.Desconto,
            this.ValorAntigo});
            this.gridItemVenda.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.gridItemVenda.Location = new System.Drawing.Point(6, 18);
            this.gridItemVenda.Name = "gridItemVenda";
            this.gridItemVenda.ReadOnly = true;
            this.gridItemVenda.Size = new System.Drawing.Size(343, 232);
            this.gridItemVenda.TabIndex = 0;
            // 
            // boxPagamento
            // 
            this.boxPagamento.Controls.Add(this.label3);
            this.boxPagamento.Controls.Add(this.label2);
            this.boxPagamento.Controls.Add(this.label1);
            this.boxPagamento.Controls.Add(this.lblSegundaOpcao);
            this.boxPagamento.Controls.Add(this.txtSegundaOpcao);
            this.boxPagamento.Controls.Add(this.lblTipoPagamento);
            this.boxPagamento.Controls.Add(this.cmbTipoPagamento);
            this.boxPagamento.Controls.Add(this.lblValorRecebido);
            this.boxPagamento.Controls.Add(this.txtValorRecebido);
            this.boxPagamento.Location = new System.Drawing.Point(16, 136);
            this.boxPagamento.Name = "boxPagamento";
            this.boxPagamento.Size = new System.Drawing.Size(401, 137);
            this.boxPagamento.TabIndex = 19;
            this.boxPagamento.TabStop = false;
            this.boxPagamento.Text = "Pagamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(166, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(166, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = ":";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = ":";
            // 
            // lblSegundaOpcao
            // 
            this.lblSegundaOpcao.AutoSize = true;
            this.lblSegundaOpcao.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSegundaOpcao.Location = new System.Drawing.Point(12, 101);
            this.lblSegundaOpcao.Name = "lblSegundaOpcao";
            this.lblSegundaOpcao.Size = new System.Drawing.Size(127, 19);
            this.lblSegundaOpcao.TabIndex = 14;
            this.lblSegundaOpcao.Text = "Segunda Opção";
            // 
            // txtSegundaOpcao
            // 
            this.txtSegundaOpcao.Enabled = false;
            this.txtSegundaOpcao.Location = new System.Drawing.Point(186, 98);
            this.txtSegundaOpcao.Name = "txtSegundaOpcao";
            this.txtSegundaOpcao.Size = new System.Drawing.Size(172, 26);
            this.txtSegundaOpcao.TabIndex = 7;
            // 
            // lblTipoPagamento
            // 
            this.lblTipoPagamento.AutoSize = true;
            this.lblTipoPagamento.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoPagamento.Location = new System.Drawing.Point(12, 36);
            this.lblTipoPagamento.Name = "lblTipoPagamento";
            this.lblTipoPagamento.Size = new System.Drawing.Size(124, 19);
            this.lblTipoPagamento.TabIndex = 7;
            this.lblTipoPagamento.Text = "Tipo de Pagam.";
            // 
            // cmbTipoPagamento
            // 
            this.cmbTipoPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPagamento.FormattingEnabled = true;
            this.cmbTipoPagamento.Location = new System.Drawing.Point(186, 33);
            this.cmbTipoPagamento.Name = "cmbTipoPagamento";
            this.cmbTipoPagamento.Size = new System.Drawing.Size(172, 27);
            this.cmbTipoPagamento.TabIndex = 3;
            this.cmbTipoPagamento.SelectedIndexChanged += new System.EventHandler(this.cmbTipoPagamento_SelectedIndexChanged);
            // 
            // lblValorRecebido
            // 
            this.lblValorRecebido.AutoSize = true;
            this.lblValorRecebido.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorRecebido.Location = new System.Drawing.Point(12, 69);
            this.lblValorRecebido.Name = "lblValorRecebido";
            this.lblValorRecebido.Size = new System.Drawing.Size(122, 19);
            this.lblValorRecebido.TabIndex = 12;
            this.lblValorRecebido.Text = "Valor Recebido";
            // 
            // txtValorRecebido
            // 
            this.txtValorRecebido.Location = new System.Drawing.Point(186, 66);
            this.txtValorRecebido.Name = "txtValorRecebido";
            this.txtValorRecebido.Size = new System.Drawing.Size(172, 26);
            this.txtValorRecebido.TabIndex = 6;
            this.txtValorRecebido.Leave += new System.EventHandler(this.txtValorRecebido_Leave);
            // 
            // boxItems
            // 
            this.boxItems.Controls.Add(this.txtDesconto);
            this.boxItems.Controls.Add(this.chkDesconto);
            this.boxItems.Controls.Add(this.btnRetirarItem);
            this.boxItems.Controls.Add(this.btnAdicionarItem);
            this.boxItems.Controls.Add(this.lblDesconto);
            this.boxItems.Controls.Add(this.lblCodProd);
            this.boxItems.Controls.Add(this.txtCodProd);
            this.boxItems.Controls.Add(this.lblQuant);
            this.boxItems.Controls.Add(this.txtQuantidade);
            this.boxItems.Location = new System.Drawing.Point(16, 17);
            this.boxItems.Name = "boxItems";
            this.boxItems.Size = new System.Drawing.Size(401, 116);
            this.boxItems.TabIndex = 18;
            this.boxItems.TabStop = false;
            this.boxItems.Text = "Itens";
            // 
            // btnRetirarItem
            // 
            this.btnRetirarItem.BackColor = System.Drawing.Color.Crimson;
            this.btnRetirarItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetirarItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRetirarItem.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirarItem.Location = new System.Drawing.Point(364, 19);
            this.btnRetirarItem.Name = "btnRetirarItem";
            this.btnRetirarItem.Size = new System.Drawing.Size(30, 23);
            this.btnRetirarItem.TabIndex = 155;
            this.btnRetirarItem.Text = "X";
            this.btnRetirarItem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRetirarItem.UseVisualStyleBackColor = false;
            this.btnRetirarItem.Click += new System.EventHandler(this.btnRetirarItem_Click);
            // 
            // btnAdicionarItem
            // 
            this.btnAdicionarItem.BackColor = System.Drawing.Color.LawnGreen;
            this.btnAdicionarItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdicionarItem.Location = new System.Drawing.Point(328, 19);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(30, 23);
            this.btnAdicionarItem.TabIndex = 2;
            this.btnAdicionarItem.Text = ">";
            this.btnAdicionarItem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdicionarItem.UseVisualStyleBackColor = false;
            this.btnAdicionarItem.Click += new System.EventHandler(this.btnAdicionarItem_Click);
            // 
            // lblCodProd
            // 
            this.lblCodProd.AutoSize = true;
            this.lblCodProd.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodProd.Location = new System.Drawing.Point(12, 22);
            this.lblCodProd.Name = "lblCodProd";
            this.lblCodProd.Size = new System.Drawing.Size(130, 19);
            this.lblCodProd.TabIndex = 0;
            this.lblCodProd.Text = "Código Produto:";
            // 
            // txtCodProd
            // 
            this.txtCodProd.Location = new System.Drawing.Point(147, 17);
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.Size = new System.Drawing.Size(172, 26);
            this.txtCodProd.TabIndex = 0;
            this.txtCodProd.Leave += new System.EventHandler(this.txtCodProd_Leave);
            // 
            // lblQuant
            // 
            this.lblQuant.AutoSize = true;
            this.lblQuant.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuant.Location = new System.Drawing.Point(41, 52);
            this.lblQuant.Name = "lblQuant";
            this.lblQuant.Size = new System.Drawing.Size(101, 19);
            this.lblQuant.TabIndex = 8;
            this.lblQuant.Text = "Quantidade:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(147, 49);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(172, 26);
            this.txtQuantidade.TabIndex = 1;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            this.txtQuantidade.Leave += new System.EventHandler(this.txtQuantidade_Leave);
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesconto.Location = new System.Drawing.Point(60, 84);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(82, 19);
            this.lblDesconto.TabIndex = 18;
            this.lblDesconto.Text = "Desconto:";
            // 
            // chkDesconto
            // 
            this.chkDesconto.AutoSize = true;
            this.chkDesconto.Location = new System.Drawing.Point(326, 87);
            this.chkDesconto.Name = "chkDesconto";
            this.chkDesconto.Size = new System.Drawing.Size(15, 14);
            this.chkDesconto.TabIndex = 4;
            this.chkDesconto.UseVisualStyleBackColor = true;
            this.chkDesconto.CheckedChanged += new System.EventHandler(this.chkDesconto_CheckedChanged);
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(148, 81);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(172, 26);
            this.txtDesconto.TabIndex = 5;
            // 
            // Codigo_Produto
            // 
            this.Codigo_Produto.HeaderText = "Produto";
            this.Codigo_Produto.Name = "Codigo_Produto";
            this.Codigo_Produto.ReadOnly = true;
            this.Codigo_Produto.Width = 85;
            // 
            // Quantidade_Produto
            // 
            this.Quantidade_Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Quantidade_Produto.HeaderText = "Quant";
            this.Quantidade_Produto.Name = "Quantidade_Produto";
            this.Quantidade_Produto.ReadOnly = true;
            this.Quantidade_Produto.Width = 83;
            // 
            // ValorTotal_Item
            // 
            this.ValorTotal_Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ValorTotal_Item.HeaderText = "Valor";
            this.ValorTotal_Item.Name = "ValorTotal_Item";
            this.ValorTotal_Item.ReadOnly = true;
            this.ValorTotal_Item.Width = 76;
            // 
            // Desconto
            // 
            this.Desconto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Desconto.HeaderText = "Desc.";
            this.Desconto.Name = "Desconto";
            this.Desconto.ReadOnly = true;
            // 
            // ValorAntigo
            // 
            this.ValorAntigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ValorAntigo.HeaderText = "ValorAntigo";
            this.ValorAntigo.Name = "ValorAntigo";
            this.ValorAntigo.ReadOnly = true;
            this.ValorAntigo.Visible = false;
            this.ValorAntigo.Width = 128;
            // 
            // Venda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(811, 404);
            this.Controls.Add(this.boxContent);
            this.Name = "Venda";
            this.Text = "Venda";
            this.boxContent.ResumeLayout(false);
            this.boxEfetuarVenda.ResumeLayout(false);
            this.boxEfetuarVenda.PerformLayout();
            this.boxGridVendas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItemVenda)).EndInit();
            this.boxPagamento.ResumeLayout(false);
            this.boxPagamento.PerformLayout();
            this.boxItems.ResumeLayout(false);
            this.boxItems.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxContent;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblQuant;
        private System.Windows.Forms.ComboBox cmbTipoPagamento;
        private System.Windows.Forms.Button btnEfutarVenda;
        private System.Windows.Forms.Label lblTipoPagamento;
        private System.Windows.Forms.TextBox txtCodProd;
        private System.Windows.Forms.Label lblCodProd;
        private System.Windows.Forms.TextBox txtTroco;
        private System.Windows.Forms.Label lblTroco;
        private System.Windows.Forms.TextBox txtValorRecebido;
        private System.Windows.Forms.Label lblValorRecebido;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cmbVendedor;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.GroupBox boxEfetuarVenda;
        private System.Windows.Forms.GroupBox boxGridVendas;
        private System.Windows.Forms.GroupBox boxPagamento;
        private System.Windows.Forms.GroupBox boxItems;
        private System.Windows.Forms.Button btnRetirarItem;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.DataGridView gridItemVenda;
        private System.Windows.Forms.Label lblSegundaOpcao;
        private System.Windows.Forms.TextBox txtSegundaOpcao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDesconto;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorAntigo;
    }
}