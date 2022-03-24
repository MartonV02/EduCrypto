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
                .Include(e => e.userHandlingModel)
                .ToList();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public override EntityClass GetById(int id)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.groupModel)
                .Include(e => e.userHandlingModel)
                .Where(f => f.Id == id)
                .FirstOrDefault();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public IEnumerable<EntityClass> GetByUserId(int userId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.groupModel)
                .Include(e => e.userHandlingModel)
                .Where(x => x.userHandlingModel.Id == userId)
                .ToList();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public IEnumerable<EntityClass> GetByGroupId(int groupId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.groupModel)
                .Include(e => e.userHandlingModel).ThenInclude(g => g.profilePicture)
                .Where(x => x.groupModel.Id == groupId)
                .ToList();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public bool IsCreator(int groupId, int userId)
        {
            var result = dbContext.Set<EntityClass>()
                .Where(r => r.groupModel.Id == groupId && r.userHandlingModel.Id == userId && r.accesLevel == "creator")
                .ToList();

            if (result == null)
                return false;
            else
                return true;
        }

        public bool IsMember(int groupId, int userId)
        {
            var result = dbContext.Set<EntityClass>()
                .Where(r => r.groupModel.Id == groupId && r.userHandlingModel.Id == userId)
                .ToList();

            if (result == null)
                return false;
            else
                return true;
        }
    }
}
