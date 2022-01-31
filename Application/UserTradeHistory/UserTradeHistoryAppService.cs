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
            UserHandlingAppService userAppService = new UserHandlingAppService();
            CryptoCurrencyAppService cryptoAppService = new CryptoCurrencyAppService();
            try
            {
                UserHandlingModel user = userAppService.GetById(userTradeHystoryModel.userHandlingModel.Id);
                CryptoCurrencyModel crypto = cryptoAppService.GetById(userTradeHystoryModel.boughtCryptoCurrencyModel.Id);
                if (user.moneyDollar < userTradeHystoryModel.spentValue)
                {
                    throw new Exception("Not Enough Money");
                }
                else
                {
                    var userCryptoAppService = new UserCryptoAppService();
                    try
                    {
                        UserCryptoModel userCryptoModel = userCryptoAppService.GetByUserIdAndCryptoId(user.Id, crypto.Id);
                        userCryptoModel.cryptoValue += userTradeHystoryModel.boughtValue;
                        this.DecreaseDollar(userTradeHystoryModel.spentValue, user);
                        return userCryptoAppService.Update(userCryptoModel);
                    }
                    catch (KeyNotFoundException)
                    {
                        UserCryptoModel userCryptoModel = new UserCryptoModel
                        {
                            Id = 0,
                            userHandlingModel = user,
                            cryptoCurrency = crypto,
                            cryptoValue = userTradeHystoryModel.boughtValue,
                            isFavourite = false
                        };
                        this.DecreaseDollar(userTradeHystoryModel.spentValue, user);
                        return userCryptoAppService.Create(userCryptoModel);
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("No such a user or crypto value");
            }
        }

        private void DecreaseDollar(decimal dollar, UserHandlingModel user)
        {
            user.moneyDollar -= dollar;
            var userAppService = new UserHandlingAppService();
            userAppService.Update(user);
        }

        private void IncreaseDollar(decimal dollar, UserHandlingModel user)
        {
            user.moneyDollar += dollar;
            var userAppService = new UserHandlingAppService();
            userAppService.Update(user);
        }
    }
}
