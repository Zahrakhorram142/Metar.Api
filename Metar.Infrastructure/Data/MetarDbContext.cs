using MetarApi.Data.Config;
using MetarApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetarApi.Data
{
    public class MetarDbContext:DbContext
    {
        public MetarDbContext(DbContextOptions options) : base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=MetarApi;Integrated Security=True;TrustServerCertificate=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MetarConfig());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<MetarEntity> MetarEntities { get; set; }
    }
}
