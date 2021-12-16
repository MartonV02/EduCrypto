using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal;

namespace Application.Common
{
    public class ApplicationDbContext: DbContext
    {
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
            optionsBuilder.UseMySql(ConnectionString);
        }

        public static ApplicationDbContext AppDbContext { get; set; }
    }
}
