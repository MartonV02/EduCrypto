using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Images
{
    public class ImageModel : IImage
    {
        [Key]
        public int Id { get; set; }
        public string IamageTitle { get ; set; }
        public byte[] ImageData { get; set; }

        [NotMapped]
        public byte[] File { 
            get 
            {
                return encodeFile(this.ImageData);
            }
            set
            {
                ImageData = decodeFile(File);
            }
        }

        private byte[] encodeFile(byte[] data)
        {
            throw new NotImplementedException();
        }

        private byte[] decodeFile(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
