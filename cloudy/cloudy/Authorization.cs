using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace cloudy
{
    public class Authorization
    {
        public bool loged_in { get; set; }

        MySqlConnection conn;
        MySqlCommand command;
        MySqlDataReader reader;

        public Authorization()
        {
            string connStr = "server=localhost; user=admin; password=; database=cloudy; port=3306;";
            conn = new MySqlConnection(connStr);
            command = new MySqlCommand();
            command.Connection = conn;

            command.Connection.Open();
        }

        public bool CheckLogIn(string login, string password)
        {
            try
            {
                command.CommandText = $"SELECT * FROM editors WHERE login = '{login}' AND password = '{password}';";

                reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
