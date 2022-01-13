using Application.Common;
using System;

namespace Application.UserTradeHistory.Interfaces
{
    public interface IUserTradeHistory : IIdentity
    {
        public UserHandling.UserHandling userHandling { get; set; }
        public int? userId { get; set; }
        public DateTime tradeDate { get; set; }
        public CryptoCurrencies.CryptoCurrency spentCryptoCurrency { get; set; }
        public int? spentId { get; set; }
        public decimal spentValue { get; set; }
        public CryptoCurrencies.CryptoCurrency boughtCryptoCurrency { get; set; }
        public int? boughtId { get; set; }
        public decimal boughtValue { get; set; }
        public Group.Group? group { get; set; }
        public int? groupId { get; set; }
    }
}
