using System.Collections.Generic;
using EntityClass = Application.CryptoCurrencies.CryptoCurrencyModel;

namespace Application.CryptoCurrencies.Interfaces
{
    public interface ICryptoCurrenciesAppService
    {
        public IEnumerable<EntityClass> GetAll();
        public EntityClass GetById(int id);
        public EntityClass Create(EntityClass entity);
        public EntityClass Update(EntityClass entity);
        public void Delete(int id);
    }
}
