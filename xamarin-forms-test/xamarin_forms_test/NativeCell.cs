using Xamarin.Forms;

namespace OMDbBrowser
{
    public class NativeCell : ViewCell
    {
        public static readonly BindableProperty TitleProperty =
          BindableProperty.Create("Title", typeof(string), typeof(NativeCell), "");

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty YearProperty =
          BindableProperty.Create("Year", typeof(string), typeof(NativeCell), "");

        public string Year
        {
            get { return (string)GetValue(YearProperty); }
            set { SetValue(YearProperty, value); }
        }

        public static readonly BindableProperty PosterProperty =
          BindableProperty.Create("Poster", typeof(string), typeof(NativeCell), "");

        public string Poster
        {
            get { return (string)GetValue(PosterProperty); }
            set { SetValue(PosterProperty, value); }
        }
    }

}
