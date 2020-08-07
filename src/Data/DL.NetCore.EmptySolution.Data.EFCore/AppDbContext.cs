using DL.NetCore.EmptySolution.Data.EFCore.Configurations;
using DL.NetCore.EmptySolution.Domain.SocialRelationship.Entities;
using Microsoft.EntityFrameworkCore;

namespace DL.NetCore.EmptySolution.Data.EFCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Extrovert> Extroverts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ExtrovertEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ExtrovertFriendshipEntityConfiguration());
        }
    }
}
