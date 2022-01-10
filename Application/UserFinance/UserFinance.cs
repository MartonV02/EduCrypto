using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.UserFinance
{
    public class UserFinance : IUserFinance
    {
        public int Id { get; set; }
        [Required]
        [Key]
        [ForeignKey("UserHandling")]
        public int userId { get; set; }
        [Required]
        [MaxLength(34)]
        public string walletNumber { get; set; }
        [Required]
        [Range(0,999999999999999.99)]
        public decimal moneyDollar { get; set; }
    }
}
