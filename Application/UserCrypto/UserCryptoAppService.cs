using Application.Common;
using Application.UserCrypto.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public override IEnumerable<EntityClass> GetAll()
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(e => e.userForGroupsModel).ThenInclude(i => i.groupModel)
                .ToList(); 

            if (result.Count == 0)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public override EntityClass GetById(int id)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(e => e.userForGroupsModel).ThenInclude(i => i.groupModel)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        //Vissza adja egy adott user adott grupphoz tartozó valutáit
        public IEnumerable<EntityClass> GetByUserForGroupsId(int userForGroupId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(e => e.userForGroupsModel).ThenInclude(i => i.groupModel)
                .Where(x => x.userForGroupsModelId == userForGroupId)
                .ToList();

            if (result.Count == 0)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        //Viszza adja egy adott gruphoz tartozó összes birtokolt valutát
        public IEnumerable<EntityClass> GetByGroupId(int groupId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(e => e.userForGroupsModel).ThenInclude(i => i.groupModel)
                .Where(x => x.userForGroupsModel.groupModel.Id == groupId)
                .ToList();

            if (result.Count == 0)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        //Vissza adja egy adott grup adott cryptovaluta birtoklásokat
        public IEnumerable<EntityClass> GetByGroupAndCryptoSymbol(int groupId, string cryptoSymbol)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(e => e.userForGroupsModel).ThenInclude(i => i.groupModel)
                .Where(x => x.userForGroupsModel.groupModel.Id == groupId && x.cryptoSymbol == cryptoSymbol)
                .ToList();

            if (result.Count == 0)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }
        
        public IEnumerable<EntityClass> GetByGroupAndUserId(int groupId, int userId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(e => e.userForGroupsModel).ThenInclude(i => i.groupModel)
                .Where(x => x.userForGroupsModel.groupModel.Id == groupId && x.userForGroupsModel.Id == userId)
                .ToList();

            if (result.Count == 0)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public EntityClass GetByUserIdAndCryptoSymbol(int userId, string cryptoSymbol)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Where(x => x.userHandlingModel.Id == userId && x.cryptoSymbol == cryptoSymbol && x.userForGroupsModel == null)
                .FirstOrDefault();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public EntityClass GetByUserForGroupsIdAndCryptoSymbol(int userForGroupId, string cryptoSymbol)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(e => e.userHandlingModel)
                .Include(e => e.userForGroupsModel).ThenInclude(i => i.groupModel)
                .Where(x => x.userForGroupsModel.Id == userForGroupId && x.cryptoSymbol == cryptoSymbol)
                .FirstOrDefault();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }
    }
}
