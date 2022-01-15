using Application.Common;
using Application.CryptoCurrencies.Interfaces;

namespace Application.CryptoCurrencies
{
    public class CryptoCurrencyAppService : GenericApplicationService<CryptoCurrencyModel>, ICryptoCurrenciesAppService
    {
        public CryptoCurrencyAppService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public CryptoCurrencyAppService() : base(ApplicationDbContext.AppDbContext)
        { }
    }
}
