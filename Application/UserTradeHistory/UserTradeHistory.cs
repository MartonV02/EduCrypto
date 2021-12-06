using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTradeHistory
{
    class UserTradeHistory : IUserTradeHistory
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public DateTime tradeDate { get; set; } = DateTime.Now;
        public int spentId { get; set; }
        public decimal spentValue { get; set; }
        public int boughtId { get; set; }
        public decimal boughtValue { get; set; }
        public int? droupId { get; set; }
    }
}
