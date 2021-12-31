using System.Collections.Generic;
using EntityClass = Application.UserCrypto.UserCrypto;

namespace Application.UserCrypto.Interfaces
{
    internal interface IUserCryptoAppService
    {
        public IEnumerable<EntityClass> GetAll();
        public IEnumerable<EntityClass> GetById(int id);
        public IEnumerable<EntityClass> Create();
        public IEnumerable<EntityClass> Update();
        public IEnumerable<EntityClass> Delete();
    }
}
