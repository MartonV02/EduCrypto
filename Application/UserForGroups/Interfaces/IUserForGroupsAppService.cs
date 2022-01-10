using System.Collections.Generic;
using EntityClass = Application.UserForGroups.UserForGroups;

namespace Application.UserForGroups.Interfaces
{
    internal interface IUserForGroupsAppService
    {
        public IEnumerable<EntityClass> GetAll();
        public IEnumerable<EntityClass> GetById(int id);
        public IEnumerable<EntityClass> Create(EntityClass entity);
        public IEnumerable<EntityClass> Update(EntityClass entity);
        public IEnumerable<EntityClass> Delete(int id);
    }
}
