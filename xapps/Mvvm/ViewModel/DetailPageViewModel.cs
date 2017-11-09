using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xapps
{
    public class DetailPageViewModel : BaseViewModel, INetworkManager
    {
        private static readonly string IMAGE_PATH = "https://image.tmdb.org/t/p/w500";
        public Command LoadItemsCommand { get; set; }
        public ObservableCollection<cast> creditData { get; set; }
        DetailData item;

        public DetailData DetailItem
        {
            set
            {
                if (item != value)
                {
                    item = value;
                    OnPropertyChanged();
                }
            }
            get
            {
                return item;
            }
        }

        public DetailPageViewModel(string requestId)
        {
            Title = "상세화면";

            if (string.IsNullOrWhiteSpace(requestId))
            {
                return;
            }

            creditData = new ObservableCollection<cast>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadDetailItemsCommand(requestId));
        }



        async Task ExecuteLoadDetailItemsCommand(string reqId)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                DetailData data = await NetworkManager.Instance().requestDetailsData(reqId);
                CreditsData creditsData = await NetworkManager.Instance().requestCreditsData(reqId);

                // poster
                data.poster_path = IMAGE_PATH + data.poster_path;
                // preview
                data.backdrop_path = IMAGE_PATH + data.backdrop_path;
                // runtime & genres
                data.runtime = data.runtime + "분";
                string genre = "";
                if (null != data.genres)
                {
                    foreach (genres g in data.genres)
                    {
                        genre += !string.IsNullOrWhiteSpace(genre) ? "/" : "";
                        genre += g.name;
                    }
                    if (!string.IsNullOrWhiteSpace(genre))
                    {
                        genre = " * " + genre;
                    }
                }
                data.runtime += genre;
                // 개봉일자
                data.release_date = data.release_date + " 개봉";

                // Etc
                data.homepage = getEtc(data);

                DetailItem = data;


                #region credits data
                creditData.Clear();
                foreach (var cast in creditsData.cast)
                {
                    if (!String.IsNullOrEmpty(cast.profile_path))
                    {
                        cast.profile_path = IMAGE_PATH + cast.profile_path;
                        cast.character = cast.character.Trim();
                        creditData.Add(cast);

                        if (creditData.Count >= 5)
                        {
                            break;
                        }
                    }
                }
                #endregion


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void onSuccess(BaseData data)
        {
            printLog("onSuccess()");
        }

        public void onFail(BaseData data)
        {
            printLog("onFail()");
        }

        private string getEtc(DetailData data)
        {
            string returnValue = "";
            try
            {
                returnValue += "adult : " + data.adult + "\n";
                returnValue += "backdrop_path : " + data.backdrop_path + "\n";
                returnValue += "budget : " + data.budget + "\n";
                returnValue += "homepage : " + data.homepage + "\n";
                returnValue += "id : " + data.id + "\n";
                returnValue += "imdb_id : " + data.imdb_id + "\n";
                returnValue += "original_language : " + data.original_language + "\n";
                returnValue += "original_title : " + data.original_title + "\n";
                returnValue += "overview : " + data.overview + "\n";
                returnValue += "popularity : " + data.popularity + "\n";
                returnValue += "poster_path : " + data.poster_path + "\n";
                returnValue += "release_date : " + data.release_date + "\n";
                returnValue += "revenue : " + data.revenue + "\n";
                returnValue += "runtime : " + data.runtime + "\n";
                returnValue += "status : " + data.status + "\n";
                returnValue += "tagline : " + data.tagline + "\n";
                returnValue += "title : " + data.title + "\n";
                returnValue += "video : " + data.video + "\n";
                returnValue += "vote_average : " + data.vote_average + "\n";
                returnValue += "vote_count : " + data.vote_count + "\n";


                returnValue += "belongs_to_collection : (" +
                data.belongs_to_collection.backdrop_path + "," +
                    data.belongs_to_collection.id + "," +
                    data.belongs_to_collection.name + "," +
                    data.belongs_to_collection.poster_path
                    + ")\n";

                returnValue += "genres (";
                foreach (genres g in data.genres)
                {
                    returnValue += g.name + ",";
                }
                returnValue += ")\n";

                returnValue += "production_companies (";
                foreach (production_companies p in data.production_companies)
                {
                    returnValue += p.name + ",";
                }
                returnValue += ")\n";

                returnValue += "production_contries (";
                foreach (production_contries pc in data.production_contries)
                {
                    returnValue += pc.name + ",";
                }
                returnValue += ")\n";

                returnValue += "spoken_languages (";
                foreach (spoken_languages s in data.spoken_languages)
                {
                    returnValue += s.name + ",";
                }
                returnValue += ")\n";
            }
            catch (Exception e)
            {
                printLog(e.Message);
                returnValue = data.ToString();
            }

            return returnValue;
        }

        private void printLog(string msg)
        {
            Debug.WriteLine("##### " + msg);
        }
    }
}
