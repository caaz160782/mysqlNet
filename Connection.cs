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

        public void InsertDb(string nombre){
             try
            {
                using var con = new MySqlConnection(Conectando());
                con.Open();

                var cmd = new MySqlCommand();
                cmd.Connection=con;
                cmd.CommandText= $"insert into test (nombre) values ('{nombre}');";
                cmd.ExecuteNonQuery();
                con.Close();
          
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

         public void InsertDb2(string nombre){
             try
            {
                using var con = new MySqlConnection(Conectando());
                con.Open();
                string sql = "insert into test (nombre) values (@nombre);";
                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nombre",nombre);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                con.Close();
          
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

          public void updateDb(string nombre, int id){
             try
            {
                using var con = new MySqlConnection(Conectando());
                con.Open();
                string sql = "update test set nombre=@nombre where id=@id;";
                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nombre",nombre);
                cmd.Parameters.AddWithValue("@id",id);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                con.Close();
          
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

            public void DeleteDb(int id){
             try
            {
                using var con = new MySqlConnection(Conectando());
                con.Open();
                string sql = "delete from test  where id=@id;";
                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id",id);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                con.Close();
          
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
