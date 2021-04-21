using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Date
{
  public class ApplicationContext : DbContext
  {
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Data Source=DEV-LUQUES\\SQL2019;Initial Catalog=BD_CursoEFCore;Integrated Security=SSPI;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
  }
}