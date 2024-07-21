using Microsoft.EntityFrameworkCore;
using Escalada.API.Model;

namespace Escalada.API.Data
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=BancoTeste;User=root;Password=00000123;",
      new MySqlServerVersion(new Version(8, 0, 23)));
            }
        }
    }

}
