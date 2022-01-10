using Application.Common;
using Application.Images;
using System;

namespace Application.UserHandling
{
    public interface IUserHandling : IIdentity
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string fullNme { get; set; }
        public DateTime birthDate { get; set; }
        public int xpLevel { get; set; }
        public Image profilePictureId { get; set; }
    }
}
