using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal;
using System;
using Application.UserHandling;
using Application.CryptoCurrencies;
using Application.Group;
using Application.UserCrypto;
using Application.UserForGroups;
using Application.UserTradeHistory;

namespace Application.Common
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<UserHandlingModel> UserHandlings { get; set; }
        public DbSet<CryptoCurrencyModel> CryptoCurrencies { get; set; }
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<UserCryptoModel> UserCryptos { get; set; }
        public DbSet<UserForGroupsModel> UserForGroups { get; set; }
        public DbSet<UserTradeHistoryModel> UserTradeHistories { get; set; }
        public string ConnectionString { get; set; }
#if DEBUG
        = "Server=localhost;Database=EduCrypto;Uid=root;Pwd=;";
#endif
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        {
            var extension = options.FindExtension<MySqlOptionsExtension>();
            this.ConnectionString = extension.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            optionsBuilder.UseMySql(this.ConnectionString, new MySqlServerVersion(new Version()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserHandlingModel>().HasIndex(e => e.userName).IsUnique();
            modelBuilder.Entity<UserHandlingModel>().HasIndex(e => e.email).IsUnique();
            modelBuilder.Entity<UserHandlingModel>().HasIndex(e => e.walletNumber).IsUnique();

            modelBuilder.Entity<GroupModel>().HasIndex(e => e.name).IsUnique();

            modelBuilder.Entity<UserForGroupsModel>().HasIndex(e => e.groupWalletNumber).IsUnique();

            modelBuilder.Entity<UserHandlingModel>().HasData(
                new UserHandlingModel() { Id = 1, userName = "test", email = "test@test.com", fullName = "Test Elek", birthDate = new DateTime(2000, 01, 01), xpLevel = 0, moneyDollar = 1000, Password = "Test123"},
                new UserHandlingModel() { Id = 2, userName = "replica", email = "replica@wallas.com", fullName = "Officer K", birthDate = new DateTime(2049, 01, 01), xpLevel = 0, moneyDollar = 1000, Password = "InterlinkedCells"}
            );
        }

        public static ApplicationDbContext AppDbContext { get; set; }
    }
}
