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

            items.movie = new NewMovie();
            //Xml Parsing  

            XDocument doc = XDocument.Parse(contents);
            Debug.WriteLine(doc);

            foreach (XElement list in doc.Descendants("Row"))
            {
                items.movie.DOCID = getElementData(list.Element("DOCID"));
                items.movie.movieId = getElementData(list.Element("movieId"));
                items.movie.movieSeq = getElementData(list.Element("movieSeq"));

                items.movie.title = getElementData(list.Element("title"));
                items.movie.titleEng = getElementData(list.Element("titleEng"));
                items.movie.titleOrg = getElementData(list.Element("titleOrg"));
                items.movie.titleEtc = getElementData(list.Element("titleEtc"));
                items.movie.prodYear = getElementData(list.Element("prodYear"));

                items.movie.directors = new List<director>();
                foreach (XElement listItem in list.Descendants("directors"))
                {
                    foreach (XElement item in listItem.Descendants("director"))
                    {
                        director itemObj = new director();
                        itemObj.directorNm = getElementData(item.Element("directorNm"));
                        itemObj.directorId = getElementData(item.Element("directorId"));

                        items.movie.directors.Add(itemObj);
                    }
                }

                items.movie.actors = new List<actor>();
                foreach (XElement listItem in list.Descendants("actors"))
                {
                    foreach (XElement item in listItem.Descendants("actor"))
                    {
                        actor itemObj = new actor();
                        itemObj.actorNm = getElementData(item.Element("actorNm"));
                        itemObj.actorId = getElementData(item.Element("actorId"));

                        items.movie.actors.Add(itemObj);
                    }
                }


                items.movie.nation = getElementData(list.Element("nation"));
                items.movie.company = getElementData(list.Element("company"));
                items.movie.plot = getElementData(list.Element("plot"));

                items.movie.runtime = getElementData(list.Element("runtime"));
                items.movie.rating = getElementData(list.Element("rating"));
                items.movie.genre = getElementData(list.Element("genre"));
                items.movie.kmdbUrl = getElementData(list.Element("kmdbUrl"));
                items.movie.type = getElementData(list.Element("type"));
                items.movie.use = getElementData(list.Element("use"));

                items.movie.episodes = getElementData(list.Element("episodes"));
                items.movie.ratedYn = getElementData(list.Element("ratedYn"));
                items.movie.repRatDate = getElementData(list.Element("repRatDate"));
                items.movie.repRlsDate = getElementData(list.Element("repRlsDate"));

                items.movie.ratings = new List<rating>();
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
                        items.movie.ratings.Add(itemObj);
                    }
                }

                items.movie.keywords = getElementData(list.Element("keywords"));
                items.movie.posters = getElementData(list.Element("posters"));
                items.movie.stlls = getElementData(list.Element("stlls"));

                items.movie.staffs = new List<staff>();
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

                        items.movie.staffs.Add(itemObj);
                    }
                }

                items.movie.vods = new List<vod>();
                foreach (XElement listItem in list.Descendants("vods"))
                {
                    foreach (XElement item in listItem.Descendants("vod"))
                    {
                        vod itemObj = new vod();
                        itemObj.vodClass = getElementData(item.Element("vodClass"));
                        itemObj.vodUrl = getElementData(item.Element("vodUrl"));

                        items.movie.vods.Add(itemObj);
                    }
                }

                items.movie.stats = new List<stat>();
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

                        items.movie.stats.Add(itemObj);
                    }
                }

                items.movie.themeSong = getElementData(list.Element("themeSong"));
                items.movie.soundtrack = getElementData(list.Element("soundtrack"));
                items.movie.fLocation = getElementData(list.Element("fLocation"));

                items.movie.Awards1 = getElementData(list.Element("Awards1"));
                items.movie.Awards2 = getElementData(list.Element("Awards2"));
                items.movie.regDate = getElementData(list.Element("regDate"));

                items.movie.modDate = getElementData(list.Element("modDate"));
                items.movie.isanCode = getElementData(list.Element("isanCode"));
                items.movie.ALIAS = getElementData(list.Element("ALIAS"));

            }

            return items;
        }
    }
}
