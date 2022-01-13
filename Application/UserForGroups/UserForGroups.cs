using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.UserForGroups
{
    public class UserForGroups: IUserForGroups
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public UserHandling.UserHandling userHandling { get; set; }
        public int? userId { get; set; }

        [Required]
        public Group.Group group { get; set; }
        public int? groupId { get; set; }

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
