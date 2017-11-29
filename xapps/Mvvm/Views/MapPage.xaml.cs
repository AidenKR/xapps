using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using System.Linq;

namespace xapps
{
    public partial class MapPage : ContentPage
    {
        public MapPage(string searchLocaleText)
        {
            InitializeComponent();

            var mapTypeValues = new List<MapType>();
            foreach (var mapType in Enum.GetValues(typeof(MapType)))
            {
                mapTypeValues.Add((MapType)mapType);
                pickerMapType.Items.Add(Enum.GetName(typeof(MapType), mapType));
            }

            pickerMapType.SelectedIndexChanged += (sender, e) =>
            {
                mapView.MapType = mapTypeValues[pickerMapType.SelectedIndex];
            };
            pickerMapType.SelectedIndex = 0;

            mapView.UiSettings.MyLocationButtonEnabled = true;
            mapView.UiSettings.ZoomControlsEnabled = true;
            mapView.IsTrafficEnabled = true;
            mapView.IsIndoorEnabled = true;
            mapView.UiSettings.CompassEnabled = true;
            mapView.UiSettings.RotateGesturesEnabled = true;
            mapView.UiSettings.IndoorLevelPickerEnabled = true;
            mapView.UiSettings.ScrollGesturesEnabled = true;
            mapView.UiSettings.ZoomGesturesEnabled = true;

            mapView.MapClicked += (sender, e) =>
            {
                var lat = e.Point.Latitude.ToString("0.000");
                var lng = e.Point.Longitude.ToString("0.000");
                this.DisplayAlert("MapClicked", $"{lat} /{lng} ", "CLOSE");
            };

            locationButton.Clicked += (sender, e) =>
            {
                mapView.MyLocationEnabled = true;
            };

            mapView.MapLongClicked += (sender, e) =>
            {
                var lat = e.Point.Latitude.ToString("0.000");
                var lng = e.Point.Longitude.ToString("0.000");
                this.DisplayAlert("MapLongClicked", $"{lat} /{lng} ", "CLOSE");

                var pinMelbourne = new Pin() { Label = "Melbourne", Position = new Position(-37.971237, 144.492697) };
                mapView.Pins.Add(pinMelbourne);
            };

            //mapView.MyLocationButtonClicked += (sender, args) =>
            //{
            //    args.Handled = true;
            //    mapView.MyLocationEnabled = true;
            //};

            searchButton.Clicked += async (sender, e) =>
            {
                if(entryAddress.Text == null || entryAddress.Text.Length <= 0) {
                    await this.DisplayAlert("Invalidate", "Input searchData", "Close");
                    return;
                }

                searchLocale();
            };

            stackView.Children.Add(mapView);

            if(searchLocaleText != null && searchLocaleText.Length > 0) {
                entryAddress.Text = searchLocaleText;
                searchLocale();
            }
        }

        void pinClicked(object sender, Xamarin.Forms.GoogleMaps.PinClickedEventArgs e)
        {
            this.DisplayAlert("alert", "pinClicked", "Close");
        }

        void mapClicked(object sender, Xamarin.Forms.GoogleMaps.MapClickedEventArgs e)
        {
            this.DisplayAlert("alert", "mapClicked", "Close");
        }

        async void searchLocale() {
            var geocoder = new Xamarin.Forms.GoogleMaps.Geocoder();
            IEnumerable<Position> positions = await geocoder.GetPositionsForAddressAsync(entryAddress.Text);
            if (positions.ToList().Count() > 0)
            {
                var pos = positions.First();
                mapView.MoveToRegion(MapSpan.FromCenterAndRadius(pos, Distance.FromKilometers(10)));
                var reg = mapView.VisibleRegion;
                var format = "0.00";
                Debug.WriteLine($"Center = {reg.Center.Latitude.ToString(format)} , {reg.Center.Longitude.ToString(format)} ");
            }
            else
            {
                await this.DisplayAlert("Not found", "Geocoder returns no results", "Close");
            }
        }
    }
}

