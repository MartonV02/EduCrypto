using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.UserCrypto
{
    public class UserCrypto : IUserCrypto
    {
        public int Id { get; set; }

        [StringLength(34)]
        [Required]
        public string walletNumber { get; set; }

        [Required]
        [ForeignKey("CryptoCurrency")]
        public int cryptoId { get; set; }

        [Required]
        [Range(0, 999999999999999.99)]
        public double cryptoValue { get; set; }

        [StringLength(34)]
        [Required]
        public string groupWalletNumber { get; set; }
        public bool isFavourite { get; set; }
    }
}
