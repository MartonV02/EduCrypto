using Application.Common;

namespace Application.UserFinance.Interfaces
{
    public interface IUserFinance : IIdentity
    {
        public UserHandling.UserHandling userHandling { get; set; }
        public string walletNumber { get; set; }
        public decimal moneyDollar { get; set; }
    }
}
