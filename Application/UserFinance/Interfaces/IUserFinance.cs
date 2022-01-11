using Application.Common;

namespace Application.UserFinance.Interfaces
{
    public interface IUserFinance : IIdentity
    {
        public int userId { get; set; }
        public string walletNumber { get; set; }
        public decimal moneyDollar { get; set; }
    }
}
