using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace cloudy
{
    public class DataAccess
    {
        MySqlConnection conn;
        MySqlCommand command;
        MySqlDataReader reader;

        public DataAccess()
        {
            string connStr = "server=localhost; user=admin; password=; database=cloudy; port=3306;";
            conn = new MySqlConnection(connStr);
            command = new MySqlCommand();
            command.Connection = conn;

            command.Connection.Open();
        }

        private List<Weather> GetList(string commandText)
        {
            try
            {
                command.CommandText = commandText;

                reader = command.ExecuteReader();

                List<Weather> result = new List<Weather> { };

                while (reader.Read())
                {
                    result.Add(new Weather(reader.GetString(0), reader.GetInt16(1), reader.GetString(2), reader.GetInt32(3), reader.GetBoolean(4) == false ? "Нема" : "Є", reader.GetUInt32(5)));
                }

                reader.Close();
                if (result.Count == 0)
                {
                    return null;
                }
                else
                {
                    return result;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Weather> GetWeathers()
        {
            return GetList("SELECT * FROM cloudy;");
        }

        public int AddToBase(Weather weather)
        {
            try
            {
                command.CommandText = $"SELECT * FROM cloudy WHERE city = '{weather.city}' AND date = {weather.day} " +
                    $"AND month = '{weather.month}';";

                reader = command.ExecuteReader();

                if (!reader.HasRows)
                {
                    reader.Close();
                    command.CommandText = "INSERT INTO cloudy(city,date,month,temperature,precipitation,pressure) VALUES(@city, @date, @month, @temperature, @precipitation, @pressure)";

                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@city", weather.city);
                    command.Parameters.AddWithValue("@date", weather.day);
                    command.Parameters.AddWithValue("@month", weather.month);
                    command.Parameters.AddWithValue("@temperature", weather.temperature);
                    command.Parameters.AddWithValue("@precipitation", weather.precipitation == "Є" ? true : false);
                    command.Parameters.AddWithValue("@pressure", weather.pressure);

                    command.ExecuteNonQuery();

                    return 1;
                }
                else
                {
                    reader.Close();
                    return -1;
                }
                
            }
            catch
            {
                reader.Close();
                return 0;
            }
        }

        public bool DeleteFromBase(Weather weather)
        {
            try
            {
                command.CommandText = $"DELETE FROM cloudy WHERE city = '{weather.city}' AND date = {weather.day} " +
                    $"AND month = '{weather.month}' AND temperature = {weather.temperature} AND precipitation = {(weather.precipitation == "Є" ? true : false)} " +
                    $"AND pressure = {weather.pressure};";

                if (command.ExecuteNonQuery() == 0)
                {
                    throw new Exception();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Weather> SelectXY(string city, string month)
        {
            try
            {
                string commandText;
                if (city != String.Empty && month != String.Empty)
                {
                    commandText = $"SELECT * FROM cloudy WHERE city = '{city}' AND month = '{month}';";
                }
                else if (city != String.Empty)
                {
                    commandText = $"SELECT * FROM cloudy WHERE city = '{city}';";
                }
                else
                {
                    throw new Exception();
                }

                return GetList(commandText);
            }
            catch
            {
                return null;
            }
        }

        public List<Weather> GetRainData()
        {
            return GetList($"SELECT * FROM cloudy WHERE temperature > 0 AND precipitation = 1;");
        }
    }
}
