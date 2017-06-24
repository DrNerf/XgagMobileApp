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

        public MainPage(MainPageViewModel viewModel)
		{
			InitializeComponent();
            m_ViewModel = viewModel;
            BindingContext = viewModel;
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
