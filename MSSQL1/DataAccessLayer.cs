using Microsoft.Data.SqlClient;

namespace MSSQL
{
    public static class DataAccessLayer
    {
        public static string ServerName { get; set; } = "mssql";
        public static string DatabaseName { get; set; } = "ispp3104";
        public static string Login { get; set; } = "ispp3104";
        public static string Password { get; set; } = "3104";
        public static string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new()
                {
                    DataSource = ServerName,
                    InitialCatalog = DatabaseName,
                    UserID = Login,
                    Password = Password,
                    TrustServerCertificate = true
                };
                return builder.ConnectionString;
            }
        }
        public static List<Game> Games
        {
            get
            {
                using SqlConnection connection = new(ConnectionString);
                connection.Open();

                string query = "SELECT * FROM GAME";
                SqlCommand command = new(query, connection);
                SqlDataReader reader = command.ExecuteReader();

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
            using SqlConnection connection = new(ConnectionString);
            connection.Open();

            SqlCommand command = new(query, connection);
            return command.ExecuteScalar();
        }

    }
}
