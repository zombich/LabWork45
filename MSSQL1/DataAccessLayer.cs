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
        public static object GetScalarValue(string query)
        {
            using SqlConnection connection = new(ConnectionString);
            connection.Open();

            SqlCommand command = new(query, connection);
            return command.ExecuteScalar();
        }

    }
}
