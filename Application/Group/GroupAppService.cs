using Application.Common;
using Application.Group.Interfaces;

namespace Application.Group
{
    public class GroupAppService : GenericApplicationService<Group>, IGroupAppService
    {
        public GroupAppService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public GroupAppService() : base(ApplicationDbContext.AppDbContext)
        { }
    }
}
