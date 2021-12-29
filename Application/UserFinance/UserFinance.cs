namespace Application.UserFinance
{
    public class UserFinance : IUserFinance
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string walletNumber { get; set; }
        public decimal moneyDollar { get; set; }
    }
}
