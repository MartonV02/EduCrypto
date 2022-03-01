using Application.ImportCryptos;
using Application.ImportCryptos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Common
{
    public static class CryptoData
    {
        private static List<FinalCryptoData> lastResponse { get; set; } = null;
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

        public static List<FinalCryptoData> Check()
        {
            if (lastResponse == null || expirationDate < DateTime.Now)
            {
                ImportCryptosAppService importCryptosAppService = new ImportCryptosAppService();
                lastResponse = importCryptosAppService.GetList().ToList();
            }
            return lastResponse;
        }

        public static FinalCryptoData GetByCryptoSymbol(string cryptoSymbol)
        {
            var result = Check().Where(e => e.symbol == cryptoSymbol).FirstOrDefault();
            if (result == null)
            {
                throw new KeyNotFoundException();
            }
            return result;
        }

        public static decimal ChangeToCrypto(FinalCryptoData crypto, decimal spent)
        {
            return spent / crypto.actual_USD_Price;
        }

        public static decimal ChangeToDollar(FinalCryptoData crypto, decimal spent)
        {
            return spent * crypto.actual_USD_Price;
        }
    }
}
