using System.Collections.Generic;
using EntityClass = Application.Group.GroupModel;

namespace Application.Group.Interfaces
{
    public interface IGroupAppService
    {
        public IEnumerable<EntityClass> GetAll();
        public EntityClass GetById(int id);
        public EntityClass Create(EntityClass entity);
        public EntityClass Update(EntityClass entity);
        public void Delete(int id);
    }
}
