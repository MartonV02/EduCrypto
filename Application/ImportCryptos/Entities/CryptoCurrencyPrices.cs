using System;

namespace Application.ImportCryptos.Entities
{
    public class CryptoCurrencyPrices
    {
        public decimal price { get; set; }
        public double percent_change_1h { get; set; }
        public double percent_change_24h { get; set; }
        public double percent_change_7d { get; set; }
        public double percent_change_30d { get; set; }
        public double percent_change_90d { get; set; }
        public decimal market_cap_dominance { get; set; }
        public DateTime last_updated { get; set; }
    }
}
