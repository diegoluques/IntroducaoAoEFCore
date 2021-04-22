using System;
using System.Linq;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CursoEFCore.Date
{
  public class ApplicationContext : DbContext
  {
    private static readonly ILoggerFactory _logger = LoggerFactory.Create(l => l.AddConsole());
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder
      .UseLoggerFactory(_logger)
      .EnableSensitiveDataLogging()
      .UseSqlServer("Data Source=DEV-LUQUES\\SQL2019;Initial Catalog=BD_CursoEFCore;Integrated Security=SSPI;",
      p => p.EnableRetryOnFailure(
        maxRetryCount: 2,
        maxRetryDelay:
          TimeSpan.FromSeconds(5),
          errorNumbersToAdd: null
      ));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
      MapearPropriedadesEsquecidas(modelBuilder);
    }

    protected void MapearPropriedadesEsquecidas(ModelBuilder modelBuilder)
    {
      foreach (var entity in modelBuilder.Model.GetEntityTypes())
      {
        var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));

        foreach (var property in properties)
        {
          if (string.IsNullOrEmpty(property.GetColumnType()) &&
          !property.GetMaxLength().HasValue)
          {
            property.SetMaxLength(100);
            property.SetColumnType("varchar(100)");
          }
        }
      }
    }
  }
}