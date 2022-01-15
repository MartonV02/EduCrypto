using Application.Images;
using Application.UserHandling.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

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
        public string password { get; set; }
        [Required]
        [MaxLength(100)]
        public string email { get; set; }
        [Required]
        [MaxLength(100)]
        public string fullNme { get; set; }
        [Required]
        public DateTime birthDate { get; set; }
        [Required]
        public int xpLevel { get; set; }
        public ImageModel profilePictureId { get; set; }
    }
}
