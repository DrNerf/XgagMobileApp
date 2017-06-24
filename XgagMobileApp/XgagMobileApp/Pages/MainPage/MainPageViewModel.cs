using Common;
using System.Threading;
using System.Threading.Tasks;
using System;
using ServiceLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace XgagMobileApp
{
    public class MainPageViewModel : ViewModelBase
    {
        private IPostsProxy m_PostsProxy;
        private int m_CurrentPage = 1;
        
        public ObservableCollection<IPostModel> Posts { get; set; }

        public ICommand NextPageCommand { get; set; }

        public MainPageViewModel(IPostsProxy postsProxy)
        {
            m_PostsProxy = postsProxy;
            Posts = new ObservableCollection<IPostModel>();
            NextPageCommand = new Command(() => LoadPage(m_CurrentPage += 1));
            LoadPage(m_CurrentPage);
        }

        public void ItemLoaded(IPostModel model)
        {
            if (Posts[Posts.Count - 2] == model)
            {
                LoadPage(m_CurrentPage += 1);
            }
        }

        private void LoadPage(int page)
        {
            IsBusy = true;
            m_PostsProxy.Get(page).ContinueWith((t) =>
            {
                foreach (var post in t.Result)
                {
                    Posts.Add(post);
                }

                IsBusy = false;
            });
        }
    }
}
