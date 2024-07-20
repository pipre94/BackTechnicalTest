using BackTechnicalTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackTechnicalTest.Infrastructure
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración opcional de entidades y relaciones
        }
    }
}
