using Application.Common;
using Application.CryptoCurrencies;
using Application.Group;
using Application.UserHandling;
using System;

namespace Application.UserTradeHistory.Interfaces
{
    public interface IUserTradeHistory : IIdentity
    {
        public UserHandlingModel userHandlingModel { get; set; }
        public int? userId { get; set; }
        public DateTime tradeDate { get; set; }
        public CryptoCurrencyModel spentCryptoCurrencyModel { get; set; }
        public int? spentId { get; set; }
        public decimal spentValue { get; set; }
        public CryptoCurrencyModel boughtCryptoCurrencyModel { get; set; }
        public int? boughtId { get; set; }
        public decimal boughtValue { get; set; }
        public GroupModel? groupModel { get; set; }
        public int? groupId { get; set; }
    }
}
