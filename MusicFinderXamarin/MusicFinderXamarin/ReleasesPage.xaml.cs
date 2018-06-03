using MusicFinderXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicFinderXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReleasesPage : ContentPage
    {
        public ApiRest Client { get; set; }// = new ApiRest();
        public ObservableCollection<Release> Releases { get; set; } = new ObservableCollection<Release>();
        public Artist Artist { get; set; }

        public ReleasesPage ()
		{
			InitializeComponent ();

            ReleasesListView.ItemsSource = Releases;
            ReleasesListView.ItemSelected += ReleasesListView_ItemSelected;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            Releases.Clear();
            foreach (Release release in await Client.GetReleases(Artist.MbId.ToString()))
            {
                Releases.Add(release);
            }

            SearchingLabel.IsVisible = false;
            ReleasesListView.IsVisible = true;
        }

        private void ReleasesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Release release = (Release)ReleasesListView.SelectedItem;
            Navigation.PushAsync(new RecordingsPage() { Release = release, Artist = Artist, Client = Client });
        }
    }
}