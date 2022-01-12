using Application.Common;
using Application.UserHandling.Interfaces;

namespace Application.UserHandling
{
    public class UserHandlingAppService : GenericApplicationService<UserHandling>, IUserHandlingAppService
    {
        public UserHandlingAppService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public UserHandlingAppService() : base(ApplicationDbContext.AppDbContext)
        { }
    }
}
