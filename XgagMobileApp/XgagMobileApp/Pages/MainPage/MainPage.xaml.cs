using Microsoft.Practices.Unity;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XgagMobileApp
{
	public partial class MainPage : ContentPage
	{
        private MainPageViewModel m_ViewModel;
        private IUnityContainer m_Container;

        public MainPage(
            IUserSessionModel userSession,
            IUnityContainer container)
		{
			InitializeComponent();
            m_Container = container;
            if (userSession.SessionToken != default(Guid))
            {
                m_ViewModel = m_Container.Resolve<MainPageViewModel>();
                BindingContext = m_ViewModel; 
            }
            else
            {
                ShowLoginPage();
            }
		}

        private async void ShowLoginPage()
        {
            var loginPage = m_Container.Resolve<LoginPage>();
            loginPage.LoginSuccessful += OnLoginSuccessful;
            await Navigation.PushModalAsync(loginPage, true);
        }

        private void OnLoginSuccessful(object sender, EventArgs e)
        {
            var loginPage = sender as LoginPage;
            loginPage.LoginSuccessful -= OnLoginSuccessful;
            Device.BeginInvokeOnMainThread(async () =>
            {
                m_ViewModel = m_Container.Resolve<MainPageViewModel>();
                BindingContext = m_ViewModel;
                await Navigation.PopModalAsync(true);
            });
        }

        private void ListViewItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (e != null)
            {
                m_ViewModel.ItemLoaded(e.Item as IPostModel);
            }
        }
    }
}
