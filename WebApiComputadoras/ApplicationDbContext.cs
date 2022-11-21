using Microsoft.EntityFrameworkCore;
using WebApiComputadoras.Entitys;

namespace WebApiComputadoras
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Computadoras> Computadoras { get; set; }
        public DbSet<Complementos> Complementos { get; set; }
    }
}
