using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeUsuarios.Infra.Data.Contexts
{
    /// <summary>
    /// Classe para injeção de dependências, toda vez que for necessário adicionar uma nova migração, é necessário criar uma nova classe com o nome SqlServerContextMigration{NumeroDaMigracao}
    /// </summary>
    public class SqlServerContextMigration : IDesignTimeDbContextFactory<SqlServerContext>
    {
        /// <summary>
        /// Injetor de dependência para a classe SqlServerContext sempre que for necessário criar uma nova Migrations do Entity Framework
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public SqlServerContext CreateDbContext(string[] args)
        {
            #region Monta a configuração a partir de várias fontes
            // Detecta o ambiente (ex: Development, Production)
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .AddUserSecrets(typeof(SqlServerContextMigration).Assembly, optional: true)
                .AddEnvironmentVariables()
                .Build();

            #endregion

            #region Busca a connection string: primeiro tenta variável de ambiente, depois no appsettings
            // Procura SQLSERVER_CONNECTION como prioridade, senão tenta connectionStrings:SqlServer
            var connectionString = configuration["SQLSERVER_CONNECTION"]
                                   ?? configuration.GetConnectionString("SqlServer");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("A string de conexão não foi encontrada nas fontes de configuração.");

            var optionsBuilder = new DbContextOptionsBuilder<SqlServerContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SqlServerContext(optionsBuilder.Options);
            #endregion
        }
    }
}
