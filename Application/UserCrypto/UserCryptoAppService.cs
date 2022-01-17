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

        public override EntityClass Create(EntityClass entity)
        {
            entity.userId = entity.userHandlingModel.Id;
            entity.cryptoId = entity.cryptoCurrency.Id;
            if (entity.userForGroupsModel !=null)
            {
                entity.userForGroupId = entity.userForGroupsModel.Id;
            }
            return base.Create(entity);
        }

        //Vissza adja egy adott user adott grupphoz tartozó valutáit
        public IEnumerable<EntityClass> GetByUserForGroupsId(int userForGroupId)
        {
            var result = dbContext.Set<EntityClass>().Where(x => x.userForGroupId == userForGroupId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        //Viszza adja egy adott gruphoz tartozó összes birtokolt valutát
        public IEnumerable<EntityClass> GetByGroupId(int groupId)
        {
            var result = dbContext.Set<EntityClass>().Where(x => x.userForGroupsModel.groupModel.Id == groupId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        //Vissza adja egy adott grup adott cryptovaluta birtoklásokat
        public IEnumerable<EntityClass> GetByGroupAndCryptoId(int groupId, int cryptoId)
        {
            var result = dbContext.Set<EntityClass>().Where(x => x.userForGroupsModel.groupModel.Id == groupId && x.cryptoId == cryptoId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        
        public EntityClass GetByGroupAndUserId(int groupId, int userId)
        {
            var result = dbContext.Set<EntityClass>().Where(x => x.userForGroupsModel.groupModel.Id == groupId && x.userId == userId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.FirstOrDefault();
        }
    }
}
