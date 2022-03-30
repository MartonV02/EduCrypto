using Application.Common;
using Microsoft.EntityFrameworkCore;
using System;

namespace UnitTest
{
    class TestDbContext: ApplicationDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("educrypto" + Guid.NewGuid().ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static TestDbContext GenerateTestDbContext()
        {
            TestDbContext context = new();
            context.Database.EnsureCreated();
            return context;
        }
    }
}
