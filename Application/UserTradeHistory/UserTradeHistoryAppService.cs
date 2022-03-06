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
            if (userTradeHystoryModel.spentCryptoSymbol == null && userTradeHystoryModel.boughtCryptoSymbol != null && userTradeHystoryModel.userForGroupsModelId == null)
                this.TradeDollarToCrypto(userTradeHystoryModel, userAppService, userCryptoAppService);
            else if (userTradeHystoryModel.spentCryptoSymbol != null && userTradeHystoryModel.boughtCryptoSymbol == null && userTradeHystoryModel.userForGroupsModelId == null)
                this.TradeCryptoToDollar(userTradeHystoryModel, userAppService, userCryptoAppService);
            else if (userTradeHystoryModel.spentCryptoSymbol == null && userTradeHystoryModel.boughtCryptoSymbol != null && userTradeHystoryModel.userForGroupsModelId != null)
                this.TradeDollarToCryptoInGroup(userTradeHystoryModel, userAppService, userCryptoAppService, userForGroupsAppService);
            else if (userTradeHystoryModel.spentCryptoSymbol != null && userTradeHystoryModel.boughtCryptoSymbol == null && userTradeHystoryModel.userForGroupsModelId != null)
                this.TradeCryptoToDollarInGroup(userTradeHystoryModel, userAppService, userCryptoAppService, userForGroupsAppService);

            return this.Create(userTradeHystoryModel);
        }

        public override IEnumerable<EntityClass> GetAll()
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(h => h.userForGroupsModel).ThenInclude(i => i.groupModel)
                .ToList();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public override EntityClass GetById(int id)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(h => h.userForGroupsModel).ThenInclude(i => i.groupModel)
                .Where(f => f.Id == id)
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
                .Include(e => e.userHandlingModel)
                .Where(x => x.userHandlingModel.Id == userId && x.userForGroupsModel == null)
                .ToList();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public IEnumerable<EntityClass> GetByGroupId(int groupId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(h => h.userForGroupsModel).ThenInclude(i => i.groupModel)
                .Where(x => x.userForGroupsModel.groupModel.Id == groupId)
                .ToList();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public IEnumerable<EntityClass> GetByUserAndGroupId(int userId, int groupId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(h => h.userForGroupsModel).ThenInclude(i => i.groupModel)
                .Where(x => x.userForGroupsModel.groupModel.Id == groupId && x.userHandlingModel.Id == userId)
                .ToList();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public IEnumerable<EntityClass> GetByCryptoCurrencySymbol(string cryptoSymbol)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(h => h.userForGroupsModel).ThenInclude(i => i.groupModel)
                .Where(x => x.boughtCryptoSymbol == cryptoSymbol)
                .ToList();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public IEnumerable<EntityClass> GetByUserIdAndCryptoCurrencySymbol(int userId, string cryptoSymbol)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(h => h.userForGroupsModel).ThenInclude(i => i.groupModel)
                .Where(x => x.userHandlingModel.Id == userId && x.boughtCryptoSymbol == cryptoSymbol)
                .ToList();

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
                UserHandlingModel user = userAppService.GetById(userTradeHystoryModel.userHandlingModelId);
                FinalCryptoData crypto = CryptoData.GetByCryptoSymbol(userTradeHystoryModel.boughtCryptoSymbol);
                if (user.moneyDollar < userTradeHystoryModel.spentValue)
                {
                    throw new Exception("Not Enough Money");
                }
                else if (userTradeHystoryModel.boughtValue != CryptoData.ChangeToCrypto(crypto, userTradeHystoryModel.spentValue))
                {
                    throw new Exception($"Invalid Change -> Correct: {CryptoData.ChangeToCrypto(crypto, userTradeHystoryModel.spentValue)}");
                }
                else
                {
                    UserCryptoModel userCryptoModel = userCryptoAppService.GetByUserIdAndCryptoSymbol(user.Id, crypto.symbol);
                    if (userCryptoModel != null)
                    {
                        userCryptoModel.cryptoValue += userTradeHystoryModel.boughtValue;
                        this.DecreaseDollar(userTradeHystoryModel.spentValue, user, userAppService);
                        return userCryptoAppService.Update(userCryptoModel);
                    }
                    else
                    {
                        userCryptoModel = new UserCryptoModel
                        {
                            Id = 0,
                            userHandlingModel = user,
                            cryptoSymbol = crypto.symbol,
                            cryptoValue = userTradeHystoryModel.boughtValue,
                            isFavourite = false
                        };
                        this.DecreaseDollar(userTradeHystoryModel.spentValue, user, userAppService);
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
                UserHandlingModel user = userAppService.GetById(userTradeHystoryModel.userHandlingModelId);
                FinalCryptoData crypto = CryptoData.GetByCryptoSymbol(userTradeHystoryModel.spentCryptoSymbol);

                try
                {
                    UserCryptoModel userCrypto = userCryptoAppService.GetByUserIdAndCryptoSymbol(user.Id, crypto.symbol);
                    if (userCrypto.cryptoValue < userTradeHystoryModel.spentValue || userCrypto == null)
                    {
                        throw new KeyNotFoundException();
                    }
                    else if (userTradeHystoryModel.boughtValue != CryptoData.ChangeToDollar(crypto, userTradeHystoryModel.spentValue))
                    {
                        throw new Exception($"Invalid Change -> Correct: {CryptoData.ChangeToDollar(crypto, userTradeHystoryModel.spentValue)}");
                    }
                    else
                    {
                        userCrypto.cryptoValue -= userTradeHystoryModel.spentValue;
                        this.IncreaseDollar(userTradeHystoryModel.boughtValue, user, userAppService);
                        return userCryptoAppService.Update(userCrypto);
                    }
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
                UserHandlingModel user = userAppService.GetById(userTradeHystoryModel.userHandlingModelId);
                UserForGroupsModel userForGroups = userForGroupsAppService.GetById(userTradeHystoryModel.userForGroupsModelId.GetValueOrDefault());
                FinalCryptoData crypto = CryptoData.GetByCryptoSymbol(userTradeHystoryModel.boughtCryptoSymbol);

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
                    throw new Exception($"Invalid Change -> Correct: {CryptoData.ChangeToCrypto(crypto, userTradeHystoryModel.spentValue)}");
                }
                else
                {
                    UserCryptoModel userCryptoModel = userCryptoAppService.GetByUserForGroupsIdAndCryptoSymbol(userForGroups.Id, crypto.symbol);
                    if (userCryptoModel != null)
                    {
                        userCryptoModel.cryptoValue += userTradeHystoryModel.boughtValue;
                        this.DecreaseDollarInGroup(userTradeHystoryModel.spentValue, userForGroups, userForGroupsAppService);
                        return userCryptoAppService.Update(userCryptoModel);
                    }
                    else
                    {
                        userCryptoModel = new UserCryptoModel
                        {
                            Id = 0,
                            userHandlingModel = user,
                            cryptoSymbol = crypto.symbol,
                            cryptoValue = userTradeHystoryModel.boughtValue,
                            userForGroupsModel = userForGroups,
                            isFavourite = false
                        };
                        this.DecreaseDollarInGroup(userTradeHystoryModel.spentValue, userForGroups, userForGroupsAppService);
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
                UserHandlingModel user = userAppService.GetById(userTradeHystoryModel.userHandlingModelId);
                FinalCryptoData crypto = CryptoData.GetByCryptoSymbol(userTradeHystoryModel.spentCryptoSymbol);
                UserForGroupsModel userForGroups = userForGroupsAppService.GetById(userTradeHystoryModel.userForGroupsModelId.GetValueOrDefault());

                if (user.Id != userForGroups.userHandlingModel.Id)
                {
                    throw new Exception("Not maching users");
                }
                else if (userForGroups.groupModel.isFinished)
                {
                    throw new Exception("Group already closed");
                }
                else
                {
                    try
                    {
                        UserCryptoModel userCrypto = userCryptoAppService.GetByUserForGroupsIdAndCryptoSymbol(userForGroups.Id, crypto.symbol);
                        if (userCrypto.cryptoValue < userTradeHystoryModel.spentValue || userCrypto == null)
                        {
                            throw new KeyNotFoundException();
                        }
                        else if (userTradeHystoryModel.boughtValue != CryptoData.ChangeToDollar(crypto, userTradeHystoryModel.spentValue))
                        {
                            throw new Exception($"Invalid Change -> Correct: {CryptoData.ChangeToDollar(crypto, userTradeHystoryModel.spentValue)}");
                        }
                        else
                        {
                            userCrypto.cryptoValue -= userTradeHystoryModel.spentValue;
                            this.IncreaseDollarInGroup(userTradeHystoryModel.boughtValue, userForGroups, userForGroupsAppService);
                            return userCryptoAppService.Update(userCrypto);
                        }
                    }
                    catch (KeyNotFoundException)
                    {
                        throw new Exception("Not enough Crypto currency");
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("No such a user or crypto value");
            }
        }

        private void DecreaseDollar(decimal dollar, UserHandlingModel user, UserHandlingAppService userAppService)
        {
            user.moneyDollar -= dollar;
            userAppService.Update(user);
        }

        private void IncreaseDollar(decimal dollar, UserHandlingModel user, UserHandlingAppService userAppService)
        {
            user.moneyDollar += dollar;
            userAppService.Update(user);
        }

        private void DecreaseDollarInGroup(decimal dollar, UserForGroupsModel userForGroups, UserForGroupsAppService userForGroupsAppService)
        {
            userForGroups.money -= dollar;
            userForGroupsAppService.Update(userForGroups);
        }

        private void IncreaseDollarInGroup(decimal dollar, UserForGroupsModel userForGroups, UserForGroupsAppService userForGroupsAppService)
        {
            userForGroups.money += dollar;
            userForGroupsAppService.Update(userForGroups);
        }
    }
}
