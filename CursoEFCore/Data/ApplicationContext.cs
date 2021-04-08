using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Date
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer("Data Source=DEV-LUQUES\\SQL2019;Initial Catalog=DbFinancas;Integrated Security=SSPI;");
        }
    }
}