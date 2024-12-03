using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testes.Classes;
using testes.DAO;
using testes.Editar;

namespace testes
{
    public partial class FormAluno : Form
    {
        private AlunoDAO alunoDAO;
        private ProjetoDAO projetoDAO;

        public FormAluno()
        {
            InitializeComponent();
            alunoDAO = new AlunoDAO();
            projetoDAO = new ProjetoDAO();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Criar o aluno com os dados do formulário
                Aluno aluno = new Aluno
                {
                    Nome = txtNomeAluno.Text,
                    Email = txtEmailAluno.Text
                };

                // Obter o Id do Projeto selecionado na ComboBox
                int idProjetoSelecionado = Convert.ToInt32(cmbProjetos.SelectedValue);

                // Inserir aluno e associá-lo ao projeto
                alunoDAO.InserirAlunoEAssociarAoProjeto(aluno, idProjetoSelecionado);

                // Atualizar o grid para refletir as novas associações
                CarregarGridAssociacao();

                // Limpar campos após salvar
                txtNomeAluno.Clear();
                txtEmailAluno.Clear();
                cmbProjetos.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void CarregarProjetos()
        {
            try
            {
                // Limpar o DataGridView antes de adicionar novos dados
                dgvAssociacao.Rows.Clear();

                // Obter a lista de projetos do banco de dados
                DataTable dtProjetos = projetoDAO.ObterTodosProjetos();

                // Preencher o DataGridView com os projetos
                foreach (DataRow row in dtProjetos.Rows)
                {
                    dgvAssociacao.Rows.Add(
                        row["IdProjeto"],     // Coluna 1: ID do Projeto
                        row["NomeProjeto"]
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os projetos: {ex.Message}");
            }
        }


        private void CarregarGridAssociacao()
        {
            


            try
            {
                // Obter a associação de alunos e projetos
                DataTable dt = alunoDAO.ObterAlunosPorProjeto();
                dgvAssociacao.DataSource = dt;

                // Ajustar as colunas para se esticarem conforme o tamanho disponível (sem perder a auto-dimensionação)
                dgvAssociacao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Ajustar as linhas para auto-dimensionamento com base no conteúdo
                dgvAssociacao.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Habilitar quebra de linha no texto das células
                dgvAssociacao.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o grid: {ex.Message}");
            }
        }

        private void FormAluno_Load(object sender, EventArgs e)
        {
            try
            {
                // Carregar os projetos na ComboBox
                List<Projeto> projetos = projetoDAO.GetAllProjetos();
                cmbProjetos.DataSource = projetos;
                cmbProjetos.DisplayMember = "NomeProjeto";
                cmbProjetos.ValueMember = "IdProjeto";

                // Carregar o Grid com a associação de alunos e projetos
                CarregarGridAssociacao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o formulário: {ex.Message}");
            }
        }

        

        private void CarregarAlunosAssociados(int idProjetoSelecionado)
        {
            try
            {
                // Carregar alunos associados ao projeto
                DataTable dt = alunoDAO.ObterAlunosPorProjeto(idProjetoSelecionado);

                // Atribuir os dados ao DataGridView
                dgvAssociacao.DataSource = dt;

                // Caso necessário, esconder a coluna IdProjeto
                dgvAssociacao.Columns["IdProjeto"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar alunos associados: {ex.Message}");
            }
        }



    }
}
