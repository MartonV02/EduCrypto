using Application.Common;
using Application.Images;
using System;

namespace Application.UserHandling.Interfaces
{
    public interface IUserHandling : IIdentity
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string fullName { get; set; }
        public DateTime birthDate { get; set; }
        public int xpLevel { get; set; }
        public decimal moneyDollar { get; set; }
        public string? walletNumber { get; set; }
        public ImageModel? profilePicture { get; set; }
        public string PasswordHash { get; set; }
        public string Password { get; set; }

        public bool CheckPassword(string pwd);
    }
}
