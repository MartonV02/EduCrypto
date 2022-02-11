using Application.Common;
using Application.UserForGroups;
using Application.UserHandling;

namespace Application.UserCrypto
{
    public interface IUserCrypto : IIdentity
    {
        public UserHandlingModel userHandlingModel { get; set; }
        public string cryptoSymbol { get; set; }
        public decimal cryptoValue { get; set; }
        public UserForGroupsModel? userForGroupsModel { get; set; }
        public bool isFavourite { get; set; }
    }
}
