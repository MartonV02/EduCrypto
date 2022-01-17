using Application.CryptoCurrencies;
using Application.UserForGroups;
using Application.UserHandling;
using System.ComponentModel.DataAnnotations;

namespace Application.UserCrypto
{
    public class UserCryptoModel : IUserCrypto
    {
        public int Id { get; set; }

        [Required]
        public UserHandlingModel userHandlingModel { get; set; }
        public int? userId { get; set; }
        [MaxLength(34)]
        public string? walletNumber { get; set; }

        [Required]
        public CryptoCurrencyModel cryptoCurrency { get; set; }
        public int? cryptoId { get; set; }

        [Required]
        [Range(0, 999999999999999.99)]
        public double cryptoValue { get; set; }

        public UserForGroupsModel? userForGroupsModel { get; set; }
        public int? userForGroupId { get; set; }
        [StringLength(34)]
        public string? groupWalletNumber { get; set; }
        public bool isFavourite { get; set; }
    }
}
