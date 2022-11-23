using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiComputadoras.Entitys;

namespace WebApiComputadoras
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity <ComputadorasComplementos>().HasKey(al => new {al.ComputadorasId, al.ComplentosId });


        }
        public DbSet<Computadoras> Computadoras { get; set; }
        public DbSet<Complementos> Complementos { get; set; }
        public DbSet<ComputadorasComplementos> ComputadorasComplementos { get; set; }
    }
}
