using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Images
{
    public interface IImage: IIdentity
    {
        public string IamageTitle { get; set; }
        public byte[] ImageData { get; set; }
    }
}
