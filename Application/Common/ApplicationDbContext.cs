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

        public static ApplicationDbContext AppDbContext { get; set; }
    }
}
