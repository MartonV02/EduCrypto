using Application.Common;
using Application.UserCrypto.Interfaces;
using System.Collections.Generic;
using System.Linq;
using EntityClass = Application.UserCrypto.UserCrypto;

namespace Application.UserCrypto
{
    public class UserCryptoAppService : GenericApplicationService<EntityClass>, IUserCryptoAppService
    {
        public UserCryptoAppService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public UserCryptoAppService() : base(ApplicationDbContext.AppDbContext)
        { }

        public IEnumerable<EntityClass> GetByUserId(int cryptoId)
        {
            var result = dbContext.Set<EntityClass>().Where(x => x.cryptoId == cryptoId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }
    }
}
