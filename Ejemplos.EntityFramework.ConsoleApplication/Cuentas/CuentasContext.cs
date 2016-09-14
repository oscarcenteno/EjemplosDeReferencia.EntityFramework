using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Ejemplos.EntityFramework.ConsoleApplication.Cuentas
{
    public class CuentasContext : DbContext
    {
        public CuentasContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CuentasContext>());
        }

        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Historico> Historicos { get; set; }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
