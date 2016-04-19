using Android;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using OMDbBrowser;
using OMDbBrowser.Droid;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NativeCell), typeof(NativeAndroidCellRenderer))]
namespace OMDbBrowser.Droid
{
    public class NativeAndroidCellRenderer : ViewCellRenderer
    {
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            var x = (NativeCell)item;

            var view = convertView;

            if (view == null)
            {
                // no view to re-use, create new
                view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.NativeAndroidCell, null);
            }

            view.FindViewById<TextView>(Resource.Id.Title).Text = x.Title;
            view.FindViewById<TextView>(Resource.Id.Year).Text = x.Year;
            view.FindViewById<ImageView>(Resource.Id.Poster).SetImageURI(Android.Net.Uri.Parse(x.Poster));

            /*
            // grab the old image and dispose of it
            if (view.FindViewById<ImageView>(Resource.Id.Poster).Drawable != null)
            {
                using (var image = view.FindViewById<ImageView>(Resource.Id.Poster).Drawable as BitmapDrawable)
                {
                    if (image != null)
                    {
                        if (image.Bitmap != null)
                        {
                            image.Bitmap.Dispose();
                        }
                    }
                }
            }
            // If a new image is required, display it
            if (!string.IsNullOrWhiteSpace(x.Poster))
            {
                context.Resources.GetBitmapAsync(x.Poster).ContinueWith((t) => {
                    var bitmap = t.Result;
                    if (bitmap != null)
                    {
                        view.FindViewById<ImageView>(Resource.Id.Poster).SetImageBitmap(bitmap);
                        bitmap.Dispose();
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

            }
            else
            {
                // clear the image
                view.FindViewById<ImageView>(Resource.Id.Poster).SetImageBitmap(null);
            }
            */
            return view;
        }
    }
}