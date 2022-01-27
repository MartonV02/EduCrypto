using Application.Common;
using Application.CryptoCurrencies;
using Application.UserForGroups;
using Application.UserHandling;
using System;

namespace Application.UserTradeHistory.Interfaces
{
    public interface IUserTradeHistory : IIdentity
    {
        public UserHandlingModel userHandlingModel { get; set; }
        public DateTime tradeDate { get; set; }
        public CryptoCurrencyModel spentCryptoCurrencyModel { get; set; }
        public decimal spentValue { get; set; }
        public CryptoCurrencyModel boughtCryptoCurrencyModel { get; set; }
        public decimal boughtValue { get; set; }
        public UserForGroupsModel? userForGroupsModel { get; set; }
    }
}
