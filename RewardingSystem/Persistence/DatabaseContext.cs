using Microsoft.EntityFrameworkCore;
using RewardingSystem.Models;

namespace RewardingSystem.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminToken> AdminTokens { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        void Save()
        {
            SaveChanges();
        }
    }
}
