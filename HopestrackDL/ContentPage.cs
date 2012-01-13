using Telerik.OpenAccess;

namespace HopestrackDL
{
    [Persistent]
    public class ContentPage
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public string Id { get; set; }
    }
}