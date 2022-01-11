using System.Collections.Generic;
using EntityClass = Application.UserHandling.UserHandling;

namespace Application.UserHandling.Interfaces
{
    public interface IUserHandlingAppService
    {
        public IEnumerable<EntityClass> GetAll();
        public EntityClass GetById(int id);
        public EntityClass Create(EntityClass entity);
        public EntityClass Update(EntityClass entity);
        public void Delete(int id);
    }
}
