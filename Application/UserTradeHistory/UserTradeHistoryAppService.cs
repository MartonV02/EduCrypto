using Application.Common;
using Application.ImportCryptos.Entities;
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

        public EntityClass CreateWithTransaction(EntityClass userTradeHystoryModel, UserHandlingAppService userAppService,
            UserCryptoAppService userCryptoAppService, UserForGroupsAppService userForGroupsAppService)
        {
            if (userTradeHystoryModel.spentCryptoSymbol == null && userTradeHystoryModel.boughtCryptoSymbol != null && userTradeHystoryModel.userForGroupsModel == null)
                this.TradeDollarToCrypto(userTradeHystoryModel, userAppService, userCryptoAppService);
            else if (userTradeHystoryModel.spentCryptoSymbol != null && userTradeHystoryModel.boughtCryptoSymbol == null && userTradeHystoryModel.userForGroupsModel == null)
                this.TradeCryptoToDollar(userTradeHystoryModel, userAppService, userCryptoAppService);
            else if (userTradeHystoryModel.spentCryptoSymbol == null && userTradeHystoryModel.boughtCryptoSymbol != null && userTradeHystoryModel.userForGroupsModel != null)
                this.TradeDollarToCryptoInGroup(userTradeHystoryModel, userAppService, userCryptoAppService, userForGroupsAppService);
            else if (userTradeHystoryModel.spentCryptoSymbol != null && userTradeHystoryModel.boughtCryptoSymbol == null && userTradeHystoryModel.userForGroupsModel != null)
                this.TradeCryptoToDollarInGroup(userTradeHystoryModel, userAppService, userCryptoAppService, userForGroupsAppService);

            return this.Create(userTradeHystoryModel);
        }

        public override IEnumerable<EntityClass> GetAll()
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(h => h.userForGroupsModel).ThenInclude(i => i.groupModel);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public override EntityClass GetById(int id)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(h => h.userForGroupsModel).ThenInclude(i => i.groupModel)
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
                .Include(e => e.userHandlingModel)
                .Include(h => h.userForGroupsModel).ThenInclude(i => i.groupModel)
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
                .Include(e => e.userHandlingModel)
                .Include(h => h.userForGroupsModel).ThenInclude(i => i.groupModel)
                .Where(x => x.userForGroupsModel.groupModel.Id == groupId && x.userHandlingModel.Id == userId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public IEnumerable<EntityClass> GetByCryptoCurrencySymbol(string cryptoSymbol)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(h => h.userForGroupsModel).ThenInclude(i => i.groupModel)
                .Where(x => x.boughtCryptoSymbol == cryptoSymbol);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public IEnumerable<EntityClass> GetByUserIdAndCryptoCurrencySymbol(int userId, string cryptoSymbol)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(h => h.userForGroupsModel).ThenInclude(i => i.groupModel)
                .Where(x => x.userHandlingModel.Id == userId && x.boughtCryptoSymbol == cryptoSymbol);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        private UserCryptoModel TradeDollarToCrypto(EntityClass userTradeHystoryModel, UserHandlingAppService userAppService, 
            UserCryptoAppService userCryptoAppService)
        {
            try
            {
                UserHandlingModel user = userAppService.GetById(userTradeHystoryModel.userHandlingModel.Id);
                CryptoPropertiesModel crypto = CryptoData.GetByCryptoSymbol(userTradeHystoryModel.boughtCryptoSymbol);
                if (user.moneyDollar < userTradeHystoryModel.spentValue)
                {
                    throw new Exception("Not Enough Money");
                }
                else if (userTradeHystoryModel.boughtValue != CryptoData.ChangeToCrypto(crypto, userTradeHystoryModel.spentValue))
                {
                    throw new Exception("Invalid Change");
                }
                else
                {
                    try
                    {
                        UserCryptoModel userCryptoModel = userCryptoAppService.GetByUserIdAndCryptoSymbol(user.Id, crypto.symbol);
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
                            cryptoSymbol = crypto.symbol,
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

        private UserCryptoModel TradeCryptoToDollar(EntityClass userTradeHystoryModel, UserHandlingAppService userAppService, 
            UserCryptoAppService userCryptoAppService)
        {
            try
            {
                UserHandlingModel user = userAppService.GetById(userTradeHystoryModel.userHandlingModel.Id);
                CryptoPropertiesModel crypto = CryptoData.GetByCryptoSymbol(userTradeHystoryModel.spentCryptoSymbol);

                try
                {
                    UserCryptoModel userCrypto = userCryptoAppService.GetByUserIdAndCryptoSymbol(user.Id, crypto.symbol);
                    if (userCrypto.cryptoValue < userTradeHystoryModel.spentValue)
                    {
                        throw new KeyNotFoundException();
                    }
                    else if (userTradeHystoryModel.boughtValue != CryptoData.ChangeToDollar(crypto, userTradeHystoryModel.spentValue))
                    {
                        throw new Exception("Invalid Change");
                    }
                    userCrypto.cryptoValue -= userTradeHystoryModel.spentValue;
                    this.IncreaseDollar(userTradeHystoryModel.boughtValue, user);
                    return userCryptoAppService.Update(userCrypto);
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

        private UserCryptoModel TradeDollarToCryptoInGroup(EntityClass userTradeHystoryModel, UserHandlingAppService userAppService, 
            UserCryptoAppService userCryptoAppService, UserForGroupsAppService userForGroupsAppService)
        {
            try
            {
                UserHandlingModel user = userAppService.GetById(userTradeHystoryModel.userHandlingModel.Id);
                UserForGroupsModel userForGroups = userForGroupsAppService.GetById(userTradeHystoryModel.userForGroupsModel.Id);
                CryptoPropertiesModel crypto = CryptoData.GetByCryptoSymbol(userTradeHystoryModel.boughtCryptoSymbol);

                if (user.Id != userForGroups.userHandlingModel.Id)
                {
                    throw new Exception("Not maching users");
                }
                else if (userForGroups.groupModel.isFinished)
                {
                    throw new Exception("Group already closed");
                }
                else if (userForGroups.money < userTradeHystoryModel.spentValue)
                {
                    throw new Exception("Not Enough Money");
                }
                else if (userTradeHystoryModel.boughtValue != CryptoData.ChangeToCrypto(crypto, userTradeHystoryModel.spentValue))
                {
                    throw new Exception("Invalid Change");
                }
                else
                {
                    try
                    {
                        UserCryptoModel userCryptoModel = userCryptoAppService.GetByUserForGroupsIdAndCryptoSymbol(userForGroups.Id, crypto.symbol);
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
                            cryptoSymbol = crypto.symbol,
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

        private UserCryptoModel TradeCryptoToDollarInGroup(EntityClass userTradeHystoryModel, UserHandlingAppService userAppService, 
            UserCryptoAppService userCryptoAppService, UserForGroupsAppService userForGroupsAppService)
        {
            try
            {
                UserHandlingModel user = userAppService.GetById(userTradeHystoryModel.userHandlingModel.Id);
                CryptoPropertiesModel crypto = CryptoData.GetByCryptoSymbol(userTradeHystoryModel.spentCryptoSymbol);
                UserForGroupsModel userForGroups = userForGroupsAppService.GetById(userTradeHystoryModel.userForGroupsModel.Id);

                if (user.Id != userForGroups.userHandlingModel.Id)
                {
                    throw new Exception("Not maching users");
                }
                else if (userForGroups.groupModel.isFinished)
                {
                    throw new Exception("Group already closed");
                }

                try
                {
                    UserCryptoModel userCrypto = userCryptoAppService.GetByUserForGroupsIdAndCryptoSymbol(userForGroups.Id, crypto.symbol);
                    if (userCrypto.cryptoValue < userTradeHystoryModel.spentValue)
                    {
                        throw new KeyNotFoundException();
                    }
                    else if (userTradeHystoryModel.boughtValue != CryptoData.ChangeToDollar(crypto, userTradeHystoryModel.spentValue))
                    {
                        throw new Exception("Invalid Change");
                    }
                    userCrypto.cryptoValue -= userTradeHystoryModel.spentValue;
                    this.IncreaseDollarInGroup(userTradeHystoryModel.boughtValue, userForGroups);
                    return userCryptoAppService.Update(userCrypto);
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
