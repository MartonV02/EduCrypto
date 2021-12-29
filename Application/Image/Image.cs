namespace Application.Images
{
    public class Image : IImage
    {
        public int Id { get; set; }
        public string IamageTitle { get ; set; }
        public byte[] ImageData { get; set; }
    }
}
