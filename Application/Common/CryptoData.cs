using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ImportCryptos;
using Application.ImportCryptos.Entities;

namespace Application.Common
{
    public static class CryptoData
    {
        private static List<CryptoPropertiesModel> lastResponse { get; set; } = null;
        public static DateTime expirationDate
        {
            get
            {
                return expirationDate;
            }
            set
            {
                expirationDate = value.AddMinutes(5);
            } 
        }

        public static List<CryptoPropertiesModel> Check()
        {
            if (lastResponse == null || expirationDate < DateTime.Now)
            {
                ImportCryptosAppService importCryptosAppService = new ImportCryptosAppService();
                lastResponse = importCryptosAppService.GetList().ToList();
            }
            return lastResponse;
        }
    }
}
