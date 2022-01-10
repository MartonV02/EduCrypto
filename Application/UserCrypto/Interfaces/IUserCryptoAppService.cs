using System.Collections.Generic;
using EntityClass = Application.UserCrypto.UserCrypto;

namespace Application.UserCrypto.Interfaces
{
    internal interface IUserCryptoAppService
    {
        public IEnumerable<EntityClass> GetAll();
        public EntityClass GetById(int id);
        public IEnumerable<EntityClass> GetByCryptoId(int cryptoId);
        public EntityClass Create(EntityClass entity);
        public EntityClass Update(EntityClass entity);
        public void Delete(int id);
    }
}
