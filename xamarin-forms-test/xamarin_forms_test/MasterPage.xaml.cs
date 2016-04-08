using System;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace OMDbBrowser
{
    class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Poster { get; set; }
    }

    class MovieList
    {
        public Movie[] Search { get; set; }
    }

    public partial class MasterPage : ContentPage
    {

        public MasterPage()
        {
            InitializeComponent();
        }

        async void OnSearch(object sender, EventArgs e)
        {
            using (var webClient = new System.Net.Http.HttpClient())
            {
                var json = await webClient.GetStringAsync("http://www.omdbapi.com/?s="+inSearch.Text);
                try
                {
                    MovieList ml = JsonConvert.DeserializeObject<MovieList>(json);
                    MovieView.ItemsSource = ml.Search;
                }
                catch (Exception ex)
                {
                    lblOut.Text = ex.ToString();
                }
            }
        }

        void OnSelected(object sender, EventArgs e)
        {
            lblOut.Text = ((Movie)MovieView.SelectedItem).Title;
        }

    }
}