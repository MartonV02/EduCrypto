using System.Collections.Generic;
using EntityClass = Application.UserTradeHistory.UserTradeHistoryModel;

namespace Application.UserTradeHistory.Interfaces
{
    public interface IUserTradeHistoryAppService
    {
        public IEnumerable<EntityClass> GetAll();
        public EntityClass GetById(int id);
        public IEnumerable<EntityClass> GetByUserId(int userId);
        public IEnumerable<EntityClass> GetByGroupId(int groupId);
        public IEnumerable<EntityClass> GetByCryptoCurrencyId(int cryptoCurrencyId);
        public EntityClass Create(EntityClass entity);
        public EntityClass Update(EntityClass entity);
        public void Delete(int id);
    }
}
