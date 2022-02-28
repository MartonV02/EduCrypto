using Application.ImportCryptos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Web;

namespace Application.ImportCryptos
{
    public class ImportCryptosAppService
    {
        private static string API_KEY = "a32bf73f-f24a-4484-8d59-220e19acd17d";

        private string GetCryptoList()
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "100";
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());
        }

        public IEnumerable<dynamic> GetList()
        {
            var resultData = JsonSerializer.Deserialize<ImportedCryptos>(this.GetCryptoList());
            
            var resultInnerProperties = resultData.data;

            return resultInnerProperties.Select(r => new 
            { 
                r.id,
                r.name,
                r.symbol,
                r.date_added,
                r.max_supply,
                r.circulating_supply,
                r.last_updated,
                //r.quote,
                percent_Change24h = r.quote.USD.percent_change_24h,
                percent_Change30d = r.quote.USD.percent_change_30d,
                percent_Change90d = r.quote.USD.percent_change_90d,
                actual_USD_Price = r.quote.USD.price
            });
        }
    }
}
