using MusicFinderXamarin.Services;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MusicFinderXamarin
{
	public partial class MainPage : ContentPage
	{
        public ApiRest Client { get; set; } = new ApiRest();
        public ObservableCollection<Artist> Artists { get; set; } = new ObservableCollection<Artist>();

        public MainPage()
        {
            InitializeComponent();
            ArtistsListView.ItemsSource = Artists;

            SearchArtistButton.Clicked += SearchArtistButton_Clicked;
            ArtistsListView.ItemSelected += ArtistsListView_ItemSelected;
        }

        private void ArtistsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Artist artist = (Artist)ArtistsListView.SelectedItem;
            Navigation.PushAsync(new ReleasesPage() { Artist = artist, Client = Client });
        }

        private async void SearchArtistButton_Clicked(object sender, System.EventArgs e)
        {
            SearchingLabel.IsVisible = true;
            ArtistsListView.IsVisible = false;
            Artists.Clear();
            foreach (Artist artist in await Client.GetArtists(ArtistSearchEntry.Text))
            {
                Artists.Add(artist);
            }

            SearchingLabel.IsVisible = false;
            ArtistsListView.IsVisible = true;
        }
    }
}
