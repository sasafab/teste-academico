using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using testes.Classes;
using testes.DAO;
using testes.Editar;

namespace testes
{
    public partial class FrmProjeto : Form
    {
        private ProjetoDAO projetoDAO = new ProjetoDAO(); // Instancia o DAO de projetos


        private void FrmProjeto_Load(object sender, EventArgs e)
        {
            AtualizarDataGridView();  // Chama o método para carregar os dados no DataGridView ao iniciar o formulário
        }
        public FrmProjeto()
        {
            InitializeComponent();
            //nao permite que o user redimensione a janela
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //atualiza o grid com o banco de dados assim que entrar no programa
            this.Load += new EventHandler(FrmProjeto_Load);
        }

        // Evento de clique do botão para salvar um novo projeto
        private void btnSalvarProjeto_Click(object sender, EventArgs e)
        {
            string nomeProjeto = txtNomeProjeto.Text;
            DateTime dataInicio = dtpDataInicio.Value;
            DateTime dataFinal = dtpDataFinal.Value;
            string professorOrientador = txtProfessorOrientador.Text;

            // Cria o objeto Projeto usando as informações do formulário
            Projeto projeto = new Projeto
            {
                NomeProjeto = nomeProjeto,
                DataInicio = dataInicio,
                DataFinal = dataFinal,
                ProfessorOrientador = professorOrientador
            };

            try
            {
                // Chama o método do DAO para inserir o projeto no banco de dados
                projetoDAO.InserirProjeto(projeto);
                MessageBox.Show("Projeto cadastrado com sucesso!");
                AtualizarDataGridView(); // Atualiza o DataGridView após o cadastro
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar projeto: " + ex.Message);
            }
        }

        // Evento de carregamento do formulário
        private void FormProjeto_Load(object sender, EventArgs e)
        {
            AtualizarDataGridView(); // Carrega os projetos cadastrados ao abrir o formulário
        }

        // Método para atualizar o DataGridView com os projetos cadastrados
        private void AtualizarDataGridView()
        {
            try
            {
                // Chama o método do DAO para buscar todos os projetos cadastrados
                List<Projeto> projetos = projetoDAO.BuscarProjetos();

                // Cria uma lista para armazenar as informações a serem exibidas no DataGridView
                DataTable dt = new DataTable();
                dt.Columns.Add("IdProjeto", typeof(int));
                dt.Columns.Add("NomeProjeto", typeof(string));
                dt.Columns.Add("DataInicio", typeof(DateTime));
                dt.Columns.Add("DataFinal", typeof(DateTime));
                dt.Columns.Add("ProfessorOrientador", typeof(string));

                // Preenche a DataTable com os dados dos projetos
                foreach (var projeto in projetos)
                {
                    dt.Rows.Add(projeto.IdProjeto, projeto.NomeProjeto, projeto.DataInicio, projeto.DataFinal, projeto.ProfessorOrientador);
                }

                // Atualiza o DataGridView com os dados
                dgvProjetos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar projetos: " + ex.Message);
            }
            //redimensiona a largura das colunas (deixa ai)
            dgvProjetos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dgvProjetos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtém o ID do projeto da célula selecionada
                int idProjeto = Convert.ToInt32(dgvProjetos.Rows[e.RowIndex].Cells[0].Value);

                // Abre o formulário de edição, passando o ID do projeto
                FrmEditarProjeto editarProjetoForm = new FrmEditarProjeto(idProjeto);
                editarProjetoForm.ShowDialog();

                // Após o fechamento do formulário de edição, atualiza o DataGridView
                AtualizarDataGridView();
            }
        }

        private void FrmProjeto_Load_1(object sender, EventArgs e)
        {

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string pesquisa = txtPesquisar.Text;  // Onde txtPesquisar é o TextBox para a pesquisa
            ProjetoDAO projetoDAO = new ProjetoDAO();
            DataTable dt = projetoDAO.Pesquisar(pesquisa);

            dgvProjetos.DataSource = dt;  // dgvProjetos é o seu DataGridView
        }
    }
}
