using System;
using System.Collections.Generic;
using System.Net;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace xapps.Droid
{
    /// <summary>
    /// This adapter uses a view defined in /Resources/Layout/ListSelectorViewCell.axml
    /// as the cell layout
    /// </summary>
    public class ListSelectorViewAdapter : BaseAdapter<ListPageItem>
    {
        readonly Activity context;
        IList<ListPageItem> tableItems = new List<ListPageItem>();

        public ListSelectorViewAdapter(Activity context, ListSelectorView view)
        {
            this.context = context;
            tableItems = (System.Collections.Generic.IList<xapps.ListPageItem>)view.ItemsSource;
            //Console.WriteLine("## ListSelectorViewAdapter() ItemsCount: " + tableItems.Count());
        }

        public override ListPageItem this[int position]
        {
            get
            {
                return tableItems[position];
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return tableItems.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = tableItems[position];

            var view = convertView;
            MyViewHolder vHolder;

            if (view == null)
            {
                vHolder = new MyViewHolder();

                // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.ListSelectorViewCell, null);
                vHolder.MovieTitle = view.FindViewById<TextView>(Resource.Id.MovieTitle);
                vHolder.MovieDesc = view.FindViewById<TextView>(Resource.Id.MovieDesc);
                vHolder.MovieGrade = view.FindViewById<TextView>(Resource.Id.MovieGrade);
                vHolder.MovieReleaseDate = view.FindViewById<TextView>(Resource.Id.MovieReleaseDate);
                vHolder.MovieReleaseDate = view.FindViewById<TextView>(Resource.Id.MovieReleaseDate);
                vHolder.MoviePoster = view.FindViewById<ImageView>(Resource.Id.MoviePoster);

                view.Tag = vHolder;
            }
            else
            {
                vHolder = view.Tag as MyViewHolder;
            }

            // set data
            vHolder.MovieTitle.Text = item.Title;
            vHolder.MovieDesc.Text = item.Description;
            vHolder.MovieGrade.Text = item.Rank;
            vHolder.MovieReleaseDate.Text = item.SubDescription;

            if (!String.IsNullOrWhiteSpace(item.ThumbUrl))
            {
                //Console.WriteLine("############## ["+ item.Title +"]Drawable: " + vHolder.MoviePoster.Drawable);
                setImage(vHolder.MoviePoster, item.ThumbUrl);
            }

            return view;
        }

        private void setImage(ImageView v, string url)
        {
            try
            {
                WebClient client = new WebClient();
                client.DownloadDataCompleted += delegate (object sender, DownloadDataCompletedEventArgs e)
                {
                    if (!string.IsNullOrEmpty(e.Error?.Message))
                    {
                        Console.WriteLine("DownloadDataCompleted() Error : " + e.Error.Message);
                        return;
                    }

                    byte[] raw = e.Result;
                    if (raw != null && raw.Length > 0)
                    {
                        Bitmap imageBitmap = BitmapFactory.DecodeByteArray(raw, 0, raw.Length);
                        v.SetImageBitmap(imageBitmap);
                    }

                };
                client.DownloadDataAsync(new System.Uri(url));
            }
            catch (Exception e)
            {
                Console.WriteLine("setImage() error: " + e.Message);
                v.SetImageBitmap(null);
            }
        }
    }
}

