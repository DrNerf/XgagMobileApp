using Microsoft.Practices.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XgagMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        private IUnityContainer m_Container;
        private LoginPageViewModel m_ViewModel;

        public event EventHandler LoginSuccessful;

        public LoginPage(
            LoginPageViewModel viewModel,
            IUnityContainer container)
		{
			InitializeComponent();
            BindingContext = viewModel;
            m_ViewModel = viewModel;
            viewModel.LoginSuccessful += OnLoginSuccessful;
            m_Container = container;
		}

        private void OnLoginSuccessful(object sender, EventArgs e)
        {
            m_ViewModel.LoginSuccessful -= OnLoginSuccessful;
            LoginSuccessful?.Invoke(this, null);
        }
    }
}