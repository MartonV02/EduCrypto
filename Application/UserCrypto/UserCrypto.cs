using Application.CryptoCurrencies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.UserCrypto
{
    public class UserCrypto : IUserCrypto
    {
        public int Id { get; set; }

        [Required]
        public UserFinance.UserFinance userFinance { get; set; }
        [MaxLength(34)]
        public string walletNumber { get; set; }

        [Required]
        public CryptoCurrency cryptoCurrency { get; set; }

        [Required]
        [Range(0, 999999999999999.99)]
        public double cryptoValue { get; set; }

        public UserForGroups.UserForGroups userForGroups { get; set; }
        [StringLength(34)]
        public string? groupWalletNumber { get; set; }
        public bool isFavourite { get; set; }
    }
}
