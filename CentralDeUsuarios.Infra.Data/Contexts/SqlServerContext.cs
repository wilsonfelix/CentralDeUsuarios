using CentralDeUsuarios.Domain.Entities;
using CentralDeUsuarios.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CentralDeUsuarios.Infra.Data.Contexts
{
    /// <summary>
    /// Classe de contexto de banco de dados SQL Server
    /// </summary>
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
        }

        // Aqui você pode configurar as entidades do banco de dados (se necessário)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        /// <summary>
        /// Propriedade de acesso à entidade de usuários
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }


    }
}
