using System;
using System.Data.SqlClient;
using testes.DAO; // Adicionando o namespace de Conexao

namespace testes.Classes
{
    public class Login
    {
        // Propriedades para o usuário e a senha
        public string Usuario
        {
            get; set;
        }
        public string Senha
        {
            get; set;
        }

        // Método para validar o login
        public bool Logar()
        {
            string query = "SELECT Login, Id FROM usuarios WHERE Senha = @senha AND Login = @login";

            // Usando `using` para garantir o fechamento da conexão com Conexao.GetConnection()
            using (SqlConnection conexao = Conexao.GetConnection())  // Aqui foi alterado
            {
                SqlCommand comando = new SqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@senha", Senha);
                comando.Parameters.AddWithValue("@login", Usuario);

                try
                {
                    conexao.Open();
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        // Retorna true se houver registros
                        return resultado.HasRows;
                    }
                }
                catch (Exception ex)
                {
                    // Opcional: registrar o erro para debug
                    Console.WriteLine("Erro ao tentar logar: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
