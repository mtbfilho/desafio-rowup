using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RowUpTest.Models
{
    public class RowupBD
    {
        public static List<Usuario> GetUsuarios(string ordenacao = "asc")
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RowupConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"select Id, Nome from dbo.Usuario order by Nome {ordenacao}";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Usuario> usuarios = new List<Usuario>();

                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario();
                            usuarios.Add(usuario);

                            usuario.Id = (int)reader["Id"];
                            usuario.Nome = (string)reader["Nome"];
                        }

                        reader.Close();

                        return usuarios;
                    }
                }
            }
        }

        public static void Inserir(Usuario usuario)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RowupConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into dbo.Usuario (Nome) values (@Nome)";

                    SqlParameter parameter = new SqlParameter("@Nome", SqlDbType.VarChar, 20);
                    parameter.Value = usuario.Nome;

                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}