using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XgagMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage (LoginPageViewModel viewModel)
		{
			InitializeComponent ();
            BindingContext = viewModel;
		}
	}
}