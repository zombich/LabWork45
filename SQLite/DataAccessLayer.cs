using Microsoft.Data.Sqlite;
using System.Data;

namespace SQLite
{
    public static class DataAccessLayer
    {
        public static string FileName { get; set; } = "mydb.sqlite";
        public static string ConnectionString
        {
            get
            {
                SqliteConnectionStringBuilder builder = new()
                {
                    DataSource = FileName
                };
                return builder.ConnectionString;
            }
        }
        public static List<Game> Games
        {
            get
            {
                using SqliteConnection connection = new(ConnectionString);
                connection.Open();

                string query = "SELECT * FROM GAME";
                SqliteCommand command = new(query, connection);
                SqliteDataReader reader = command.ExecuteReader();

                List<Game> games = new();
                Game game;

                if (reader.HasRows)
                while (reader.Read())
                {
                    game = new();
                    game.Id = Convert.ToInt32(reader["Id"]);
                    game.Title = reader["Title"].ToString();
                    game.Price = Convert.ToDouble(reader["Price"]);
                    games.Add(game);
                }
                return games;
            }
        }
        public static object GetScalarValue(string query)
        {
            using SqliteConnection connection = new(ConnectionString);
            connection.Open();

            SqliteCommand command = new(query, connection);
            return command.ExecuteScalar();
        }

    }
}
