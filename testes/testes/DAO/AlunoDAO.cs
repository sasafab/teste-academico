using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testes.Classes;

namespace testes.DAO
{
    internal class AlunoDAO
    {
        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Server=.\SQLEXPRESS;Database=Academia;Integrated Security=True");
        }

        // Inserir um aluno no banco de dados
        public void InserirAluno(Aluno aluno)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "INSERT INTO Alunos (Nome, Email) VALUES (@Nome, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
                cmd.Parameters.AddWithValue("@Email", aluno.Email);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        // Associar um aluno a um projeto (Tabela Alunos_Projetos)
        // Associar um aluno a um projeto (Tabela Alunos_Projetos)
        public void AssociarAlunoProjeto(int idAluno, int idProjeto)
        {
            // Verificar se a associação já existe
            string queryVerificarExistencia = "SELECT COUNT(*) FROM Alunos_Projetos WHERE IdAluno = @IdAluno AND IdProjeto = @IdProjeto";

            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmdVerificar = new SqlCommand(queryVerificarExistencia, conn);
                cmdVerificar.Parameters.AddWithValue("@IdAluno", idAluno);
                cmdVerificar.Parameters.AddWithValue("@IdProjeto", idProjeto);

                conn.Open();
                int count = (int)cmdVerificar.ExecuteScalar(); // Conta quantas vezes essa associação existe

                if (count == 0)  // Se a associação não existir, insere
                {
                    // Inserir a associação aluno - projeto
                    string queryInserirAssociacao = "INSERT INTO Alunos_Projetos (IdAluno, IdProjeto) VALUES (@IdAluno, @IdProjeto)";

                    SqlCommand cmdInserir = new SqlCommand(queryInserirAssociacao, conn);
                    cmdInserir.Parameters.AddWithValue("@IdAluno", idAluno);
                    cmdInserir.Parameters.AddWithValue("@IdProjeto", idProjeto);
                    cmdInserir.ExecuteNonQuery();

                    MessageBox.Show("Aluno cadastrado no projeto com sucesso!");
                }
                else
                {
                    // Caso a associação já exista, informamos o usuário
                    MessageBox.Show("Esse aluno já está associado a esse projeto.");
                }
            }
        }


        // Esse método será chamado na sequência, para inserção do aluno e depois associação ao projeto
        public void InserirAlunoEAssociarAoProjeto(Aluno aluno, int idProjeto)
        {
            using (SqlConnection conn = GetConnection())
            {
                // Verificar se o aluno já existe no banco pelo nome
                string queryVerificarAluno = "SELECT IdAluno FROM Alunos WHERE Nome = @Nome";
                SqlCommand cmdVerificarAluno = new SqlCommand(queryVerificarAluno, conn);
                cmdVerificarAluno.Parameters.AddWithValue("@Nome", aluno.Nome);

                conn.Open();
                object result = cmdVerificarAluno.ExecuteScalar(); // Retorna o Id do aluno, se existir

                if (result != null)  // O aluno já existe no banco
                {
                    int idAlunoExistente = Convert.ToInt32(result);

                    // Verificar se o aluno já está associado ao projeto
                    string queryVerificarAssociacao = "SELECT COUNT(*) FROM Alunos_Projetos WHERE IdAluno = @IdAluno AND IdProjeto = @IdProjeto";
                    SqlCommand cmdVerificarAssociacao = new SqlCommand(queryVerificarAssociacao, conn);
                    cmdVerificarAssociacao.Parameters.AddWithValue("@IdAluno", idAlunoExistente);
                    cmdVerificarAssociacao.Parameters.AddWithValue("@IdProjeto", idProjeto);

                    int count = (int)cmdVerificarAssociacao.ExecuteScalar();

                    if (count > 0) // O aluno já está associado ao projeto
                    {
                        MessageBox.Show("Esse aluno já está associado a este projeto.");
                    }
                    else // O aluno está em outro projeto, então associamos ao novo projeto
                    {
                        // Associar o aluno ao novo projeto
                        string queryAssociarAluno = "INSERT INTO Alunos_Projetos (IdAluno, IdProjeto) VALUES (@IdAluno, @IdProjeto)";
                        SqlCommand cmdAssociarAluno = new SqlCommand(queryAssociarAluno, conn);
                        cmdAssociarAluno.Parameters.AddWithValue("@IdAluno", idAlunoExistente);
                        cmdAssociarAluno.Parameters.AddWithValue("@IdProjeto", idProjeto);
                        cmdAssociarAluno.ExecuteNonQuery();

                        MessageBox.Show("Aluno associado ao novo projeto com sucesso!");
                    }
                }
                else // O aluno não existe no banco, então insere o aluno e associa ao projeto
                {
                    // Inserir o novo aluno
                    string queryInserirAluno = "INSERT INTO Alunos (Nome, Email) VALUES (@Nome, @Email)";
                    SqlCommand cmdInserirAluno = new SqlCommand(queryInserirAluno, conn);
                    cmdInserirAluno.Parameters.AddWithValue("@Nome", aluno.Nome);
                    cmdInserirAluno.Parameters.AddWithValue("@Email", aluno.Email);
                    cmdInserirAluno.ExecuteNonQuery();

                    // Obter o ID do aluno inserido
                    int idAlunoInserido = ObterUltimoIdAlunoInserido();

                    // Associar o aluno ao projeto
                    string queryAssociarAluno = "INSERT INTO Alunos_Projetos (IdAluno, IdProjeto) VALUES (@IdAluno, @IdProjeto)";
                    SqlCommand cmdAssociarAluno = new SqlCommand(queryAssociarAluno, conn);
                    cmdAssociarAluno.Parameters.AddWithValue("@IdAluno", idAlunoInserido);
                    cmdAssociarAluno.Parameters.AddWithValue("@IdProjeto", idProjeto);
                    cmdAssociarAluno.ExecuteNonQuery();

                    MessageBox.Show("Aluno cadastrado e associado ao projeto com sucesso!");
                }

                conn.Close();
            }
        }

        


        // Método para pegar o último id inserido de aluno (pode ser otimizado conforme o contexto)
        private int ObterUltimoIdAlunoInserido()
        {
            int idAluno = 0;

            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT MAX(IdAluno) FROM Alunos";  // Obter o último id inserido
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                idAluno = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }

            return idAluno;
        }



        public DataTable ObterAlunosPorProjeto()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = GetConnection())
            {
                string query = @"
        SELECT p.NomeProjeto, a.Nome
        FROM Projetos p
        JOIN Alunos_Projetos ap ON p.IdProjeto = ap.IdProjeto
        JOIN Alunos a ON ap.IdAluno = a.IdAluno
        ORDER BY p.NomeProjeto";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Adiciona as colunas na DataTable
                dt.Columns.Add("NomeProjeto");
                dt.Columns.Add("Alunos");

                // Processar os dados lidos
                while (reader.Read())
                {
                    string nomeProjeto = reader["NomeProjeto"].ToString();
                    string nomeAluno = reader["Nome"].ToString();

                    // Verifica se o projeto já está na DataTable
                    DataRow[] rows = dt.Select($"NomeProjeto = '{nomeProjeto}'");

                    if (rows.Length > 0)
                    {
                        // Se já existe, adiciona o nome do aluno à célula de Alunos
                        rows[0]["Alunos"] = rows[0]["Alunos"] + ", " + nomeAluno;
                    }
                    else
                    {
                        // Se não existe, cria uma nova linha
                        dt.Rows.Add(nomeProjeto, nomeAluno);
                    }
                }

                conn.Close();
            }

            return dt;
        }



        // Obter todos os alunos cadastrados
        public List<Aluno> ObterTodosAlunos()
        {
            List<Aluno> alunos = new List<Aluno>();

            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT IdAluno, Nome, Email FROM Alunos";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Aluno aluno = new Aluno
                    {
                        IdAluno = Convert.ToInt32(reader["IdAluno"]),
                        Nome = reader["Nome"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                    alunos.Add(aluno);
                }

                conn.Close();
            }

            return alunos;
        }

        public void RemoverAssociacaoAlunoProjeto(int idAluno, int idProjeto)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "DELETE FROM Alunos_Projetos WHERE IdAluno = @IdAluno AND IdProjeto = @IdProjeto";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAluno", idAluno);
                cmd.Parameters.AddWithValue("@IdProjeto", idProjeto);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public DataTable ObterAlunosPorProjeto(int idProjeto)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = GetConnection())
            {
                string query = @"
            SELECT a.IdAluno, a.Nome
            FROM Alunos a
            JOIN Alunos_Projetos ap ON a.IdAluno = ap.IdAluno
            WHERE ap.IdProjeto = @IdProjeto";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdProjeto", idProjeto);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
                conn.Close();
            }

            return dt;
        }


        public void RemoverAlunoDoProjeto(int idAluno, int idProjeto)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = @"
            DELETE FROM Alunos_Projetos
            WHERE IdAluno = @IdAluno AND IdProjeto = @IdProjeto";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAluno", idAluno);
                cmd.Parameters.AddWithValue("@IdProjeto", idProjeto);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }



        public List<Aluno> ObterAlunosNaoAssociados(int idProjeto)
        {
            List<Aluno> alunos = new List<Aluno>();

            using (SqlConnection conn = GetConnection())
            {
                string query = @"
            SELECT IdAluno, Nome
            FROM Alunos
            WHERE IdAluno NOT IN (SELECT IdAluno FROM Alunos_Projetos WHERE IdProjeto = @IdProjeto)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdProjeto", idProjeto);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    alunos.Add(new Aluno
                    {
                        IdAluno = Convert.ToInt32(reader["IdAluno"]),
                        Nome = reader["Nome"].ToString()
                    });
                }

                conn.Close();
            }

            return alunos;
        }


        // Método para associar um aluno a um projeto
        public void AssociarAlunoAProjeto(int idAluno, int idProjeto)
        {
            string query = "INSERT INTO AlunosProjetos (IdAluno, IdProjeto) VALUES (@IdAluno, @IdProjeto)";

            using (SqlConnection conn = Conexao.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAluno", idAluno);
                cmd.Parameters.AddWithValue("@IdProjeto", idProjeto);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Método para desassociar um aluno de um projeto
        public void DesassociarAlunoDeProjeto(int idAluno, int idProjeto)
        {
            string query = "DELETE FROM AlunosProjetos WHERE IdAluno = @IdAluno AND IdProjeto = @IdProjeto";

            using (SqlConnection conn = Conexao.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAluno", idAluno);
                cmd.Parameters.AddWithValue("@IdProjeto", idProjeto);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }






    }
}
