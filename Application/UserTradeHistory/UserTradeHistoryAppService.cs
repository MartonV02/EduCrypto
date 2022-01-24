using Application.Common;
using Application.UserTradeHistory.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using EntityClass = Application.UserTradeHistory.UserTradeHistoryModel;

namespace Application.UserTradeHistory
{
    public class UserTradeHistoryAppService : GenericApplicationService<EntityClass>, IUserTradeHistoryAppService
    {
        public UserTradeHistoryAppService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public UserTradeHistoryAppService() : base(ApplicationDbContext.AppDbContext)
        { }

        public override EntityClass Create(EntityClass userTradeHystoryModel)
        {
            userTradeHystoryModel.tradeDate = DateTime.Now;
            return base.Create(userTradeHystoryModel);
        }

        public override IEnumerable<EntityClass> GetAll()
        {
            return dbContext.Set<EntityClass>()
                .Include(f => f.boughtCryptoCurrencyModel)
                .Include(g => g.spentCryptoCurrencyModel)
                .Include(e => e.userHandlingModel);
        }

        public override EntityClass GetById(int id)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.boughtCryptoCurrencyModel)
                .Include(g => g.spentCryptoCurrencyModel)
                .Include(e => e.userHandlingModel)
                .Include(h => h.groupModel)
                .FirstOrDefault();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public IEnumerable<EntityClass> GetByUserId(int userId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.boughtCryptoCurrencyModel)
                .Include(g => g.spentCryptoCurrencyModel)
                .Include(e => e.userHandlingModel)
                .Where(x => x.userHandlingModel.Id == userId && x.groupModel == null);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public IEnumerable<EntityClass> GetByGroupId(int groupId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.boughtCryptoCurrencyModel)
                .Include(g => g.spentCryptoCurrencyModel)
                .Include(e => e.userHandlingModel)
                .Include(h => h.groupModel)
                .Where(x => x.groupModel.Id == groupId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public IEnumerable<EntityClass> GetByUserAndGroupId(int userId, int groupId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.boughtCryptoCurrencyModel)
                .Include(g => g.spentCryptoCurrencyModel)
                .Include(e => e.userHandlingModel)
                .Include(h => h.groupModel)
                .Where(x => x.groupModel.Id == groupId && x.userHandlingModel.Id == userId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public IEnumerable<EntityClass> GetByCryptoCurrencyId(int cryptoCurrencyId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.boughtCryptoCurrencyModel)
                .Include(g => g.spentCryptoCurrencyModel)
                .Include(e => e.userHandlingModel)
                .Include(h => h.groupModel)
                .Where(x => x.boughtCryptoCurrencyModel.Id == cryptoCurrencyId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }
    }
}
