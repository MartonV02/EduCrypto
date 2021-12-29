using Application.Common;
using System;

namespace Application.UserTradeHistory
{
    public interface IUserTradeHistory : IIdentity
    {
        public int userId { get; set; }
        public DateTime tradeDate { get; set; }
        public int spentId { get; set; }
        public decimal spentValue { get; set; }
        public int boughtId { get; set; }
        public decimal boughtValue { get; set; }
        public int? droupId { get; set; }
    }
}
