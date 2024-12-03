using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testes.DAO;

namespace testes.Classes
{
    public class Usuarios
    {
        // Removemos a string de conexão direta

        public int Id
        {
            get; set;
        }
        public string Login
        {
            get; set;
        }
        public string Senha
        {
            get; set;
        }
        public bool Ativo
        {
            get; set;
        }

        public void Inserir()
        {
            string query = "INSERT INTO Usuarios (Login, Senha, Ativo) VALUES (@login, @senha, @ativo)";
            using (SqlConnection conexao = Conexao.GetConnection()) // Usando a conexão da classe Conexao
            {
                SqlCommand comando = new SqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@login", Login);
                comando.Parameters.AddWithValue("@senha", Senha);
                comando.Parameters.AddWithValue("@ativo", Ativo);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
        }

        public DataTable PreencherGrid()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT Id, Login, Ativo FROM Usuarios ORDER BY Id DESC";
            using (SqlConnection conexao = Conexao.GetConnection()) // Usando a conexão da classe Conexao
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conexao);
                try
                {
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao acessar os dados para preencher grid: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dataTable;
        }

        public DataTable Pesquisar(string pesquisa)
        {
            DataTable dataTable = new DataTable();
            string query = string.IsNullOrEmpty(pesquisa) ?
                "SELECT Login, Ativo FROM Usuarios ORDER BY Id DESC" :
                "SELECT Login, Ativo FROM Usuarios WHERE Login LIKE @pesquisa ORDER BY Id DESC";

            using (SqlConnection conexao = Conexao.GetConnection()) // Usando a conexão da classe Conexao
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conexao);
                adapter.SelectCommand.Parameters.AddWithValue("@pesquisa", "%" + pesquisa + "%");

                try
                {
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao acessar os dados para preencher grid: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dataTable;
        }

        public void Editar()
        {
            string query = "UPDATE Usuarios SET Login = @login, Senha = @senha, Ativo = @ativo WHERE Id = @id";
            using (SqlConnection conexao = Conexao.GetConnection()) // Usando a conexão da classe Conexao
            {
                SqlCommand comando = new SqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@login", Login);
                comando.Parameters.AddWithValue("@senha", Senha);
                comando.Parameters.AddWithValue("@ativo", Ativo);
                comando.Parameters.AddWithValue("@id", Id);

                conexao.Open();
                int resposta = comando.ExecuteNonQuery();
                if (resposta == 1)
                {
                    MessageBox.Show("Usuário Atualizado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Excluir()
        {
            string query = "DELETE FROM Usuarios WHERE Id = @Id";
            using (SqlConnection con = Conexao.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", this.Id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Usuário excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir o usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        public void PesquisarPorId(int id)
        {
            string query = "SELECT Id, Login, Senha, Ativo FROM Usuarios WHERE Id = @id ORDER BY Id DESC";
            using (SqlConnection conexao = Conexao.GetConnection()) // Usando a conexão da classe Conexao
            {
                SqlCommand comando = new SqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@id", id);

                conexao.Open();
                using (SqlDataReader resultado = comando.ExecuteReader())
                {
                    if (resultado.Read())
                    {
                        Id = resultado.GetInt32(0);
                        Login = resultado.GetString(1);
                        Senha = resultado.GetString(2);
                        Ativo = resultado.GetBoolean(3);
                    }
                }
            }
        }
    }
}
