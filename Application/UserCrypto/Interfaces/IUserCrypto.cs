using Application.Common;
using Application.CryptoCurrencies;
using Application.UserForGroups;
using Application.UserHandling;

namespace Application.UserCrypto
{
    public interface IUserCrypto : IIdentity
    {
        public UserHandlingModel userHandlingModel { get; set; }
        public int? userId { get; set; }
        public string? walletNumber { get; set; }
        public CryptoCurrencyModel cryptoCurrency { get; set; }
        public int? cryptoId { get; set; }
        public double cryptoValue { get; set; }
        public UserForGroupsModel? userForGroupsModel { get; set; }
        public int? userForGroupId { get; set; }
        public string?  groupWalletNumber { get; set; }
        public bool isFavourite { get; set; }
    }
}
