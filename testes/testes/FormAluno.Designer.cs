namespace testes
{
    partial class FormAluno
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
            this.components = new System.ComponentModel.Container();
            this.txtNomeAluno = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtEmailAluno = new System.Windows.Forms.TextBox();
            this.cmbProjetos = new System.Windows.Forms.ComboBox();
            this.dgvAssociacao = new System.Windows.Forms.DataGridView();
            this.btnSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssociacao)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomeAluno
            // 
            this.txtNomeAluno.Location = new System.Drawing.Point(29, 27);
            this.txtNomeAluno.Name = "txtNomeAluno";
            this.txtNomeAluno.Size = new System.Drawing.Size(226, 20);
            this.txtNomeAluno.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtEmailAluno
            // 
            this.txtEmailAluno.Location = new System.Drawing.Point(29, 69);
            this.txtEmailAluno.Name = "txtEmailAluno";
            this.txtEmailAluno.Size = new System.Drawing.Size(226, 20);
            this.txtEmailAluno.TabIndex = 2;
            // 
            // cmbProjetos
            // 
            this.cmbProjetos.FormattingEnabled = true;
            this.cmbProjetos.Location = new System.Drawing.Point(284, 26);
            this.cmbProjetos.Name = "cmbProjetos";
            this.cmbProjetos.Size = new System.Drawing.Size(147, 21);
            this.cmbProjetos.TabIndex = 3;
            // 
            // dgvAssociacao
            // 
            this.dgvAssociacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssociacao.Location = new System.Drawing.Point(19, 103);
            this.dgvAssociacao.Name = "dgvAssociacao";
            this.dgvAssociacao.Size = new System.Drawing.Size(450, 203);
            this.dgvAssociacao.TabIndex = 4;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(288, 53);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(159, 35);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "button1";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // FormAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 324);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.dgvAssociacao);
            this.Controls.Add(this.cmbProjetos);
            this.Controls.Add(this.txtEmailAluno);
            this.Controls.Add(this.txtNomeAluno);
            this.Name = "FormAluno";
            this.Text = "FormAluno";
            this.Load += new System.EventHandler(this.FormAluno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssociacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeAluno;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtEmailAluno;
        private System.Windows.Forms.ComboBox cmbProjetos;
        private System.Windows.Forms.DataGridView dgvAssociacao;
        private System.Windows.Forms.Button btnSalvar;
    }
}