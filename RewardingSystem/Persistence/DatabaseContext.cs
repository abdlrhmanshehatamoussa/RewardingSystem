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
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherRank> VoucherRanks { get; set; }
        public DbSet<VoucherType> VoucherTypes { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Trial> Trials { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasIndex(a => a.UserName).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Transaction>().HasIndex(t => t.ReferenceNumber).IsUnique();
            modelBuilder.Entity<Voucher>().HasIndex(v => v.Code).IsUnique();
            modelBuilder.Entity<VoucherType>().HasIndex(vt => vt.Name).IsUnique();
            modelBuilder.Entity<VoucherRank>().HasIndex(vr => vr.Name).IsUnique();
            modelBuilder.Entity<Merchant>().HasIndex(m => m.Name).IsUnique();
        }

        void Save()
        {
            SaveChanges();
        }
    }
}
