using Microsoft.EntityFrameworkCore;

namespace GAV.GavRes.DataAccess.Context
{
    public class GavContext : DbContext
    {
        public DbSet<GAV.GavRes.DataAccess.Models.Vet> Vets { get; set; }
        public DbSet<GAV.GavRes.DataAccess.Models.Pet> Pets { get; set; }
        public DbSet<GAV.GavRes.DataAccess.Models.Client> Clients { get; set; }
        public DbSet<GAV.GavRes.DataAccess.Models.User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GavDb;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
