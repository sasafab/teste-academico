namespace testes.Editar
{
    partial class FrmEditarProjeto
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditarProjeto = new System.Windows.Forms.Button();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpDataInicio = new System.Windows.Forms.DateTimePicker();
            this.txtProfessorOrientador = new System.Windows.Forms.TextBox();
            this.txtNomeProjeto = new System.Windows.Forms.TextBox();
            this.btnDeletProjeto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(29, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Professor Orientador";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(30, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Data de entrega";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(30, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Data de início";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(30, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nome do Projeto";
            // 
            // btnEditarProjeto
            // 
            this.btnEditarProjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnEditarProjeto.Location = new System.Drawing.Point(32, 288);
            this.btnEditarProjeto.Name = "btnEditarProjeto";
            this.btnEditarProjeto.Size = new System.Drawing.Size(120, 39);
            this.btnEditarProjeto.TabIndex = 15;
            this.btnEditarProjeto.Text = "Editar";
            this.btnEditarProjeto.UseVisualStyleBackColor = true;
            this.btnEditarProjeto.Click += new System.EventHandler(this.btnEditarProjeto_Click);
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtpDataFinal.Location = new System.Drawing.Point(32, 244);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(292, 24);
            this.dtpDataFinal.TabIndex = 14;
            // 
            // dtpDataInicio
            // 
            this.dtpDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtpDataInicio.Location = new System.Drawing.Point(32, 183);
            this.dtpDataInicio.Name = "dtpDataInicio";
            this.dtpDataInicio.Size = new System.Drawing.Size(298, 24);
            this.dtpDataInicio.TabIndex = 13;
            // 
            // txtProfessorOrientador
            // 
            this.txtProfessorOrientador.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtProfessorOrientador.Location = new System.Drawing.Point(32, 119);
            this.txtProfessorOrientador.Name = "txtProfessorOrientador";
            this.txtProfessorOrientador.Size = new System.Drawing.Size(298, 24);
            this.txtProfessorOrientador.TabIndex = 12;
            // 
            // txtNomeProjeto
            // 
            this.txtNomeProjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtNomeProjeto.Location = new System.Drawing.Point(32, 54);
            this.txtNomeProjeto.Name = "txtNomeProjeto";
            this.txtNomeProjeto.Size = new System.Drawing.Size(232, 24);
            this.txtNomeProjeto.TabIndex = 11;
            // 
            // btnDeletProjeto
            // 
            this.btnDeletProjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnDeletProjeto.Location = new System.Drawing.Point(186, 288);
            this.btnDeletProjeto.Name = "btnDeletProjeto";
            this.btnDeletProjeto.Size = new System.Drawing.Size(138, 39);
            this.btnDeletProjeto.TabIndex = 20;
            this.btnDeletProjeto.Text = "Deletar Projeto";
            this.btnDeletProjeto.UseVisualStyleBackColor = true;
            this.btnDeletProjeto.Click += new System.EventHandler(this.btnDeletProjeto_Click);
            // 
            // FrmEditarProjeto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 355);
            this.Controls.Add(this.btnDeletProjeto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditarProjeto);
            this.Controls.Add(this.dtpDataFinal);
            this.Controls.Add(this.dtpDataInicio);
            this.Controls.Add(this.txtProfessorOrientador);
            this.Controls.Add(this.txtNomeProjeto);
            this.Name = "FrmEditarProjeto";
            this.Text = "FrmEditarProjeto";
            this.Load += new System.EventHandler(this.FrmEditarProjeto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditarProjeto;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.DateTimePicker dtpDataInicio;
        private System.Windows.Forms.TextBox txtProfessorOrientador;
        private System.Windows.Forms.TextBox txtNomeProjeto;
        private System.Windows.Forms.Button btnDeletProjeto;
    }
}