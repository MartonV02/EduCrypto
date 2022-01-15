using Application.Common;
using Application.Group.Interfaces;
using System;

namespace Application.Group
{
    public class GroupAppService : GenericApplicationService<GroupModel>, IGroupAppService
    {
        public GroupAppService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public GroupAppService() : base(ApplicationDbContext.AppDbContext)
        { }

        public override GroupModel Create(GroupModel groupModel)
        {
            groupModel.startDate = DateTime.Now;
            return base.Create(groupModel);
        }
    }
}
