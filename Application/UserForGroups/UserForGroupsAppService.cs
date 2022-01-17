using Application.Common;
using Application.UserForGroups.Interfaces;
using System.Collections.Generic;
using System.Linq;
using EntityClass = Application.UserForGroups.UserForGroupsModel;

namespace Application.UserForGroups
{
    public class UserForGroupsAppService : GenericApplicationService<EntityClass>, IUserForGroupsAppService
    {
        public UserForGroupsAppService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public UserForGroupsAppService() : base(ApplicationDbContext.AppDbContext)
        { }

        public IEnumerable<EntityClass> GetByUserId(int userId)
        {
            var result = dbContext.Set<EntityClass>().Where(x => x.userId == userId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public IEnumerable<EntityClass> GetByGroupId(int groupId)
        {
            var result = dbContext.Set<EntityClass>().Where(x => x.groupId == groupId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public override EntityClass Create(EntityClass entity)
        {
            entity.groupId = entity.groupModel.Id;
            entity.userId = entity.userHandlingModel.Id;
            return base.Create(entity);
        }
    }
}
