using Application.UserCrypto;
using Application.UserForGroups;
using Application.UserHandling;
using Application.UserTradeHistory;
using Xunit;

namespace UnitTest
{
    public class UserTradeHistoryAndUserCryptoTest
    {
        [Fact]
        public void UserTrade()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserTradeHistoryAppService userTradeHistoryAppService = new(context);
                UserCryptoAppService userCryptoAppService = new(context);
                UserHandlingAppService userHandlingAppService = new(context);
                UserForGroupsAppService userForGroupsAppService = new(context);

                UserTradeHistoryModel userTrade = new()
                {
                    userHandlingModelId = 1,
                    spentCryptoSymbol = null,
                    spentValue = 100,
                    boughtCryptoSymbol = "LUNA",
                    boughtValue = 0,
                };

                UserTradeHistoryModel trade = userTradeHistoryAppService.CreateWithTransaction(userTrade, userHandlingAppService, userCryptoAppService, userForGroupsAppService);
                UserHandlingModel user = userHandlingAppService.GetById(1);
                UserCryptoModel crypto = userCryptoAppService.GetById(1);

                Assert.Equal(1, trade.userHandlingModelId);
                Assert.NotNull(trade.tradeDate);
                Assert.Null(trade.spentCryptoSymbol);
                Assert.Equal(100, trade.spentValue);
                Assert.Equal("LUNA", trade.boughtCryptoSymbol);
                Assert.True(trade.boughtValue != 0);
                Assert.Null(trade.userForGroupsModelId);

                Assert.Equal(900, user.moneyDollar);

                Assert.Equal(1, crypto.userHandlingModelId);
                Assert.Equal("LUNA", crypto.cryptoSymbol);
                Assert.True(crypto.cryptoValue != 0);
                Assert.Null(crypto.userForGroupsModelId);

                var cryptoValue = crypto.cryptoValue;

                var value = cryptoValue / 2;
                UserTradeHistoryModel userTrade2 = new()
                {
                    userHandlingModelId = 1,
                    spentCryptoSymbol = "LUNA",
                    spentValue = value,
                    boughtCryptoSymbol = null,
                    boughtValue = 0,
                };

                trade = userTradeHistoryAppService.CreateWithTransaction(userTrade2, userHandlingAppService, userCryptoAppService, userForGroupsAppService);
                user = userHandlingAppService.GetById(1);
                crypto = userCryptoAppService.GetById(1);

                Assert.Equal(1, trade.userHandlingModelId);
                Assert.NotNull(trade.tradeDate);
                Assert.Equal("LUNA", trade.spentCryptoSymbol);
                Assert.Equal(value, trade.spentValue);
                Assert.Null(trade.boughtCryptoSymbol);
                Assert.True(trade.boughtValue != 0);
                Assert.Null(trade.userForGroupsModelId);

                Assert.True(user.moneyDollar > 900);

                Assert.Equal(1, crypto.userHandlingModelId);
                Assert.Equal("LUNA", crypto.cryptoSymbol);
                Assert.True(crypto.cryptoValue < cryptoValue);
                Assert.Null(crypto.userForGroupsModelId);
            }
        }

        [Fact]
        public void UserTradeInGroup()
        {
            using (var context = TestDbContext.GenerateTestDbContext())
            {
                UserTradeHistoryAppService userTradeHistoryAppService = new(context);
                UserCryptoAppService userCryptoAppService = new(context);
                UserHandlingAppService userHandlingAppService = new(context);
                UserForGroupsAppService userForGroupsAppService = new(context);

                UserTradeHistoryModel userTrade = new()
                {
                    userHandlingModelId = 1,
                    spentCryptoSymbol = null,
                    spentValue = 50,
                    boughtCryptoSymbol = "LUNA",
                    boughtValue = 0,
                    userForGroupsModelId = 1,
                };

                UserTradeHistoryModel trade = userTradeHistoryAppService.CreateWithTransaction(userTrade, userHandlingAppService, userCryptoAppService, userForGroupsAppService);
                UserForGroupsModel user = userForGroupsAppService.GetById(1);
                UserCryptoModel crypto = userCryptoAppService.GetById(1);

                Assert.Equal(1, trade.userHandlingModelId);
                Assert.NotNull(trade.tradeDate);
                Assert.Null(trade.spentCryptoSymbol);
                Assert.Equal(50, trade.spentValue);
                Assert.Equal("LUNA", trade.boughtCryptoSymbol);
                Assert.True(trade.boughtValue != 0);
                Assert.Equal(1, trade.userForGroupsModelId);

                Assert.Equal(50, user.money);

                Assert.Equal(1, crypto.userHandlingModelId);
                Assert.Equal("LUNA", crypto.cryptoSymbol);
                Assert.True(crypto.cryptoValue != 0);
                Assert.Equal(1, crypto.userForGroupsModelId);

                var cryptoValue = crypto.cryptoValue;

                var value = cryptoValue / 2;
                UserTradeHistoryModel userTrade2 = new()
                {
                    userHandlingModelId = 1,
                    spentCryptoSymbol = "LUNA",
                    spentValue = value,
                    boughtCryptoSymbol = null,
                    boughtValue = 0,
                    userForGroupsModelId = 1,
                };

                trade = userTradeHistoryAppService.CreateWithTransaction(userTrade2, userHandlingAppService, userCryptoAppService, userForGroupsAppService);
                user = userForGroupsAppService.GetById(1);
                crypto = userCryptoAppService.GetById(1);

                Assert.Equal(1, trade.userHandlingModelId);
                Assert.NotNull(trade.tradeDate);
                Assert.Equal("LUNA", trade.spentCryptoSymbol);
                Assert.Equal(value, trade.spentValue);
                Assert.Null(trade.boughtCryptoSymbol);
                Assert.True(trade.boughtValue != 0);
                Assert.Equal(1, trade.userForGroupsModelId);

                Assert.True(user.money > 50);

                Assert.Equal(1, crypto.userHandlingModelId);
                Assert.Equal("LUNA", crypto.cryptoSymbol);
                Assert.True(crypto.cryptoValue < cryptoValue);
                Assert.Equal(1, crypto.userForGroupsModelId);
            }
        }
    }
}
