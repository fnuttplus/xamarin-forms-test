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
        public string Plot { get; set; }
    }

    class MovieList
    {
        public Movie[] Search { get; set; }
    }

    public partial class MasterPage : ContentPage
    {
        DetailsPage Details;
        public MasterPage(DetailsPage details)
        {
            Details = details;
            Title = "Search!";
            InitializeComponent();
        }
        
        async void OnSearch(object sender, EventArgs e)
        {
            aiLoading.IsVisible = true;
            using (var webClient = new System.Net.Http.HttpClient())
            {
                var json = await webClient.GetStringAsync("http://www.omdbapi.com/?s="+inSearch.Text);
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
        }

        async void OnSelected(object sender, EventArgs e)
        {
            Movie movie = (Movie)MovieView.SelectedItem;
            Details.SetContent(movie.Title, movie.Year, movie.Poster);
            using (var webClient = new System.Net.Http.HttpClient())
            {
                var json = await webClient.GetStringAsync("http://www.omdbapi.com/?t=" + movie.Title);
                try
                {
                    movie = JsonConvert.DeserializeObject<Movie>(json);
                    Details.SetMoreContent(movie.Plot);
                }
                catch (Exception ex)
                {
                    lblOut.Text = ex.ToString();
                }
            }
        }

    }
}