using System.Collections.Generic;
using EntityClass = Application.UserForGroups.UserForGroupsModel;

namespace Application.UserForGroups.Interfaces
{
    public interface IUserForGroupsAppService
    {
        public IEnumerable<EntityClass> GetAll();
        public EntityClass GetById(int id);
        public IEnumerable<EntityClass> GetByUserId(int userId);
        public IEnumerable<EntityClass> GetByGroupId(int groupId);
        public EntityClass Create(EntityClass entity);
        public EntityClass Update(EntityClass entity);
        public void Delete(int id);
    }
}
