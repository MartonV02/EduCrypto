using Application.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserHandling
{
    public class UserHandling : IUserHandling
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string fullNme { get; set; }
        public DateTime birthDate { get; set; }
        public int xpLevel { get; set; }
        public Image profilePictureId { get; set; }
    }
}
