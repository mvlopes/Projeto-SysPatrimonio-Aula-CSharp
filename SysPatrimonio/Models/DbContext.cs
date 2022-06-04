using Microsoft.EntityFrameworkCore;
using SysPatrimonio.Models;

namespace SysPatrimonio.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> opcoes) : base(opcoes)
        {

        }

        public DbSet<DbUsuario> Usuarios { get; set; }

        public DbSet<DbCategoria>? DbCategoria { get; set; }

        public DbSet<DbFornecedor>? DbFornecedor { get; set; }

        public DbSet<DbDepartamento>? DbDepartamento { get; set; }

        public DbSet<DbLocal>? DbLocal { get; set; }

    }
}
