namespace artesanatoCapixaba
{
    partial class Caixa
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
            this.boxCaixa = new System.Windows.Forms.GroupBox();
            this.btnFecharCaixa = new System.Windows.Forms.Button();
            this.btnAbrirCaixa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDinheiroCaixa = new System.Windows.Forms.TextBox();
            this.boxCaixa.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxCaixa
            // 
            this.boxCaixa.Controls.Add(this.btnFecharCaixa);
            this.boxCaixa.Controls.Add(this.btnAbrirCaixa);
            this.boxCaixa.Controls.Add(this.label1);
            this.boxCaixa.Controls.Add(this.txtDinheiroCaixa);
            this.boxCaixa.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxCaixa.Location = new System.Drawing.Point(8, -2);
            this.boxCaixa.Name = "boxCaixa";
            this.boxCaixa.Size = new System.Drawing.Size(336, 124);
            this.boxCaixa.TabIndex = 0;
            this.boxCaixa.TabStop = false;
            this.boxCaixa.Text = "Caixa";
            // 
            // btnFecharCaixa
            // 
            this.btnFecharCaixa.BackColor = System.Drawing.Color.Crimson;
            this.btnFecharCaixa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFecharCaixa.Location = new System.Drawing.Point(181, 81);
            this.btnFecharCaixa.Name = "btnFecharCaixa";
            this.btnFecharCaixa.Size = new System.Drawing.Size(140, 31);
            this.btnFecharCaixa.TabIndex = 3;
            this.btnFecharCaixa.Text = "Fechar Caixa";
            this.btnFecharCaixa.UseVisualStyleBackColor = false;
            this.btnFecharCaixa.Click += new System.EventHandler(this.btnFecharCaixa_Click);
            // 
            // btnAbrirCaixa
            // 
            this.btnAbrirCaixa.BackColor = System.Drawing.Color.Lime;
            this.btnAbrirCaixa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirCaixa.Location = new System.Drawing.Point(21, 81);
            this.btnAbrirCaixa.Name = "btnAbrirCaixa";
            this.btnAbrirCaixa.Size = new System.Drawing.Size(140, 31);
            this.btnAbrirCaixa.TabIndex = 2;
            this.btnAbrirCaixa.Text = "Abrir Caixa";
            this.btnAbrirCaixa.UseVisualStyleBackColor = false;
            this.btnAbrirCaixa.Click += new System.EventHandler(this.btnAbrirCaixa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dinheiro no Caixa:";
            // 
            // txtDinheiroCaixa
            // 
            this.txtDinheiroCaixa.Location = new System.Drawing.Point(181, 33);
            this.txtDinheiroCaixa.Name = "txtDinheiroCaixa";
            this.txtDinheiroCaixa.Size = new System.Drawing.Size(140, 26);
            this.txtDinheiroCaixa.TabIndex = 0;
            this.txtDinheiroCaixa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDinheiroCaixa_KeyPress);
            // 
            // Caixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(352, 131);
            this.Controls.Add(this.boxCaixa);
            this.Name = "Caixa";
            this.Text = "Artesanato Capixaba -  Caixa";
            this.boxCaixa.ResumeLayout(false);
            this.boxCaixa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxCaixa;
        private System.Windows.Forms.Button btnFecharCaixa;
        private System.Windows.Forms.Button btnAbrirCaixa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDinheiroCaixa;
    }
}