using Application.Common;
using Application.Group;
using Application.UserForGroups;
using Application.UserHandling;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
