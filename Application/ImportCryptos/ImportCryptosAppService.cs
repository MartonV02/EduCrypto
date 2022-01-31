using Application.ImportCryptos.Entities;
using System;
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
            queryString["limit"] = "1000";
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());
        }

        public ImportedCryptos GetList()
        {
            ImportedCryptos result = JsonSerializer.Deserialize<ImportedCryptos>(this.GetCryptoList());

            return result;
        }
    }
}
