using Application.CryptoCurrencies.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Application.CryptoCurrencies
{
    public class CryptoCurrencyModel : ICryptoCurrency
    { 
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string name { get; set; }
        [Required]
        [MaxLength(5)]
        public string contraction { get; set; }
        [Required]
        [Range(0,999999999999999.99)]
        public decimal price { get; set; }
        [Required]
        [Range(0, 9999.99)]
        public decimal dayPercent { get; set; }
        [Required]
        [Range(0, 9999.99)]
        public decimal weekPercent { get; set; }
        [Required]
        [Range(0, 999999999999999.99)]
        public decimal marketCap { get; set; }
        [Required]
        [Range(0, 999999999999999.99)]
        public decimal volume { get; set; }
        [Required]
        [Range(0, 999999999999999.99)]
        public decimal circulatingSupply { get; set; }
    }
}
