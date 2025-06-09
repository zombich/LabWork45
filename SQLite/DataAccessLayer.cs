using Microsoft.Data.Sqlite;

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
        public static object GetScalarValue(string query)
        {
            using SqliteConnection connection = new(ConnectionString);
            connection.Open();

            SqliteCommand command = new(query, connection);
            return command.ExecuteScalar();
        }

    }
}
