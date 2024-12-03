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
    internal class ProjetoDAO



    {

        public Projeto GetProjetoById(int idProjeto)
        {
            Projeto projeto = null;

            using (SqlConnection conn = Conexao.GetConnection())
            {
                // Consulta SQL para buscar o projeto pelo ID
                string query = "SELECT IdProjeto, NomeProjeto FROM Projetos WHERE IdProjeto = @IdProjeto";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdProjeto", idProjeto);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Se houver algum registro, cria o objeto Projeto
                if (reader.Read())
                {
                    projeto = new Projeto
                    {
                        IdProjeto = Convert.ToInt32(reader["IdProjeto"]),
                        NomeProjeto = reader["NomeProjeto"].ToString()
                    };
                }

                conn.Close();
            }

            return projeto;
        }

        public List<Projeto> GetAllProjetos()
        {
            List<Projeto> projetos = new List<Projeto>();
            string query = "SELECT IdProjeto, NomeProjeto, DataInicio, DataFinal, ProfessorOrientador FROM Projetos";

            using (SqlConnection conn = Conexao.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    projetos.Add(new Projeto
                    {
                        IdProjeto = Convert.ToInt32(reader["IdProjeto"]),
                        NomeProjeto = reader["NomeProjeto"].ToString(),
                        DataInicio = Convert.ToDateTime(reader["DataInicio"]),
                        DataFinal = Convert.ToDateTime(reader["DataFinal"]),
                        ProfessorOrientador = reader["ProfessorOrientador"].ToString()
                    });
                }
            }

            return projetos;
        }

        public DataTable ObterTodosProjetos()
        {
            DataTable dt = new DataTable();

            try
            {
                // Query para buscar todos os projetos
                string query = "SELECT IdProjeto, NomeProjeto, Descricao FROM Projetos";

                using (SqlConnection conn = new SqlConnection("sua-string-de-conexao"))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt); // Preencher o DataTable com os dados obtidos
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter os projetos: {ex.Message}");
            }

            return dt;
        }


        public DataTable Pesquisar(string pesquisa)
        {
            DataTable dt = new DataTable();
            SqlConnection conexao = Conexao.GetConnection();  // Conexão com o banco de dados

            // Query para buscar projetos, se pesquisa for nula ou vazia, retorna todos os projetos
            string query = "";
            if (string.IsNullOrEmpty(pesquisa))
            {
                query = "SELECT IdProjeto, NomeProjeto, DataInicio, DataFinal, ProfessorOrientador FROM Projetos";
            }
            else
            {
                query = "SELECT IdProjeto, NomeProjeto, DataInicio, DataFinal, ProfessorOrientador FROM Projetos WHERE NomeProjeto LIKE @Pesquisa";
            }

            try
            {
                conexao.Open();
                SqlCommand comando = new SqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@Pesquisa", "%" + pesquisa + "%");  // Evitar SQL Injection

                SqlDataReader leitura = comando.ExecuteReader();

                // Adicionar as colunas ao DataTable
                dt.Columns.Add("IdProjeto");
                dt.Columns.Add("NomeProjeto");
                dt.Columns.Add("DataInicio");
                dt.Columns.Add("DataFinal");
                dt.Columns.Add("ProfessorOrientador");

                if (leitura.HasRows)
                {
                    // Preencher o DataTable com os dados dos projetos
                    while (leitura.Read())
                    {
                        DataRow row = dt.NewRow();
                        row["IdProjeto"] = leitura["IdProjeto"];
                        row["NomeProjeto"] = leitura["NomeProjeto"];
                        row["DataInicio"] = Convert.ToDateTime(leitura["DataInicio"]).ToString("dd/MM/yyyy");
                        row["DataFinal"] = Convert.ToDateTime(leitura["DataFinal"]).ToString("dd/MM/yyyy");
                        row["ProfessorOrientador"] = leitura["ProfessorOrientador"];
                        dt.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao pesquisar projetos: " + ex.Message);
            }
            finally
            {
                conexao.Close(); // Garantir que a conexão será fechada
            }

            return dt;  // Retorna o DataTable com os projetos encontrados
        }
    


        public void InserirProjeto(Projeto projeto)
        {
            using (SqlConnection connection = Conexao.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Projetos (NomeProjeto, DataInicio, DataFinal, ProfessorOrientador) VALUES (@NomeProjeto, @DataInicio, @DataFinal, @ProfessorOrientador)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@NomeProjeto", projeto.NomeProjeto);
                command.Parameters.AddWithValue("@DataInicio", projeto.DataInicio);
                command.Parameters.AddWithValue("@DataFinal", projeto.DataFinal);
                command.Parameters.AddWithValue("@ProfessorOrientador", projeto.ProfessorOrientador);

                command.ExecuteNonQuery();
            }
        }

        public void EditarProjeto(Projeto projeto)
        {
            string query = "UPDATE Projetos SET NomeProjeto = @NomeProjeto, DataInicio = @DataInicio, DataFinal = @DataFinal, ProfessorOrientador = @ProfessorOrientador WHERE IdProjeto = @IdProjeto";

            using (SqlConnection conn = Conexao.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdProjeto", projeto.IdProjeto);
                cmd.Parameters.AddWithValue("@NomeProjeto", projeto.NomeProjeto);
                cmd.Parameters.AddWithValue("@DataInicio", projeto.DataInicio);
                cmd.Parameters.AddWithValue("@DataFinal", projeto.DataFinal);
                cmd.Parameters.AddWithValue("@ProfessorOrientador", projeto.ProfessorOrientador);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletarProjeto(int idProjeto)
        {
            using (SqlConnection conn = Conexao.GetConnection())
            {
                string query = "DELETE FROM Projetos WHERE IdProjeto = @idProjeto";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idProjeto", idProjeto);

                try
                {
                    conn.Open();
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Projeto excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Projeto não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir projeto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para buscar todos os projetos cadastrados
        public List<Projeto> BuscarProjetos()
        {
            List<Projeto> projetos = new List<Projeto>();

            using (SqlConnection connection = Conexao.GetConnection())
            {
                connection.Open();
                string query = "SELECT IdProjeto, NomeProjeto, DataInicio, DataFinal, ProfessorOrientador FROM Projetos";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Projeto projeto = new Projeto
                    {
                        IdProjeto = Convert.ToInt32(reader["IdProjeto"]),
                        NomeProjeto = reader["NomeProjeto"].ToString(),
                        DataInicio = Convert.ToDateTime(reader["DataInicio"]),
                        DataFinal = Convert.ToDateTime(reader["DataFinal"]),
                        ProfessorOrientador = reader["ProfessorOrientador"].ToString()
                    };
                    projetos.Add(projeto);
                }
            }

            return projetos;
        }

        public bool EstaAssociadoAoProjeto(int idAluno, int idProjeto)
        {
            string query = "SELECT COUNT(1) FROM AlunosProjetos WHERE IdAluno = @IdAluno AND IdProjeto = @IdProjeto";

            using (SqlConnection conn = Conexao.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAluno", idAluno);
                cmd.Parameters.AddWithValue("@IdProjeto", idProjeto);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}
