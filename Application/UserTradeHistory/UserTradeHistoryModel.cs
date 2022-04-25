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

        public UserHandlingModel userHandlingModel { get; set; }
        [Required]
        public int userHandlingModelId { get; set; }

        public DateTime? tradeDate { get; set; } = DateTime.Now;

        public string? spentCryptoSymbol { get; set; }

        [Required]
        [Range(0, 999999999999999.99)]
        public decimal spentValue { get; set; }

        public string? boughtCryptoSymbol { get; set; }


        [Required]
        [Range(0,999999999999999.99)]
        public decimal boughtValue { get; set; }

        public UserForGroupsModel? userForGroupsModel { get; set; }
        public int? userForGroupsModelId { get; set; }

        public decimal actualPrice { get; set; }
    }
}
