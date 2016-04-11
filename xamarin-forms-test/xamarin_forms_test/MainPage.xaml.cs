using Xamarin.Forms;

namespace OMDbBrowser
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            Title = "OMDbBrowser";
            MasterBehavior = MasterBehavior.SplitOnLandscape;
            DetailsPage Details = new DetailsPage() { Title = "Description"};
            Detail = Details;
            Master = new MasterPage(Details);
        }
    }
}
