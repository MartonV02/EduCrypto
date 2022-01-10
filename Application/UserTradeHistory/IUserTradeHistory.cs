using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int? groupId { get; set; }
    }
}
