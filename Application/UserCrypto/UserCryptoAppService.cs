using Application.Common;
using Application.UserCrypto.Interfaces;
using System.Collections.Generic;
using System.Linq;
using EntityClass = Application.UserCrypto.UserCryptoModel;

namespace Application.UserCrypto
{
    public class UserCryptoAppService : GenericApplicationService<EntityClass>, IUserCryptoAppService
    {
        public UserCryptoAppService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public UserCryptoAppService() : base(ApplicationDbContext.AppDbContext)
        { }

        public IEnumerable<EntityClass> GetByUserId(string walletNumber)
        {
            var result = dbContext.Set<EntityClass>().Where(x => x.walletNumber == walletNumber);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public IEnumerable<EntityClass> GetByCryptoId(int cryptoId)
        {
            throw new System.NotImplementedException();
        }
    }
}
