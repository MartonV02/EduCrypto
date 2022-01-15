using System;
using System.ComponentModel.DataAnnotations;
using Application.Group.Interfaces;

namespace Application.Group
{
    public class GroupModel: IGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string name { get; set; }
        [Required]
        [Range(0,999999999999999.99)]
        public decimal startBudget { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public bool isFinished { get; set; } = true;
    }
}
