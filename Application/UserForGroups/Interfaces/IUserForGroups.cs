using Application.Common;

namespace Application.UserForGroups
{
    public interface IUserForGroups : IIdentity
    {
        public UserHandling.UserHandlingModel userHandling { get; set; }
        public int? userId { get; set; }
        public Group.GroupModel group { get; set; }
        public int? groupId { get; set; }
        public string accesLevel { get; set; }
        public string groupWalletNumber { get; set; }
        public decimal money { get; set; }
    }
}
