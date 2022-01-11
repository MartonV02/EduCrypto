using Application.Common;
using Application.UserFinance.Interfaces;
using System.Collections.Generic;
using System.Linq;
using EntityClass = Application.UserFinance.UserFinance;

namespace Application.UserFinance
{
    public class UserFinanceAppService : GenericApplicationService<UserFinance>, IUserFinanceAppService
    {
        public UserFinanceAppService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public UserFinanceAppService() : base(ApplicationDbContext.AppDbContext)
        { }

        public IEnumerable<EntityClass> GetByUserId(int userId)
        {
            var result = dbContext.Set<EntityClass>().Where(x => x.userId == userId);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.ToList();
        }
    }
}
