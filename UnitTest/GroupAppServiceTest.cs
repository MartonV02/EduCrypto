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
                GroupAppService service = new(context);

                GroupModel group = service.GetById(1);

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
                GroupAppService service = new(context);
                GroupModel group = new()
                {
                    name = "Space Y",
                    startBudget = 2400,
                    finishDate = new DateTime(2022, 05, 01),
                };

                var created = service.Create(group);
                var result = service.GetById(created.Id);

                Assert.Equal("Space Y", created.name);
                Assert.Equal(2, created.Id);
                Assert.Equal(2400, created.startBudget);
                Assert.Equal("2022-05-01", created.finishDate.ToString("yyyy-MM-dd"));
                Assert.False(created.isFinished);

                Assert.Equal("Space Y", result.name);
                Assert.Equal(2, result.Id);
                Assert.Equal(2400, result.startBudget);
                Assert.Equal("2022-05-01", result.finishDate.ToString("yyyy-MM-dd"));
                Assert.False(result.isFinished);
            }
        }

        [Fact]
        public void CreateWidthError()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                GroupAppService service = new(context);
                GroupModel group = new()
                {
                    name = "Space Y",
                    startBudget = 2400,
                    finishDate = new DateTime(2020, 01, 01),
                };

                Assert.Throws<Exception>(() => service.Create(group));
            }
        }

        [Fact]
        public void Update()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                GroupAppService service = new (context);
                GroupModel group = service.GetById(1);
                group.finishDate = new DateTime(2022, 03, 27);
                group.name = "Space X";
                group.startBudget = 200;

                var updated = service.Update(group);
                var result = service.GetById(1);

                Assert.Equal("Space X", updated.name);
                Assert.Equal(1, updated.Id);
                Assert.Equal(100, updated.startBudget);
                Assert.Equal("2022-03-27", updated.finishDate.ToString("yyyy-MM-dd"));
                Assert.True(updated.isFinished);

                Assert.Equal("Space X", result.name);
                Assert.Equal(1, result.Id);
                Assert.Equal(100, result.startBudget);
                Assert.Equal("2022-03-27", result.finishDate.ToString("yyyy-MM-dd"));
                Assert.True(result.isFinished);
            }
        }

        [Fact]
        public void Delete()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                GroupAppService service = new(context);

                service.Delete(1);

                Assert.Throws<KeyNotFoundException>(() => service.GetById(1));
            }
        }

        [Fact]
        public void NotFound()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                GroupAppService service = new(context);

                

                Assert.Throws<KeyNotFoundException>(() => service.GetById(2));
            }
        }
    }
}
