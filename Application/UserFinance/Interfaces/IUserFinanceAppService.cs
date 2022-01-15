using System.Collections.Generic;
using EntityClass = Application.UserFinance.UserFinanceModel;

namespace Application.UserFinance.Interfaces
{
    public interface IUserFinanceAppService
    {
        public IEnumerable<EntityClass> GetAll();
        public EntityClass GetById(int id);
        public IEnumerable<EntityClass> GetByUserId(int userId);
        public EntityClass Create(EntityClass entity);
        public EntityClass Update(EntityClass entity);
        public void Delete(int id);
    }
}
