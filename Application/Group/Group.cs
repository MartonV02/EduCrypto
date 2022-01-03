using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Group
{
    class Group: IGroup
    {
        public int Id { get; set; }
        public string name { get; set; }
        public decimal startBudget { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public bool isFinished { get; set; } = true;
    }
}
