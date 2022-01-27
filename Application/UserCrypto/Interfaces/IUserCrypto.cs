using Application.Common;
using Application.CryptoCurrencies;
using Application.UserForGroups;
using Application.UserHandling;

namespace Application.UserCrypto
{
    public interface IUserCrypto : IIdentity
    {
        public UserHandlingModel userHandlingModel { get; set; }
        public CryptoCurrencyModel cryptoCurrency { get; set; }
        public double cryptoValue { get; set; }
        public UserForGroupsModel? userForGroupsModel { get; set; }
        public bool isFavourite { get; set; }
    }
}
