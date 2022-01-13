using Application.UserTradeHistory.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.UserTradeHistory
{
    public class UserTradeHistory : IUserTradeHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public UserHandling.UserHandling userHandling { get; set; }
        public int? userId { get; set; }
        [Required]
        public DateTime tradeDate { get; set; } = DateTime.Now;
        [Required]
        public CryptoCurrencies.CryptoCurrency spentCryptoCurrency { get; set; }
        public int? spentId { get; set; }
        [Required]
        [Range(0, 999999999999999.99)]
        public decimal spentValue { get; set; }
        [Required]
        public CryptoCurrencies.CryptoCurrency boughtCryptoCurrency { get; set; }
        public int? boughtId { get; set; }
        [Required]
        [Range(0,999999999999999.99)]
        public decimal boughtValue { get; set; }
        public Group.Group? group { get; set; }
        public int? groupId { get; set; }
    }
}
