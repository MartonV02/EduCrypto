using Application.Common;
using Application.CryptoCurrencies;

namespace Application.UserCrypto
{
    public interface IUserCrypto : IIdentity
    {
        public UserFinance.UserFinanceModel userFinance { get; set; }
        public string walletNumber { get; set; }
        public CryptoCurrencyModel cryptoCurrency { get; set; }
        public double cryptoValue { get; set; }
        public UserForGroups.UserForGroupsModel userForGroups { get; set; }
        public string?  groupWalletNumber { get; set; }
        public bool isFavourite { get; set; }
    }
}
