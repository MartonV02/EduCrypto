﻿using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CryptoCurrencies
{
    interface ICryptoCurrency : IIdentity
    {
        public string name { get; set; }
        public string contraction { get; set; }
        public decimal price{ get; set; }
        public decimal dayPercent { get; set; }
        public decimal weekPercent { get; set; }
        public decimal marketCap { get; set; }
        public decimal volume { get; set; }
        public decimal circulatingSupply { get; set; }
    }
}
