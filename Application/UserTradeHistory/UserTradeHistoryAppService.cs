using Application.Common;
using Application.UserTradeHistory.Interfaces;
using System.Collections.Generic;
using System.Linq;
using EntityClass = Application.UserTradeHistory.UserTradeHistory;

namespace Application.UserTradeHistory
{
    public class UserTradeHistoryAppService : GenericApplicationService<EntityClass>, IUserTradeHistoryAppService
    {
        public UserTradeHistoryAppService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public UserTradeHistoryAppService() : base(ApplicationDbContext.AppDbContext)
        { }

        public IEnumerable<EntityClass> GetByUserId(int userId)
        {
            var result = dbContext.Set<EntityClass>().Where(x => x.userId == userId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public IEnumerable<EntityClass> GetByGroupId(int groupId)
        {
            var result = dbContext.Set<EntityClass>().Where(x => x.groupId == groupId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public IEnumerable<EntityClass> GetByCryptoCurrencyId(int cryptoCurrencyId)
        {
            var result = dbContext.Set<EntityClass>().Where(x => x.boughtId == cryptoCurrencyId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }
    }
}
