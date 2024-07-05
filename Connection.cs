using MySql.Data.MySqlClient;
using System;

namespace ConnectionMysql
{
    class Conectar
    {
        public static string Conectando()
        {
         return @"server=localhost;port=3306;userid=net;password=password;database=pruebas;SslMode=None";
        }

        public void ReadBD()
        {
            try
            {
                using var con = new MySqlConnection(Conectando());
                con.Open();

                string sql = "SELECT id, nombre, fecha FROM test ORDER BY id DESC";
                using var cmd = new MySqlCommand(sql, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine($"ID: {rdr.GetInt32(0)}, Name: {rdr.GetString(1)}, Date: {rdr.GetDateTime(2)}");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL error: {ex.Message}");
            }
            catch (System.Security.Authentication.AuthenticationException ex)
            {
                Console.WriteLine($"Authentication error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
