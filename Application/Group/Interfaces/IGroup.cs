using Application.Common;
using System;

namespace Application.Group.Interfaces
{
    interface IGroup: IIdentity
    {
        public string name { get; set; }
        public decimal startBudget { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public bool isFinished { get; set; } 
    }
}
