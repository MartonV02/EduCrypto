using System.ComponentModel.DataAnnotations;

namespace Application.Images
{
    public class Image : IImage
    {
        [Key]
        public int Id { get; set; }
        public string IamageTitle { get ; set; }
        public byte[] ImageData { get; set; }
    }
}
