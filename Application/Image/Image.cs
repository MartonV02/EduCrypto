using Application.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Images
{
    public class Image : IImage
    {
        public int Id { get; set; }
        public string IamageTitle { get ; set; }
        public byte[] ImageData { get; set; }
    }
}
