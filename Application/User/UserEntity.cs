using Application.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.User
{
    public class UserEntity
    {
        [Key]
        public int Id{ get; set; }

        [StringLength(50)]
        [Required]
        public string UserName { get; set; }

        [StringLength(50)]
        [Required]
        public string Password { get; set; }

        [StringLength(50)]
        [Required]
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int xpLevel { get; set; }
    }
}
