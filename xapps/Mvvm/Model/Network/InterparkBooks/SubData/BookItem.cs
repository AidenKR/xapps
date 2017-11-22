namespace xapps
{
    public class BookItem
    {
        public long itemId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string pubDate { get; set; }
        public long priceStandard { get; set; }
        public long priceSales { get; set; }
        public string saleStatus { get; set; }
        public string discountRate { get; set; }
        public string mileage { get; set; }
        public string mileageRate { get; set; }
        public string coverSmallUrl { get; set; }
        public string coverLargeUrl { get; set; }
        public string categoryId { get; set; }
        public string categoryName { get; set; }
        public string publisher { get; set; }
        public string customerReviewRank { get; set; }
        public string author { get; set; }
        public string translator { get; set; }
        public string isbn { get; set; }
        public string link { get; set; }
        public string mobileLink { get; set; }
        public string additionalLink { get; set; }
        public long reviewCount { get; set; }
        public long rank { get; set; }

        public override string ToString()
        {
            return string.Format("[BookItem: itemId={0}, title={1}, description={2}, pubDate={3}, priceStandard={4}, priceSales={5}, saleStatus={6}, discountRate={7}, mileage={8}, mileageRate={9}, coverSmallUrl={10}, coverLargeUrl={11}, categoryId={12}, categoryName={13}, publisher={14}, customerReviewRank={15}, author={16}, translator={17}, isbn={18}, link={19}, mobileLink={20}, additionalLink={21}, reviewCount={22}, rank={23}]", itemId, title, description, pubDate, priceStandard, priceSales, saleStatus, discountRate, mileage, mileageRate, coverSmallUrl, coverLargeUrl, categoryId, categoryName, publisher, customerReviewRank, author, translator, isbn, link, mobileLink, additionalLink, reviewCount, rank);
        }    
    }
}
