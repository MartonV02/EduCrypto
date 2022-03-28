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

            if (result.Count == 0)
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

        public override UserHandlingModel Update(UserHandlingModel user)
        {
            UserHandlingModel modified = this.GetById(user.Id);
            modified.Id = user.Id;
            modified.userName = user.userName;
            modified.email = user.email;
            modified.fullName = user.fullName;
            modified.birthDate = user.birthDate;
            modified.Password = user.Password;
            UserHandlingModel result = base.Update(modified);
            return new UserHandlingModel()
            {
                Id = result.Id,
                userName = result.userName,
                email = result.email,
                fullName = result.fullName,
                birthDate = result.birthDate,
                moneyDollar = result.moneyDollar,
                xpLevel = result.xpLevel,
            };
        }

        public UserHandlingModel GetByEmail(string email)
        {
            var result = dbContext.Set<UserHandlingModel>()
                .Include(f => f.profilePicture)
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
