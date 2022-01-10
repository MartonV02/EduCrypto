using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.UserTradeHistory
{
    class UserTradeHistory : IUserTradeHistory
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("UserHandling")]
        public int userId { get; set; }
        [Required]
        public DateTime tradeDate { get; set; } = DateTime.Now;
        [Required]
        [ForeignKey("CryptoCurrency")]
        public int spentId { get; set; }
        [Required]
        [Range(0, 999999999999999.99)]
        public decimal spentValue { get; set; }
        [Required]
        [ForeignKey("CryptoCurrency")]
        public int boughtId { get; set; }
        [Required]
        [Range(0,999999999999999.99)]
        public decimal boughtValue { get; set; }
        [ForeignKey("Group")]
        public int? groupId { get; set; }
    }
}
