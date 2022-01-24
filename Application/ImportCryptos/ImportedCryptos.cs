using System;

namespace Application.ImportCryptos
{
    public class ImportedCryptos
    {
        public int Id;
        public string name;
        public string symbol;
        public string slug;
        public string num_market_pairs;
        public string date_added;
        public int max_supply;
        public int circulating_supply;
        public int total_supply;
        public DateTime last_updated;
    }
}
