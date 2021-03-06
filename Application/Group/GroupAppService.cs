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
            if (groupModel.finishDate <= DateTime.Now)
            {
                throw new Exception("Wrong Finish Date!");
            }
            groupModel.startDate = DateTime.Now;
            groupModel.isFinished = false;
            return base.Create(groupModel);
        }

        public override GroupModel GetById(int id)
        {
            GroupModel group = base.GetById(id);
            if (!group.isFinished && group.finishDate <= DateTime.Now)
            {
                group.isFinished = true;
                base.Update(group);
                return base.GetById(id);
            }
            return group;
        }

        public override GroupModel Update(GroupModel entity)
        {
            var updated = this.GetById(entity.Id);

            updated.name = entity.name;
            updated.finishDate = entity.finishDate;
            if (updated.finishDate <= DateTime.Now)
            {
                updated.isFinished = true;
            }
            else
            {
                updated.isFinished = false;
            }

            return base.Update(updated);
        }
    }
}
