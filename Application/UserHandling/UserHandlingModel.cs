using Application.Images;
using Application.UserHandling.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace Application.UserHandling
{
    public class UserHandlingModel : IUserHandling
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string userName { get; set; }

        [Required]
        [MaxLength(100)]
        public string email { get; set; }

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; }

        [Required]
        public DateTime birthDate { get; set; }

        [Required]
        public int xpLevel { get; set; }

        [MaxLength(34)]
        public string? walletNumber { get; set; }

        [Required]
        [Range(0, 999999999999999.99)]
        public decimal moneyDollar { get; set; }

        public ImageModel? profilePicture { get; set; }
        public int? profilePictureId { get; set; }

        [MaxLength(100)]
        [Required]
        public string PasswordHash { get; set; }

        private string password;
        [NotMapped]
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                this.PasswordHash = HashPassword(password);
            }
        }

        public bool CheckPassword(string pwd)
        {
            return HashPassword(pwd) == this.PasswordHash;
        }

        private string HashPassword(string pwd)
        {
            HashAlgorithm sha = SHA512.Create();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            return Convert.ToBase64String(hash);
        }
    }
}
