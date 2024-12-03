namespace testes
{
    partial class FrmProjeto
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
            this.txtNomeProjeto = new System.Windows.Forms.TextBox();
            this.txtProfessorOrientador = new System.Windows.Forms.TextBox();
            this.dtpDataInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.dgvProjetos = new System.Windows.Forms.DataGridView();
            this.btnSalvarProjeto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjetos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomeProjeto
            // 
            this.txtNomeProjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtNomeProjeto.Location = new System.Drawing.Point(23, 34);
            this.txtNomeProjeto.Name = "txtNomeProjeto";
            this.txtNomeProjeto.Size = new System.Drawing.Size(199, 24);
            this.txtNomeProjeto.TabIndex = 0;
            // 
            // txtProfessorOrientador
            // 
            this.txtProfessorOrientador.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtProfessorOrientador.Location = new System.Drawing.Point(23, 90);
            this.txtProfessorOrientador.Name = "txtProfessorOrientador";
            this.txtProfessorOrientador.Size = new System.Drawing.Size(242, 24);
            this.txtProfessorOrientador.TabIndex = 2;
            // 
            // dtpDataInicio
            // 
            this.dtpDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtpDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicio.Location = new System.Drawing.Point(248, 34);
            this.dtpDataInicio.Name = "dtpDataInicio";
            this.dtpDataInicio.Size = new System.Drawing.Size(119, 24);
            this.dtpDataInicio.TabIndex = 3;
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFinal.Location = new System.Drawing.Point(386, 34);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(109, 24);
            this.dtpDataFinal.TabIndex = 4;
            // 
            // dgvProjetos
            // 
            this.dgvProjetos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjetos.Location = new System.Drawing.Point(22, 189);
            this.dgvProjetos.Name = "dgvProjetos";
            this.dgvProjetos.Size = new System.Drawing.Size(473, 212);
            this.dgvProjetos.TabIndex = 5;
            this.dgvProjetos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProjetos_CellContentDoubleClick);
            // 
            // btnSalvarProjeto
            // 
            this.btnSalvarProjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnSalvarProjeto.Location = new System.Drawing.Point(302, 86);
            this.btnSalvarProjeto.Name = "btnSalvarProjeto";
            this.btnSalvarProjeto.Size = new System.Drawing.Size(154, 31);
            this.btnSalvarProjeto.TabIndex = 6;
            this.btnSalvarProjeto.Text = "Cadastrar";
            this.btnSalvarProjeto.UseVisualStyleBackColor = true;
            this.btnSalvarProjeto.Click += new System.EventHandler(this.btnSalvarProjeto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nome do Projeto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(245, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Data de início";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(383, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Data de entrega";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(22, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Professor Orientador";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(22, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Pesquisar um Projeto";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtPesquisar.Location = new System.Drawing.Point(23, 157);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(472, 24);
            this.txtPesquisar.TabIndex = 11;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // FrmProjeto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 407);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalvarProjeto);
            this.Controls.Add(this.dgvProjetos);
            this.Controls.Add(this.dtpDataFinal);
            this.Controls.Add(this.dtpDataInicio);
            this.Controls.Add(this.txtProfessorOrientador);
            this.Controls.Add(this.txtNomeProjeto);
            this.MaximizeBox = false;
            this.Name = "FrmProjeto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Projetos";
            this.Load += new System.EventHandler(this.FrmProjeto_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjetos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeProjeto;
        private System.Windows.Forms.TextBox txtProfessorOrientador;
        private System.Windows.Forms.DateTimePicker dtpDataInicio;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.DataGridView dgvProjetos;
        private System.Windows.Forms.Button btnSalvarProjeto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPesquisar;
    }
}