using System.Collections.Generic;
using EntityClass = Application.UserCrypto.UserCryptoModel;

namespace Application.UserCrypto.Interfaces
{
    internal interface IUserCryptoAppService
    {
        public IEnumerable<EntityClass> GetAll();
        public EntityClass GetById(int id);
        public IEnumerable<EntityClass> GetByUserForGroupsId(int userForGroupId);
        public IEnumerable<EntityClass> GetByGroupId(int groupId);
        public IEnumerable<EntityClass> GetByGroupAndUserId(int groupId, int userId);
        public IEnumerable<EntityClass> GetByUserId(int userId);
        public EntityClass GetByUserForGroupsIdAndCryptoSymbol(int userForGroupId, string cryptoSymbol);
        public EntityClass GetByUserIdAndCryptoSymbol(int userId, string cryptoSymbol);
        public EntityClass Create(EntityClass entity);
        public EntityClass Update(EntityClass entity);
        public void Delete(int id);
    }
}
