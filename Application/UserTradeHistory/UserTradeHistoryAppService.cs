using Application.Common;
using Application.CryptoCurrencies;
using Application.UserCrypto;
using Application.UserForGroups;
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

        private UserCryptoModel TradeToDollarCrypto(EntityClass userTradeHystoryModel)
        {
            UserHandlingAppService userAppService = new UserHandlingAppService();
            CryptoCurrencyAppService cryptoAppService = new CryptoCurrencyAppService();
            UserCryptoAppService userCryptoAppService = new UserCryptoAppService();
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

        private UserCryptoModel TradeCryptoToDollar(EntityClass userTradeHystoryModel)
        {
            UserHandlingAppService userAppService = new UserHandlingAppService();
            CryptoCurrencyAppService cryptoAppService = new CryptoCurrencyAppService();
            UserCryptoAppService userCryptoAppService = new UserCryptoAppService();
            try
            {
                UserHandlingModel user = userAppService.GetById(userTradeHystoryModel.userHandlingModel.Id);
                CryptoCurrencyModel crypto = cryptoAppService.GetById(userTradeHystoryModel.spentCryptoCurrencyModel.Id);
                try
                {
                    UserCryptoModel userCrypto = userCryptoAppService.GetByUserIdAndCryptoId(user.Id, crypto.Id);
                    if (userCrypto.cryptoValue < userTradeHystoryModel.spentValue)
                    {
                        throw new KeyNotFoundException();
                    }
                    userCrypto.cryptoValue -= userTradeHystoryModel.spentValue;
                    this.IncreaseDollar(userTradeHystoryModel.boughtValue, user);
                    return userCryptoAppService.Create(userCrypto);
                }
                catch (KeyNotFoundException)
                {
                    throw new Exception("Not enough Crypto currency");
                }
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("No such a user or crypto value");
            }
        }

        private UserCryptoModel TradeDollarToCryptoInGroup(EntityClass userTradeHystoryModel)
        {
            UserHandlingAppService userAppService = new UserHandlingAppService();
            UserForGroupsAppService userForGroupsAppService = new UserForGroupsAppService();
            CryptoCurrencyAppService cryptoAppService = new CryptoCurrencyAppService();
            UserCryptoAppService userCryptoAppService = new UserCryptoAppService();
            try
            {
                UserHandlingModel user = userAppService.GetById(userTradeHystoryModel.userHandlingModel.Id);
                UserForGroupsModel userForGroups = userForGroupsAppService.GetById(userTradeHystoryModel.userForGroupsModel.Id);
                CryptoCurrencyModel crypto = cryptoAppService.GetById(userTradeHystoryModel.boughtCryptoCurrencyModel.Id);

                if (user.Id != userForGroups.userHandlingModel.Id)
                {
                    throw new Exception("Not maching users");
                }

                if (userForGroups.money < userTradeHystoryModel.spentValue)
                {
                    throw new Exception("Not Enough Money");
                }
                else
                {
                    try
                    {
                        UserCryptoModel userCryptoModel = userCryptoAppService.GetByUserForGroupsIdAndCryptoId(userForGroups.Id, crypto.Id);
                        userCryptoModel.cryptoValue += userTradeHystoryModel.boughtValue;
                        this.DecreaseDollarInGroup(userTradeHystoryModel.spentValue, userForGroups);
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
                            userForGroupsModel = userForGroups,
                            isFavourite = false
                        };
                        this.DecreaseDollarInGroup(userTradeHystoryModel.spentValue, userForGroups);
                        return userCryptoAppService.Create(userCryptoModel);
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("No such a user or crypto value");
            }
        }

        private UserCryptoModel TradeCryptoToDollarInGroup(EntityClass userTradeHystoryModel)
        {
            UserHandlingAppService userAppService = new UserHandlingAppService();
            CryptoCurrencyAppService cryptoAppService = new CryptoCurrencyAppService();
            UserForGroupsAppService userForGroupsAppService = new UserForGroupsAppService();
            UserCryptoAppService userCryptoAppService = new UserCryptoAppService();
            try
            {
                UserHandlingModel user = userAppService.GetById(userTradeHystoryModel.userHandlingModel.Id);
                CryptoCurrencyModel crypto = cryptoAppService.GetById(userTradeHystoryModel.spentCryptoCurrencyModel.Id);
                UserForGroupsModel userForGroups = userForGroupsAppService.GetById(userTradeHystoryModel.userForGroupsModel.Id);

                if (user.Id != userForGroups.userHandlingModel.Id)
                {
                    throw new Exception("Not maching users");
                }

                try
                {
                    UserCryptoModel userCrypto = userCryptoAppService.GetByUserForGroupsIdAndCryptoId(userForGroups.Id, crypto.Id);
                    if (userCrypto.cryptoValue < userTradeHystoryModel.spentValue)
                    {
                        throw new KeyNotFoundException();
                    }
                    userCrypto.cryptoValue -= userTradeHystoryModel.spentValue;
                    this.IncreaseDollarInGroup(userTradeHystoryModel.boughtValue, userForGroups);
                    return userCryptoAppService.Create(userCrypto);
                }
                catch (KeyNotFoundException)
                {
                    throw new Exception("Not enough Crypto currency");
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
            UserHandlingAppService userAppService = new UserHandlingAppService();
            userAppService.Update(user);
        }

        private void IncreaseDollar(decimal dollar, UserHandlingModel user)
        {
            user.moneyDollar += dollar;
            UserHandlingAppService userAppService = new UserHandlingAppService();
            userAppService.Update(user);
        }

        private void DecreaseDollarInGroup(decimal dollar, UserForGroupsModel userForGroups)
        {
            userForGroups.money -= dollar;
            UserForGroupsAppService userForGroupsAppService = new UserForGroupsAppService();
            userForGroupsAppService.Update(userForGroups);
        }

        private void IncreaseDollarInGroup(decimal dollar, UserForGroupsModel userForGroups)
        {
            userForGroups.money += dollar;
            UserForGroupsAppService userForGroupsAppService = new UserForGroupsAppService();
            userForGroupsAppService.Update(userForGroups);
        }
    }
}
