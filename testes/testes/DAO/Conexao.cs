using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testes.DAO
{
    internal class Conexao
    {
        private static string connectionString = @"Server=.\SQLEXPRESS;Database=Academia;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
