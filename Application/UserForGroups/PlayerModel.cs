using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserForGroups
{
    public class PlayerModel
    {
        public int Place { get; set; }
        public int UserForGroupsModelId { get; set; }
        public string Username { get; set; }
        public string ProfilePictureUrl { get; set; }
        public decimal AllMoney { get; set; }
    }
}
