using Application.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.UserCrypto
{
    public class UserCrypto: IEntity, IUserCrypto 
    {
        [StringLength(34)]
        [Required]
        public string walletNumber { get; set; }
        
        [Required]
        public int cryptoId { get; set; }

        [Required]
        [Range(0, 999999999999999.99)]
        public double cryptoValue { get; set; }

        [StringLength(34)]
        [Required]
        public string groupWalletNumber { get; set; }
    }
}
