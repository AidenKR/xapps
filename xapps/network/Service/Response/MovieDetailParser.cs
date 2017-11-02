using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace xapps
{
    public class MovieDetailParser : DefaultParser
    {
        public MovieDetailData parseXml(string contents)
        {

            MovieDetailData itemObj = new MovieDetailData();

            //Xml Parsing  

            XDocument doc = XDocument.Parse(contents);
            Debug.WriteLine(doc);

            foreach (XElement item in doc.Descendants("movieInfo")) {
                itemObj.movieCd = getElementData(item.Element("movieCd"));
                itemObj.movieNm = getElementData(item.Element("movieNm"));
                itemObj.movieNmEn = getElementData(item.Element("movieNmEn"));

                itemObj.movieNmOg = getElementData(item.Element("movieNmOg"));
                itemObj.showTm = getElementData(item.Element("showTm"));
                itemObj.prdtYear = getElementData(item.Element("prdtYear"));
                itemObj.openDt = getElementData(item.Element("openDt"));
                itemObj.prdtStatNm = getElementData(item.Element("prdtStatNm"));

                itemObj.typeNm = getElementData(item.Element("typeNm"));
                itemObj.nationNm = getElementData(item.Element("nationNm"));

                if(item.Element("genres") != null) {
                    itemObj.genreNm = new List<string>();
                    foreach (XElement genresItem in item.Descendants("genre")) {
                        string genreName = getElementData(genresItem.Element("genreNm"));
                        itemObj.genreNm.Add(genreName);
                    }
                }

                if(item.Element("directors") != null) {
                    itemObj.directors = new List<People>();
                    foreach (XElement directorItem in item.Descendants("director"))
                    {
                        People person = new People();
                        person.peopleNm = getElementData(directorItem.Element("peopleNm"));
                        person.peopleNmEn = getElementData(directorItem.Element("peopleNmEn"));
                        itemObj.directors.Add(person);
                    }
                }

                if (item.Element("actors") != null)
                {
                    itemObj.actors = new List<People>();
                    foreach (XElement actorItem in item.Descendants("actor"))
                    {
                        People person = new People();
                        person.peopleNm = getElementData(actorItem.Element("peopleNmEn"));
                        person.peopleNmEn = getElementData(actorItem.Element("peopleNmEn"));
                        person.cast = getElementData(actorItem.Element("cast"));
                        person.castEn = getElementData(actorItem.Element("castEn"));
                        itemObj.actors.Add(person);
                    }
                }

                if (item.Element("showTypes") != null)
                {
                    itemObj.showTypes = new List<ShowType>();
                    foreach (XElement showTypeItem in item.Descendants("showType"))
                    {
                        ShowType type = new ShowType();
                        type.showTypeGroypNm = getElementData(showTypeItem.Element("showTypeGroypNm"));
                        type.showTypeNm = getElementData(showTypeItem.Element("showTypeNm"));
                        itemObj.showTypes.Add(type);
                    }
                }

                if (item.Element("companys") != null)
                {
                    itemObj.companys = new List<Company>();
                    foreach (XElement companyItem in item.Descendants("company"))
                    {
                        Company company = new Company();
                        company.companyCd = getElementData(companyItem.Element("companyCd"));
                        company.companyNm = getElementData(companyItem.Element("companyNm"));
                        company.companyNmEn = getElementData(companyItem.Element("companyNmEn"));
                        company.companyPartNm = getElementData(companyItem.Element("companyPartNm"));
                        itemObj.companys.Add(company);
                    }
                }

                if (item.Element("audits") != null)
                {
                    itemObj.audits = new List<Audit>();
                    foreach (XElement auditItem in item.Descendants("audit"))
                    {
                        Audit audit = new Audit();
                        audit.auditNo = getElementData(auditItem.Element("auditNo"));
                        audit.watchGradeNm = getElementData(auditItem.Element("auditNo"));
                        itemObj.audits.Add(audit);
                    }
                }

                if (item.Element("staffs") != null)
                {
                    itemObj.staffs = new List<People>();
                    foreach (XElement staffItem in item.Descendants("staff"))
                    {
                        People people = new People();
                        people.peopleNm = getElementData(staffItem.Element("auditNo"));
                        people.peopleNmEn = getElementData(staffItem.Element("auditNo"));
                        people.staffRoleNm = getElementData(staffItem.Element("auditNo"));
                        itemObj.staffs.Add(people);
                    }
                }

                Debug.WriteLine("coollhb " + itemObj + "\n\n");
            }

            return itemObj;
        }
    }
}
