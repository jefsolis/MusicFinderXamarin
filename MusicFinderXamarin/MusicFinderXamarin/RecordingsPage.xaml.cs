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
    public partial class RecordingsPage : ContentPage
    {
        public ApiRest Client { get; set; }// = new ApiRest();
        public ObservableCollection<Recording> Recordings { get; set; } = new ObservableCollection<Recording>();
        public Release Release { get; set; }
        public Artist Artist { get; set; }

        public RecordingsPage()
        {
            InitializeComponent();

            RecordingsListView.ItemsSource = Recordings;
            RecordingsListView.ItemSelected += RecordingsListView_ItemSelected;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            TitleLabel.Text = Release.Title;

            // load cover art
            Release.CoverArtUrl = await Client.GetCoverArtUrl(Release.MbId.ToString());
            if (!string.IsNullOrEmpty(Release.CoverArtUrl))
            {
                CoverImage.Source = new Uri(Release.CoverArtUrl);
            }

            Recordings.Clear();
            foreach (Recording recording in await Client.GetRecordings(Release.MbId.ToString()))
            {
                Recordings.Add(recording);
            }

            SearchingLabel.IsVisible = false;
            RecordingsListView.IsVisible = true;
        }

        private void RecordingsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Recording recording = (Recording)RecordingsListView.SelectedItem;
            Device.OpenUri(new Uri("http://www.youtube.com/results?search_query=" + CreateSearchQuery(Artist, recording)));
        }

        private string CreateSearchQuery(Artist artist, Recording recording)
        {
            StringBuilder query = new StringBuilder();
            string[] artistWords = artist.Name.Split(' ');
            foreach (string artistWord in artistWords)
            {
                query.AppendFormat("{0}+", artistWord);
            }
            string[] recordingWords = recording.Title.Split(' ');
            foreach (string recordingWord in recordingWords)
            {
                query.AppendFormat("{0}+", recordingWord);
            }

            return query.ToString();
        }
    }
}