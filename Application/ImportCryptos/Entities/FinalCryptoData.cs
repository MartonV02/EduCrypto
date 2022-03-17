using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ImportCryptos.Entities
{
    public class FinalCryptoData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string date_added { get; set; }
        public double? max_supply { get; set; }
        public double circulating_supply { get; set; }
        public string last_updated { get; set; }
        public double percent_Change24h { get; set; }
        public double percent_Change30d { get; set; }
        public double percent_Change90d { get; set; }
        public decimal actual_USD_Price { get; set; }
    }
}
