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
                .Include(f => f.cryptoCurrency)
                .Include(e => e.userHandlingModel)
                .Include(e => e.userForGroupsModel);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        public override EntityClass GetById(int id)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.cryptoCurrency)
                .Include(e => e.userHandlingModel)
                .Include(e => e.userForGroupsModel)
                .Where(x => x.Id == id);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.FirstOrDefault();
        }

        //Vissza adja egy adott user adott grupphoz tartozó valutáit
        public IEnumerable<EntityClass> GetByUserForGroupsId(int userForGroupId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.cryptoCurrency)
                .Include(e => e.userHandlingModel)
                .Include(e => e.userForGroupsModel)
                .Where(x => x.userForGroupsModel.Id == userForGroupId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        //Viszza adja egy adott gruphoz tartozó összes birtokolt valutát
        public IEnumerable<EntityClass> GetByGroupId(int groupId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.cryptoCurrency)
                .Include(e => e.userHandlingModel)
                .Include(e => e.userForGroupsModel)
                .Where(x => x.userForGroupsModel.groupModel.Id == groupId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        //Vissza adja egy adott grup adott cryptovaluta birtoklásokat
        public IEnumerable<EntityClass> GetByGroupAndCryptoId(int groupId, int cryptoId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.cryptoCurrency)
                .Include(e => e.userHandlingModel)
                .Include(e => e.userForGroupsModel)
                .Where(x => x.userForGroupsModel.groupModel.Id == groupId && x.cryptoCurrency.Id == cryptoId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }

        
        public IEnumerable<EntityClass> GetByGroupAndUserId(int groupId, int userId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.cryptoCurrency)
                .Include(e => e.userHandlingModel)
                .Include(e => e.userForGroupsModel)
                .Where(x => x.userForGroupsModel.groupModel.Id == groupId && x.userForGroupsModel.Id == userId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }
    }
}
