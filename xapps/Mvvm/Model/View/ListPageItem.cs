using System;
namespace xapps
{
    public class ListPageItem
    {
        public string Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Rank { get; set; }
        public string SubDescription { get; set; }
        public string ThumbUrl { get; set; }

        public string NextPageUrl { get; set; }
    }
}
