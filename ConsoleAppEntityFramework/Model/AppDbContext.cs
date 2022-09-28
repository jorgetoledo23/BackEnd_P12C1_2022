using Microsoft.EntityFrameworkCore;

namespace ConsoleAppEntityFramework.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Producto> tblProductos { get; set; }
        public DbSet<Cliente> tblClientes { get; set; }
        public DbSet<Venta> tblVentas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BackEndP12C1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
