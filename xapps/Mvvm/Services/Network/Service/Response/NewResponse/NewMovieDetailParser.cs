using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace xapps
{
    public class NewMovieDetailParser : DefaultParser
    {
        public NewMovieData parseXml(string contents)
        {

            NewMovieData items = new NewMovieData();

            //Xml Parsing  

            XDocument doc = XDocument.Parse(contents);
            Debug.WriteLine(doc);

            //foreach (XElement list in doc.Descendants("boxOfficeResult"))
            //{
            //    items.boxofficeType = getElementData(list.Element("boxofficeType"));
            //    items.showRange = getElementData(list.Element("showRange"));

            //    items.dailyBoxOfficeList = new List<MovieListItem>();

            //    foreach (XElement listItem in list.Descendants("dailyBoxOfficeList"))
            //    {
            //        foreach (XElement item in listItem.Descendants("dailyBoxOffice"))
            //        {
            //            MovieListItem itemObj = new MovieListItem();
            //            itemObj.rnum = getElementData(item.Element("rnum"));
            //            itemObj.rank = getElementData(item.Element("rank"));
            //            itemObj.rankInten = getElementData(item.Element("rankInten"));

            //            itemObj.rankOldAndNew = getElementData(item.Element("rankOldAndNew"));
            //            itemObj.movieCd = getElementData(item.Element("movieCd"));
            //            itemObj.movieNm = getElementData(item.Element("movieNm"));
            //            itemObj.openDt = getElementData(item.Element("openDt"));
            //            itemObj.salesAmt = getElementData(item.Element("salesAmt"));

            //            itemObj.salesShare = getElementData(item.Element("salesShare"));
            //            itemObj.salesInten = getElementData(item.Element("salesInten"));
            //            itemObj.salesChange = getElementData(item.Element("salesChange"));
            //            itemObj.salesAcc = getElementData(item.Element("salesAcc"));
            //            itemObj.audiCnt = getElementData(item.Element("audiCnt"));

            //            itemObj.audiInten = getElementData(item.Element("audiInten"));
            //            itemObj.audiChange = getElementData(item.Element("audiChange"));
            //            itemObj.audiAcc = getElementData(item.Element("audiAcc"));
            //            itemObj.scrnCnt = getElementData(item.Element("scrnCnt"));
            //            itemObj.showCnt = getElementData(item.Element("showCnt"));

            //            Debug.WriteLine("coollhb " + itemObj + "\n\n");

            //            items.dailyBoxOfficeList.Add(itemObj);
            //        }
            //    }
            //}

            return items;
        }
    }
}
