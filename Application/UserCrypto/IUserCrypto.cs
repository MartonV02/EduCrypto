using Application.Common;

namespace Application.UserCrypto
{
    public interface IUserCrypto
    {
        public int id { get; set; }
        public string walletNumber { get; set; }
        public int cryptoId { get; set; }
        public double cryptoValue { get; set; }
        public string  groupWalletNumber { get; set; }
    }
}
