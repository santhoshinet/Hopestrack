using Telerik.OpenAccess;

namespace HopestrackDL
{
    [Persistent]
    public  class Attachment
    {
        public byte[] Filedata { get; set; }

        public string Filename { get; set; }

        public string MimeType { get; set; }

        public string Id { get; set; }
    }
}