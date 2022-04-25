using Application.Common;
using Application.UserForGroups;
using Application.UserHandling;
using System;

namespace Application.UserTradeHistory.Interfaces
{
    public interface IUserTradeHistory : IIdentity
    {
        public UserHandlingModel userHandlingModel { get; set; }
        public DateTime? tradeDate { get; set; }
        public string? spentCryptoSymbol { get; set; }
        public decimal spentValue { get; set; }
        public string? boughtCryptoSymbol { get; set; }
        public decimal boughtValue { get; set; }
        public UserForGroupsModel? userForGroupsModel { get; set; }
        public decimal actualPrice { get; set; }
    }
}
