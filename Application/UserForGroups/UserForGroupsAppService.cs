using Application.Common;
using Application.UserForGroups.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public override IEnumerable<EntityClass> GetAll()
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.groupModel)
                .Include(e => e.userHandlingModel);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public override EntityClass GetById(int id)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.groupModel)
                .Include(e => e.userHandlingModel)
                .Where(f => f.Id == id);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.FirstOrDefault();
        }

        public IEnumerable<EntityClass> GetByUserId(int userId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.groupModel)
                .Include(e => e.userHandlingModel)
                .Where(x => x.userHandlingModel.Id == userId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public IEnumerable<EntityClass> GetByGroupId(int groupId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.groupModel)
                .Include(e => e.userHandlingModel).ThenInclude(g => g.profilePicture)
                .Where(x => x.groupModel.Id == groupId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }
    }
}
