using Application.Common;
using Application.Group.Interfaces;

namespace Application.Group
{
    public class GroupAppService : GenericApplicationService<GroupModel>, IGroupAppService
    {
        public GroupAppService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public GroupAppService() : base(ApplicationDbContext.AppDbContext)
        { }
    }
}
