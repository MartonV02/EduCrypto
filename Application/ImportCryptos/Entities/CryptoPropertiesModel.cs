using System;

namespace Application.ImportCryptos.Entities
{
    public class CryptoPropertiesModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string date_added { get; set; }
        public double? max_supply { get; set; }
        public double circulating_supply { get; set; }
        public string last_updated { get; set; }
        public CryptoUSD quote { get; set; }
    }
}
