using Application.UserHandling;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTest
{
    public class UserHandlingAppServiceTest
    {
        [Fact]
        public void GetById()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserHandlingAppService service = new(context);

                UserHandlingModel user = service.GetById(1);

                Assert.Equal("test", user.userName);
                Assert.Equal("test@test.com", user.email);
                Assert.Equal("Test Elek", user.fullName);
                Assert.Equal(1000, user.moneyDollar);
                Assert.Equal(1, user.Id);
            }
        }

        [Fact]
        public void GetByEmail()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserHandlingAppService service = new(context);

                UserHandlingModel user = service.GetByEmail("replica@wallas.com");

                Assert.Equal("replica", user.userName);
                Assert.Equal("replica@wallas.com", user.email);
                Assert.Equal("Officer K", user.fullName);
                Assert.Equal(1000, user.moneyDollar);
                Assert.Equal(2, user.Id);
            }
        }

        [Fact]
        public void NotFound()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserHandlingAppService service = new(context);



                Assert.Throws<KeyNotFoundException>(() => service.GetById(3));
            }
        }

        [Fact]
        public void Create()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserHandlingAppService service = new(context);
                UserHandlingModel user = new()
                {
                    userName = "Darth Vader",
                    birthDate = new DateTime(2001, 09, 22),
                    email = "vader@empire.emp",
                    fullName = "Anakin Skywalker",
                    moneyDollar = 2000,
                    Password = "R2D2",
                    xpLevel = 11,
                };

                var result = service.Create(user);

                Assert.Equal("Darth Vader", result.userName);
                Assert.Equal("vader@empire.emp", result.email);
                Assert.Equal("Anakin Skywalker", result.fullName);
                Assert.Equal(1000, result.moneyDollar);
                Assert.Equal(0, result.xpLevel);
                Assert.Equal(3, result.Id);
            }
        }

        [Fact]
        public void Update()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserHandlingAppService service = new(context);
                UserHandlingModel user = service.GetById(1);
                user.email = "gamer@jedlik.eu";

                var result = service.Update(user);

                Assert.Equal("test", result.userName);
                Assert.Equal("gamer@jedlik.eu", result.email);
                Assert.Equal("Test Elek", result.fullName);
                Assert.Equal(1000, result.moneyDollar);
                Assert.Equal(0, result.xpLevel);
                Assert.Equal(1, result.Id);
            }
        }

        [Fact]
        public void Delete()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserHandlingAppService service = new(context);

                service.Delete(1);

                Assert.Throws<KeyNotFoundException>(() => service.GetById(1));
            }
        }
    }
}
