using Application.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class GroupAppServiceTest
    {
        [Fact]
        public void GetById()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                GroupAppService sut = new(context);

                GroupModel group = sut.GetById(1);

                Assert.Equal(1, group.Id);
                Assert.Equal("test", group.name);
                Assert.Equal(100, group.startBudget);
                Assert.Equal("2022-05-01", group.finishDate.ToString("yyyy-MM-dd"));
                Assert.False(group.isFinished);
            }
        }

        [Fact]
        public void Create()
        {
            using(var context = TestDbContext.GenerateTestDbContext())
            {
                GroupAppService sut = new(context);
                GroupModel group = new()
                {
                    name = "Space Y",
                    startBudget = 2400,
                    finishDate = new DateTime(2022, 05, 01),
                };

                var updated = sut.Create(group);
                var result = sut.GetById(updated.Id);

                Assert.Equal("Space Y", result.name);
                Assert.Equal(2, result.Id);
                Assert.Equal(2400, result.startBudget);
                Assert.Equal("2022-05-01", result.finishDate.ToString("yyyy-MM-dd"));
                Assert.False(result.isFinished);
            }
        }
    }
}
