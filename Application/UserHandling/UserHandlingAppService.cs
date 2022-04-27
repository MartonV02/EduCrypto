using Application.Common;
using Application.UserHandling.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Application.UserHandling
{
    public class UserHandlingAppService : GenericApplicationService<UserHandlingModel>, IUserHandlingAppService
    {
        public UserHandlingAppService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public UserHandlingAppService() : base(ApplicationDbContext.AppDbContext)
        { }

        public override IEnumerable<UserHandlingModel> GetAll()
        {
            var result = dbContext.Set<UserHandlingModel>()
                .ToList();

            if (result.Count == 0)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public override UserHandlingModel GetById(int id)
        {
            var result =  dbContext.Set<UserHandlingModel>()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public override UserHandlingModel Create(UserHandlingModel entity)
        {
            entity.moneyDollar = 1000;
            entity.xpLevel = 0;
            return base.Create(entity);
        }

        public UserHandlingModel GetByEmail(string email)
        {
            var result = dbContext.Set<UserHandlingModel>()
                .Where(x => x.email == email)
                .FirstOrDefault();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }
    }
}
