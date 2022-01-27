using Application.Common;
using Application.Group;
using Application.UserHandling;

namespace Application.UserForGroups
{
    public interface IUserForGroups : IIdentity
    {
        public UserHandlingModel userHandlingModel { get; set; }
        public GroupModel groupModel { get; set; }
        public string accesLevel { get; set; }
        public string groupWalletNumber { get; set; }
        public decimal money { get; set; }
    }
}
