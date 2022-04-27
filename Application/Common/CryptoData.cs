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
        public static DateTime expirationDate { get; set; }

        public static List<FinalCryptoData> Check()
        {
            if (lastResponse == null || expirationDate.AddMinutes(5) < DateTime.Now)
            {
                ImportCryptosAppService importCryptosAppService = new();
                expirationDate = DateTime.Now;
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
