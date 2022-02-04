using Application.CryptoCurrencies;
using Application.UserForGroups;
using Application.UserHandling;
using Application.UserTradeHistory.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.UserTradeHistory
{
    public class UserTradeHistoryModel : IUserTradeHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public UserHandlingModel userHandlingModel { get; set; }
        [Required]
        public DateTime tradeDate { get; set; } = DateTime.Now;
        [Required]
        public CryptoCurrencyModel? spentCryptoCurrencyModel { get; set; }
        [Required]
        [Range(0, 999999999999999.99)]
        public decimal spentValue { get; set; }
        [Required]
        public CryptoCurrencyModel? boughtCryptoCurrencyModel { get; set; }
        [Required]
        [Range(0,999999999999999.99)]
        public decimal boughtValue { get; set; }
        public UserForGroupsModel? userForGroupsModel { get; set; }
    }
}
