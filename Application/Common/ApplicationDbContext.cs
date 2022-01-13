using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal;
using System;
using Application.UserHandling;

namespace Application.Common
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Application.UserHandling.UserHandling> UserHandlings { get; set; }
        public DbSet<Application.CryptoCurrencies.CryptoCurrency> CryptoCurrencies { get; set; }
        public DbSet<Application.Group.Group> Groups { get; set; }
        public DbSet<Application.UserCrypto.UserCrypto> UserCryptos { get; set; }
        public DbSet<Application.UserFinance.UserFinance> UserFinances { get; set; }
        public DbSet<Application.UserForGroups.UserForGroups> UserForGroups { get; set; }
        public DbSet<Application.UserTradeHistory.UserTradeHistory> UserTradeHistories { get; set; }
        public string ConnectionString { get; set; }
#if DEBUG
        = "Server=localhost;Database=WorkSheet;Uid=root;Pwd=;";
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

        public static ApplicationDbContext AppDbContext { get; set; }
    }
}
