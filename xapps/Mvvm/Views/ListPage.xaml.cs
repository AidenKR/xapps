using Xamarin.Forms;

namespace xapps
{
    public partial class ListPage : ContentPage
    {
        ListPageViewModel viewModel;

        public ListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ListPageViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as results;
            if (item == null)
                return;

            await Navigation.PushAsync(new DetailPage());

            // Manually deselect item
            listView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
