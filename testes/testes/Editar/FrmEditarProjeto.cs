using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testes.Classes;
using testes.DAO;

namespace testes.Editar
{
    public partial class FrmEditarProjeto : Form
    {
        private ProjetoDAO projetoDAO;
        private int idProjeto;

        public FrmEditarProjeto(int projetoId)
        {
            InitializeComponent();
            projetoDAO = new ProjetoDAO();
            idProjeto = projetoId;
            CarregarProjeto();
        }

        private void CarregarProjeto()
        {
            List<Projeto> projetos = projetoDAO.GetAllProjetos();
            Projeto projeto = projetos.Find(p => p.IdProjeto == idProjeto);

            if (projeto != null)
            {
                txtNomeProjeto.Text = projeto.NomeProjeto;
                dtpDataInicio.Value = projeto.DataInicio;
                dtpDataFinal.Value = projeto.DataFinal;
                txtProfessorOrientador.Text = projeto.ProfessorOrientador;
            }
        }

        private void btnEditarProjeto_Click(object sender, EventArgs e)
        {
            Projeto projeto = new Projeto
            {
                IdProjeto = idProjeto,
                NomeProjeto = txtNomeProjeto.Text,
                DataInicio = dtpDataInicio.Value,
                DataFinal = dtpDataFinal.Value,
                ProfessorOrientador = txtProfessorOrientador.Text
            };

            projetoDAO.EditarProjeto(projeto);
            MessageBox.Show("Projeto atualizado com sucesso!");
            this.Close();
        }

        private void btnDeletProjeto_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Tem certeza que deseja excluir este projeto?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Chama o método DeletarProjeto para excluir o projeto
                projetoDAO.DeletarProjeto(idProjeto);
                this.Close(); // Fecha o formulário após a exclusão
            }
        }

        private void FrmEditarProjeto_Load(object sender, EventArgs e)
        {

        }
    }
}

