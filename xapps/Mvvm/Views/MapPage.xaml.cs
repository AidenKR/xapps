﻿using System; using System.Collections.Generic; using System.Diagnostics; using Xamarin.Forms; using Xamarin.Forms.GoogleMaps; using System.Linq;  namespace xapps {     public partial class MapPage : ContentPage     {         public MapPage()         {             InitializeComponent();              //CLLocationManager* locationManager = [[CLLocationManager alloc] init];              //[locationManager requestWhenInUseAuthorization];              //var resultrs = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });             //var url = DependencyService.Get<IMovieUrl>();             //bool isCheck = url.requestLocation();             //mapView.MyLocationEnabled = isCheck;              mapView.UiSettings.MyLocationButtonEnabled = true;             mapView.UiSettings.ZoomControlsEnabled = true;             mapView.IsTrafficEnabled = true;             mapView.IsIndoorEnabled = true;             mapView.UiSettings.CompassEnabled = true;             mapView.UiSettings.RotateGesturesEnabled = true;             mapView.UiSettings.IndoorLevelPickerEnabled = true;             mapView.UiSettings.ScrollGesturesEnabled = true;             mapView.UiSettings.ZoomGesturesEnabled = true;              mapView.MapClicked += (sender, e) =>             {                 var lat = e.Point.Latitude.ToString("0.000");                 var lng = e.Point.Longitude.ToString("0.000");                 this.DisplayAlert("MapClicked", $"{lat} /{lng} ", "CLOSE");             };              locationButton.Clicked += (sender, e) =>             {                 mapView.MyLocationEnabled = true;             };              mapView.MapLongClicked += (sender, e) =>             {                 var lat = e.Point.Latitude.ToString("0.000");                 var lng = e.Point.Longitude.ToString("0.000");                 this.DisplayAlert("MapLongClicked", $"{lat} /{lng} ", "CLOSE");                  var pinMelbourne = new Pin() { Label = "Melbourne", Position = new Position(-37.971237, 144.492697) };                 mapView.Pins.Add(pinMelbourne);             };              //mapView.MyLocationButtonClicked += (sender, args) =>             //{             //    args.Handled = true;             //    mapView.MyLocationEnabled = true;             //};              searchButton.Clicked += async (sender, e) =>             {                 var geocoder = new Xamarin.Forms.GoogleMaps.Geocoder();                 IEnumerable<Position> positions = await geocoder.GetPositionsForAddressAsync(entryAddress.Text);                 if (positions.ToList().Count() > 0)                 {                     var pos = positions.First();                     mapView.MoveToRegion(MapSpan.FromCenterAndRadius(pos, Distance.FromKilometers(50)));                     var reg = mapView.VisibleRegion;                     var format = "0.00";                     Debug.WriteLine($"Center = {reg.Center.Latitude.ToString(format)} , {reg.Center.Longitude.ToString(format)} ");                 }                 else                 {                     await this.DisplayAlert("Not found", "Geocoder returns no results", "Close");                 }             };              stackView.Children.Add(mapView);         }          void pinClicked(object sender, Xamarin.Forms.GoogleMaps.PinClickedEventArgs e)         {             this.DisplayAlert("alert", "pinClicked", "Close");         }          void mapClicked(object sender, Xamarin.Forms.GoogleMaps.MapClickedEventArgs e)         {             this.DisplayAlert("alert", "mapClicked", "Close");         }     } }  