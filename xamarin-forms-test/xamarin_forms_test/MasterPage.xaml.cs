using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace OMDbBrowser
{
    class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string imdbRating { get; set; }
        public string Genre { get; set; }
    }

    class MovieList
    {
        public Movie[] Search { get; set; }
    }

    public partial class MasterPage : ContentPage
    {
        DetailsPage Details;
        HttpClient webClient;

        public MasterPage(DetailsPage details)
        {
            BackgroundColor = Color.FromRgba(0, 0, 0, 100);
            webClient = new HttpClient();
            webClient.BaseAddress = new Uri("http://www.omdbapi.com/");
            Details = details;
            Title = "Search!";
            InitializeComponent();
        }
        
        async void OnSearch(object sender, EventArgs e)
        {
            aiLoading.IsVisible = true;
            var json = await webClient.GetStringAsync("?s="+inSearch.Text);
            try
            {
                MovieList ml = JsonConvert.DeserializeObject<MovieList>(json);
                aiLoading.IsVisible = false;
                MovieView.ItemsSource = ml.Search;
            }
            catch (Exception ex)
            {
                lblOut.Text = ex.ToString();
            }
        }

        async void OnSelected(object sender, EventArgs e)
        {
            Movie movie = (Movie)MovieView.SelectedItem;
            Details.SetContent(movie.Title, movie.Year, movie.Poster);
            var json = await webClient.GetStringAsync("?t=" + movie.Title);
            try
            {
                movie = JsonConvert.DeserializeObject<Movie>(json);
                Details.SetMoreContent(movie.Plot, movie.imdbRating, movie.Genre);
            }
            catch (Exception ex)
            {
                lblOut.Text = ex.ToString();
            }
        }
    }
}