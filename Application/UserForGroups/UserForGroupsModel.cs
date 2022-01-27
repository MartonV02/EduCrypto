using Application.Group;
using Application.UserHandling;
using System.ComponentModel.DataAnnotations;

namespace Application.UserForGroups
{
    public class UserForGroupsModel: IUserForGroups
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public UserHandlingModel userHandlingModel { get; set; }

        [Required]
        public GroupModel groupModel { get; set; }

        [Required]
        [MaxLength(50)]
        public string accesLevel { get; set; }

        [Required]
        [MaxLength(34)]
        public string groupWalletNumber { get; set; }

        [Required]
        [Range(0, 999999999999999.99)]
        public decimal money { get; set; }
    }
}
