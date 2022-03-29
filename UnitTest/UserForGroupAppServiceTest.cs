using Application.UserForGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class UserForGroupAppServiceTest
    {
        [Fact]
        public void GetById()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserForGroupsAppService service = new(context);

                UserForGroupsModel userFgroups = service.GetById(1);

                Assert.Equal(1, userFgroups.Id);
                Assert.Equal(1, userFgroups.userHandlingModel.Id);
                Assert.Equal(1, userFgroups.groupModel.Id);
                Assert.Equal("creator", userFgroups.accesLevel);
                Assert.Equal(100, userFgroups.money);
            }
        }

        [Fact]
        public void GetByIdNotExists()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserForGroupsAppService service = new(context);

                Assert.Throws<KeyNotFoundException>(() => service.GetById(3));
            }
        }


        [Fact]
        public void GetByUserId()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserForGroupsAppService service = new(context);

                List<UserForGroupsModel> list = service.GetByUserId(2).ToList();

                Assert.Single(list);
                Assert.Equal(2, list[0].Id);
                Assert.Equal(2, list[0].userHandlingModel.Id);
                Assert.Equal(1, list[0].groupModel.Id);
                Assert.Equal("member", list[0].accesLevel);
                Assert.Equal(100, list[0].money);
            }
        }

        [Fact]
        public void GetByUserIdNotExists()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserForGroupsAppService service = new(context);

                Assert.Throws<KeyNotFoundException>(() => service.GetByUserId(3).ToList());
            }
        }

        [Fact]
        public void GetByGroupId()
        {
            using( var context = TestDbContext.GenerateTestDbContext())
            {
                UserForGroupsAppService service = new(context);

                List<UserForGroupsModel> list = service.GetByGroupId(1).ToList();

                Assert.Equal(2, list.Count);

                Assert.Equal(1, list[0].Id);
                Assert.Equal(1, list[0].userHandlingModel.Id);
                Assert.Equal(1, list[0].groupModel.Id);
                Assert.Equal("creator", list[0].accesLevel);
                Assert.Equal(100, list[0].money);

                Assert.Equal(2, list[1].Id);
                Assert.Equal(2, list[1].userHandlingModel.Id);
                Assert.Equal(1, list[1].groupModel.Id);
                Assert.Equal("member", list[1].accesLevel);
                Assert.Equal(100, list[1].money);
            }
        }

        [Fact]
        public void GetByGroupIdNotExists()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserForGroupsAppService service = new(context);

                Assert.Throws<KeyNotFoundException>(() => service.GetByGroupId(2).ToList());
            }
        }

        [Fact]
        public void IsCreator()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserForGroupsAppService service = new(context);

                bool result1 = service.IsCreator(1, 1);
                bool result2 = service.IsCreator(1, 2);

                Assert.True(result1);
                Assert.False(result2);
            }
        }

        [Fact]
        public void IsMember()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserForGroupsAppService service = new(context);

                bool result1 = service.IsMember(1, 1);
                bool result2 = service.IsMember(1, 2);
                bool result3 = service.IsMember(1, 3);

                Assert.True(result1);
                Assert.True(result2);
                Assert.False(result3);
            }
        }
    }
}
