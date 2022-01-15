using Application.Common;
using Application.UserHandling.Interfaces;

namespace Application.UserHandling
{
    public class UserHandlingAppService : GenericApplicationService<UserHandlingModel>, IUserHandlingAppService
    {
        public UserHandlingAppService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public UserHandlingAppService() : base(ApplicationDbContext.AppDbContext)
        { }
    }
}
