using Application.UserHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                UserHandlingAppService sut = new(context);

                UserHandlingModel user = sut.GetById(1);

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
                UserHandlingAppService sut = new(context);

                UserHandlingModel user = sut.GetByEmail("replica@wallas.com");

                Assert.Equal("replica", user.userName);
                Assert.Equal("replica@wallas.com", user.email);
                Assert.Equal("Officer K", user.fullName);
                Assert.Equal(1000, user.moneyDollar);
                Assert.Equal(2, user.Id);
            }
        }

        [Fact]
        public void GetByNotExists()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserHandlingAppService sut = new(context);



                Assert.Throws<KeyNotFoundException>(() => sut.GetById(3));
            }
        }

        [Fact]
        public void Create()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserHandlingAppService sut = new(context);
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

                var result = sut.Create(user);

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
                UserHandlingAppService sut = new(context);
                UserHandlingModel user = sut.GetById(1);
                user.email = "gamer@jedlik.eu";
                user.moneyDollar = 2000;
                user.xpLevel = 2;

                var result = sut.Update(user);

                Assert.Equal("test", result.userName);
                Assert.Equal("gamer@jedlik.eu", result.email);
                Assert.Equal("Test Elek", result.fullName);
                Assert.Equal(1000, result.moneyDollar);
                Assert.Equal(0, result.xpLevel);
                Assert.Equal(1, result.Id);
            }
        }
    }
}
