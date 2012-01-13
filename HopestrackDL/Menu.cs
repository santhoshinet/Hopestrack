using System;
using Telerik.OpenAccess;

namespace HopestrackDL
{
    [Persistent]
    public class Menu
    {
        public Menu()
        {
            ParentId = string.Empty;
            Id = DateTime.Now.ToString("yyddmmHHss");
            Page = new ContentPage();
        }

        public string Name { get; set; }

        public string Id { get; set; }

        public string ParentId { get; set; }

        public ContentPage Page { get; set; }
    }
}