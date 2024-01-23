using Microsoft.EntityFrameworkCore;
using Selu383.SP24.Api.Entities;

namespace Selu383.SP24.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { 
            
        }
        public DbSet<Hotel> Hotels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .Property(x => x.Name)
                .HasMaxLength(120)
                .IsRequired();

            modelBuilder.Entity<Hotel>()
                .Property(x => x.Address)
                .IsRequired();

            modelBuilder.Entity<Hotel>()
                .HasKey(x => x.Id);


            
            base.OnModelCreating(modelBuilder);
        }
    }
}
