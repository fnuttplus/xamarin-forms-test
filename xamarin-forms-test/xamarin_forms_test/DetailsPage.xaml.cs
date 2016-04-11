using Xamarin.Forms;

namespace OMDbBrowser
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }

        public void SetContent(string title, string year, string poster)
        {
            imgPoster.Source = poster;
            lblTitle.Text = title;
            lblYear.Text = "("+year+")";
        }

        public void SetMoreContent(string plot)
        {
            lblPlot.Text = plot;
        }
    }
}