using Application.Common;
using Application.UserHandling.Interfaces;
using Microsoft.EntityFrameworkCore;
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
                .Include(f => f.profilePicture)
                .ToList();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public override UserHandlingModel GetById(int id)
        {
            var result =  dbContext.Set<UserHandlingModel>()
                .Include(f => f.profilePicture)
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
    }
}
