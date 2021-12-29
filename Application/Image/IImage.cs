using Application.Common;

namespace Application.Images
{
    public interface IImage: IIdentity
    {
        public string IamageTitle { get; set; }
        public byte[] ImageData { get; set; }
    }
}
