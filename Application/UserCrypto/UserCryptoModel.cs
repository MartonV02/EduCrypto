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
        [Required]
        public int userHandlingModelId { get; set; }

        [Required]
        public string cryptoSymbol { get; set; }

        [Required]
        [Range(0, 999999999999999.99)]
        public decimal cryptoValue { get; set; }

        public UserForGroupsModel? userForGroupsModel { get; set; }
        public int? userForGroupsModelId { get; set; }

        public bool isFavourite { get; set; }
    }
}
