using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace PerspicuityTest.Tests.Integration.Database._TestUtils_
{
    public static class DatabaseTestUtils
    {
        private static string ConnectionString { get; }

        static DatabaseTestUtils()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("Web.Api/appsettings.test.json")
                .Build();

            ConnectionString = configuration.GetConnectionString("Database")!;
        }

        public static async Task ResetDatabase()
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            await sqlConnection.OpenAsync();

            var deleteQuery = @"
                DELETE dbo.Classes;
            ";

            using var command = new SqlCommand(deleteQuery, sqlConnection);
            await command.ExecuteNonQueryAsync();
        }
    }
}
