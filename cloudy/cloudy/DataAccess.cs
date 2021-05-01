using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace cloudy
{
    class DataAccess
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

        public List<Weather> GetWeathers()
        {
            try
            {
                command.CommandText = "SELECT * FROM cloudy;";

                reader = command.ExecuteReader();

                List<Weather> weathers = new List<Weather> { };

                while (reader.Read())
                {
                    weathers.Add(new Weather(reader.GetString(0), reader.GetInt16(1), reader.GetString(2), reader.GetInt32(3), reader.GetBoolean(4) == false ? "Нема" : "Є", reader.GetUInt32(5)));
                }

                reader.Close();
                if (weathers.Count == 0)
                {
                    return null;
                }
                else
                {
                    return weathers;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool AddToBase(Weather weather)
        {
            try
            {

                command.CommandText = "INSERT INTO cloudy(city,date,month,temperature,precipitation,pressure) VALUES(@city, @date, @month, @temperature, @precipitation, @pressure)";

                command.Parameters.Clear();

                command.Parameters.AddWithValue("@city", weather.city);
                command.Parameters.AddWithValue("@date", weather.day);
                command.Parameters.AddWithValue("@month", weather.month);
                command.Parameters.AddWithValue("@temperature", weather.temperature);
                command.Parameters.AddWithValue("@precipitation", weather.precipitation == "Є" ? true : false);
                command.Parameters.AddWithValue("@pressure", weather.pressure);
               
                command.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
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

        public List<Weather> GetWeathers(string city, string month)
        {
            try
            {
                command.CommandText = $"SELECT * FROM cloudy WHERE city = '{city}' AND month = '{month}';";

                reader = command.ExecuteReader();

                List<Weather> weathers = new List<Weather> { };

                while (reader.Read())
                {
                    weathers.Add(new Weather(reader.GetString(0), reader.GetInt16(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetUInt32(5)));
                }

                reader.Close();
                if (weathers.Count == 0)
                {
                    return null;
                }
                else
                {
                    return weathers;
                }
            }
            catch
            { 
                return null;
            }
        }
    }
}
