using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace Domain.Context
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options) { }

        public DbSet<ParsedData> ParsedDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
