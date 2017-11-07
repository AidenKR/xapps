using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace xapps
{
    public class MovieDataParser : DefaultParser
    {
        public MovieData parseXml(string contents)
        {

            MovieData items = new MovieData();

            //Xml Parsing  

            XDocument doc = XDocument.Parse(contents);
            Debug.WriteLine(doc);

            foreach (XElement list in doc.Descendants("Row"))
            {
                items.DOCID = getElementData(list.Element("DOCID"));
                items.movieId = getElementData(list.Element("movieId"));
                items.movieSeq = getElementData(list.Element("movieSeq"));

                items.title = getElementData(list.Element("title"));
                items.titleEng = getElementData(list.Element("titleEng"));
                items.titleOrg = getElementData(list.Element("titleOrg"));
                items.titleEtc = getElementData(list.Element("titleEtc"));
                items.prodYear = getElementData(list.Element("prodYear"));

                items.directors = new List<director>();
                foreach (XElement listItem in list.Descendants("directors"))
                {
                    foreach (XElement item in listItem.Descendants("director"))
                    {
                        director itemObj = new director();
                        itemObj.directorNm = getElementData(item.Element("directorNm"));
                        itemObj.directorId = getElementData(item.Element("directorId"));

                        items.directors.Add(itemObj);
                    }
                }

                items.actors = new List<actor>();
                foreach (XElement listItem in list.Descendants("actors"))
                {
                    foreach (XElement item in listItem.Descendants("actor"))
                    {
                        actor itemObj = new actor();
                        itemObj.actorNm = getElementData(item.Element("actorNm"));
                        itemObj.actorId = getElementData(item.Element("actorId"));

                        items.actors.Add(itemObj);
                    }
                }


                items.nation = getElementData(list.Element("nation"));
                items.company = getElementData(list.Element("company"));
                items.plot = getElementData(list.Element("plot"));

                items.runtime = getElementData(list.Element("runtime"));
                items.rating = getElementData(list.Element("rating"));
                items.genre = getElementData(list.Element("genre"));
                items.kmdbUrl = getElementData(list.Element("kmdbUrl"));
                items.type = getElementData(list.Element("type"));
                items.use = getElementData(list.Element("use"));

                items.episodes = getElementData(list.Element("episodes"));
                items.ratedYn = getElementData(list.Element("ratedYn"));
                items.repRatDate = getElementData(list.Element("repRatDate"));
                items.repRlsDate = getElementData(list.Element("repRlsDate"));

                items.ratings = new List<rating>();
                foreach (XElement listItem in list.Descendants("ratings"))
                {
                    foreach (XElement item in listItem.Descendants("rating"))
                    {
                        rating itemObj = new rating();
                        itemObj.ratingMain = getElementData(item.Element("ratingMain"));
                        itemObj.ratingDate = getElementData(item.Element("ratingDate"));
                        itemObj.ratingNo = getElementData(item.Element("ratingNo"));
                        itemObj.ratingGrade = getElementData(item.Element("ratingGrade"));
                        itemObj.releaseDate = getElementData(item.Element("releaseDate"));
                        itemObj.runtime = getElementData(item.Element("runtime"));
                        items.ratings.Add(itemObj);
                    }
                }

                items.keywords = getElementData(list.Element("keywords"));
                items.posters = getElementData(list.Element("posters"));
                items.stlls = getElementData(list.Element("stlls"));

                items.staffs = new List<staff>();
                foreach (XElement listItem in list.Descendants("staffs"))
                {
                    foreach (XElement item in listItem.Descendants("staff"))
                    {
                        staff itemObj = new staff();
                        itemObj.staffNm = getElementData(item.Element("staffNm"));
                        itemObj.staffRoleGroup = getElementData(item.Element("staffRoleGroup"));
                        itemObj.staffRole = getElementData(item.Element("staffRole"));
                        itemObj.staffEtc = getElementData(item.Element("staffEtc"));
                        itemObj.staffId = getElementData(item.Element("staffId"));

                        items.staffs.Add(itemObj);
                    }
                }

                items.vods = new List<vod>();
                foreach (XElement listItem in list.Descendants("vods"))
                {
                    foreach (XElement item in listItem.Descendants("vod"))
                    {
                        vod itemObj = new vod();
                        itemObj.vodClass = getElementData(item.Element("vodClass"));
                        itemObj.vodUrl = getElementData(item.Element("vodUrl"));

                        items.vods.Add(itemObj);
                    }
                }

                items.stats = new List<stat>();
                foreach (XElement listItem in list.Descendants("stats"))
                {
                    foreach (XElement item in listItem.Descendants("stat"))
                    {
                        stat itemObj = new stat();
                        itemObj.screenArea = getElementData(item.Element("screenArea"));
                        itemObj.screenCnt = getElementData(item.Element("screenCnt"));
                        itemObj.salesAcc = getElementData(item.Element("salesAcc"));
                        itemObj.audiAcc = getElementData(item.Element("audiAcc"));
                        itemObj.statSouce = getElementData(item.Element("statSouce"));
                        itemObj.statDate = getElementData(item.Element("statDate"));

                        items.stats.Add(itemObj);
                    }
                }

                items.themeSong = getElementData(list.Element("themeSong"));
                items.soundtrack = getElementData(list.Element("soundtrack"));
                items.fLocation = getElementData(list.Element("fLocation"));

                items.Awards1 = getElementData(list.Element("Awards1"));
                items.Awards2 = getElementData(list.Element("Awards2"));
                items.regDate = getElementData(list.Element("regDate"));

                items.modDate = getElementData(list.Element("modDate"));
                items.isanCode = getElementData(list.Element("isanCode"));
                items.ALIAS = getElementData(list.Element("ALIAS"));

            }

            return items;
        }
    }
}
