using System.Collections.Generic;

namespace xapps
{
    public class BookData
    {
        public string title { get; set; }
        public string link { get; set; }
        public string language { get; set; }
        public string copyright { get; set; }
        public string pubDate { get; set; }
        public string imageUrl { get; set; }
        public int totalResults { get; set; }
        public int startIndex { get; set; }
        public int itemsPerPage { get; set; }
        public int maxResults { get; set; }
        public string queryType { get; set; }
        public string searchCategoryId { get; set; }
        public string searchCategoryName { get; set; }
        public string returnCode { get; set; }
        public string returnMessage { get; set; }

        public List<BookItem> item {get; set; }
    }
}
