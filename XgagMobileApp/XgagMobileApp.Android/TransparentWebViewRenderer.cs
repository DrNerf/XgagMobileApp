using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XgagMobileApp;
using XgagMobileApp.Droid;
using static Android.Webkit.WebSettings;

[assembly: ExportRenderer(typeof(TransparentWebView), typeof(TransparentWebViewRenderer))]
namespace XgagMobileApp.Droid
{
    public class TransparentWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            // Setting the background as transparent
            this.Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            this.Control.Settings.DomStorageEnabled = true;
            this.Control.Settings.LoadsImagesAutomatically = true;
            this.Control.Settings.JavaScriptEnabled = true;
            this.Control.Settings.SetRenderPriority(RenderPriority.High);
        }
    }
}