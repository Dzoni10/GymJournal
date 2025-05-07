namespace GymJournal.Infrastructure.Database
{
    public class DbConnectionStringBuilder
    {
        public static string Build(string dbSchema)
        {
            var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            var database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "GymJournal";
            var schema = Environment.GetEnvironmentVariable("DATABASE_SCHEMA_NAME") ?? dbSchema;
            var user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "postgres";
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "super";
            //var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "false";
            var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";

            return
           $"Server={server};Port={port};Database={database};SearchPath={schema};User ID={user};Password={password};Pooling={pooling};";
        }
    }
}
