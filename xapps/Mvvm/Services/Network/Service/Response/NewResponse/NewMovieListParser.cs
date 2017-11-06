using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace xapps
{
    public class NewMovieListParser : DefaultParser
    {
        public NewMovieData parseXml(string contents)
        {

            NewMovieData items = new NewMovieData();
            items.MovieList = new List<NewMovie>();

            //Xml Parsing  

            XDocument doc = XDocument.Parse(contents);
            Debug.WriteLine(doc);

            foreach (XElement list in doc.Descendants("Row"))
            {
                NewMovie movie = new NewMovie();

                movie.DOCID = getElementData(list.Element("DOCID"));
                movie.movieId = getElementData(list.Element("movieId"));
                movie.movieSeq = getElementData(list.Element("movieSeq"));

                movie.title = getElementData(list.Element("title"));
                movie.titleEng = getElementData(list.Element("titleEng"));
                movie.titleOrg = getElementData(list.Element("titleOrg"));
                movie.titleEtc = getElementData(list.Element("titleEtc"));
                movie.prodYear = getElementData(list.Element("prodYear"));

                movie.directors = new List<director>();
                foreach (XElement listItem in list.Descendants("directors"))
                {
                    foreach (XElement item in listItem.Descendants("director"))
                    {
                        director itemObj = new director();
                        itemObj.directorNm = getElementData(item.Element("directorNm"));
                        itemObj.directorId = getElementData(item.Element("directorId"));

                        movie.directors.Add(itemObj);
                    }
                }

                movie.actors = new List<actor>();
                foreach (XElement listItem in list.Descendants("actors"))
                {
                    foreach (XElement item in listItem.Descendants("actor"))
                    {
                        actor itemObj = new actor();
                        itemObj.actorNm = getElementData(item.Element("actorNm"));
                        itemObj.actorId = getElementData(item.Element("actorId"));

                        movie.actors.Add(itemObj);
                    }
                }


                movie.nation = getElementData(list.Element("nation"));
                movie.company = getElementData(list.Element("company"));
                movie.plot = getElementData(list.Element("plot"));

                movie.runtime = getElementData(list.Element("runtime"));
                movie.rating = getElementData(list.Element("rating"));
                movie.genre = getElementData(list.Element("genre"));
                movie.kmdbUrl = getElementData(list.Element("kmdbUrl"));
                movie.type = getElementData(list.Element("type"));
                movie.use = getElementData(list.Element("use"));

                movie.episodes = getElementData(list.Element("episodes"));
                movie.ratedYn = getElementData(list.Element("ratedYn"));
                movie.repRatDate = getElementData(list.Element("repRatDate"));
                movie.repRlsDate = getElementData(list.Element("repRlsDate"));

                movie.ratings = new List<rating>();
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
                        movie.ratings.Add(itemObj);
                    }
                }

                movie.keywords = getElementData(list.Element("keywords"));
                movie.posters = getElementData(list.Element("posters"));
                movie.stlls = getElementData(list.Element("stlls"));

                movie.staffs = new List<staff>();
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

                        movie.staffs.Add(itemObj);
                    }
                }

                movie.vods = new List<vod>();
                foreach (XElement listItem in list.Descendants("vods"))
                {
                    foreach (XElement item in listItem.Descendants("vod"))
                    {
                        vod itemObj = new vod();
                        itemObj.vodClass = getElementData(item.Element("vodClass"));
                        itemObj.vodUrl = getElementData(item.Element("vodUrl"));

                        movie.vods.Add(itemObj);
                    }
                }

                movie.stats = new List<stat>();
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

                        movie.stats.Add(itemObj);
                    }
                }

                movie.themeSong = getElementData(list.Element("themeSong"));
                movie.soundtrack = getElementData(list.Element("soundtrack"));
                movie.fLocation = getElementData(list.Element("fLocation"));

                movie.Awards1 = getElementData(list.Element("Awards1"));
                movie.Awards2 = getElementData(list.Element("Awards2"));
                movie.regDate = getElementData(list.Element("regDate"));

                movie.modDate = getElementData(list.Element("modDate"));
                movie.isanCode = getElementData(list.Element("isanCode"));
                movie.ALIAS = getElementData(list.Element("ALIAS"));

                items.MovieList.Add(movie);

            }

            return items;
        }
    }
}
