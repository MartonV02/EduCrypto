using System.ComponentModel.DataAnnotations;

namespace Application.Common
{
    public class IEntity
    {
        [Key]
        public int id { get; set; } = default(int);
    }
}
