using Application.Common;
using Application.CryptoCurrencies;
using Application.UserCrypto;
using Application.UserHandling;
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
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.boughtCryptoCurrencyModel)
                .Include(g => g.spentCryptoCurrencyModel)
                .Include(e => e.userHandlingModel);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public override EntityClass GetById(int id)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.boughtCryptoCurrencyModel)
                .Include(g => g.spentCryptoCurrencyModel)
                .Include(e => e.userHandlingModel)
                .Include(h => h.userForGroupsModel)
                .Where(f => f.Id == id);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.FirstOrDefault();
        }

        public IEnumerable<EntityClass> GetByUserId(int userId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.boughtCryptoCurrencyModel)
                .Include(g => g.spentCryptoCurrencyModel)
                .Include(e => e.userHandlingModel)
                .Where(x => x.userHandlingModel.Id == userId && x.userForGroupsModel == null);

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
                .Include(h => h.userForGroupsModel)
                .Where(x => x.userForGroupsModel.groupModel.Id == groupId);

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
                .Include(h => h.userForGroupsModel)
                .Where(x => x.userForGroupsModel.groupModel.Id == groupId && x.userHandlingModel.Id == userId);

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
                .Include(h => h.userForGroupsModel)
                .Where(x => x.boughtCryptoCurrencyModel.Id == cryptoCurrencyId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public IEnumerable<EntityClass> GetByUserIdAndCryptoCurrencyId(int userId, int cryptoCurrencyId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.boughtCryptoCurrencyModel)
                .Include(g => g.spentCryptoCurrencyModel)
                .Include(e => e.userHandlingModel)
                .Include(h => h.userForGroupsModel)
                .Where(x => x.userHandlingModel.Id == userId && x.boughtCryptoCurrencyModel.Id == cryptoCurrencyId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        private UserCryptoModel TradeFromDollart(EntityClass userTradeHystoryModel)
        {
            var userAppService = new UserHandlingAppService();
            var cryptoAppService = new CryptoCurrencyAppService();
            try
            {
                var user = userAppService.GetById(userTradeHystoryModel.userHandlingModel.Id); //TODO ask Pali, kelle GETBYID
                var crypto = cryptoAppService.GetById(userTradeHystoryModel.boughtCryptoCurrencyModel.Id); //TODO ask Pali, kelle GETBYID
                if (user.moneyDollar < userTradeHystoryModel.spentValue)
                {
                    throw new Exception("Not Enough Money");
                }
                else
                {
                    var userCryptoAppService = new UserCryptoAppService();
                    try
                    {
                        var userCryptoModel = userCryptoAppService.GetByUserIdAndCryptoId(user.Id, crypto.Id);
                        userCryptoModel.cryptoValue += userTradeHystoryModel.boughtValue;
                        return userCryptoAppService.Update(userCryptoModel);
                    }
                    catch (KeyNotFoundException)
                    {
                        var userCryptoModel = new UserCryptoModel
                        {
                            Id = 0,
                            userHandlingModel = user,
                            cryptoCurrency = crypto,
                            cryptoValue = userTradeHystoryModel.boughtValue,
                            isFavourite = false
                        };
                        return userCryptoAppService.Create(userCryptoModel);
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("No such a user or crypto value");
            }

        }
    }
}
