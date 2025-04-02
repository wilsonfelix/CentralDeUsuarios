using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace CentralDeUsuarios.Infra.Data.Contexts
{
    public static class SqlServerContextFactory
    {
        public static SqlServerContext Create()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddUserSecrets(typeof(SqlServerContextFactory).Assembly, optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration["SQLSERVER_CONNECTION"]
                ?? configuration.GetConnectionString("SqlServer");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("String de conexão não encontrada.");

            var options = new DbContextOptionsBuilder<SqlServerContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new SqlServerContext(options);
        }
    }
}
