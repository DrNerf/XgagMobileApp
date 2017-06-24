using Common;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;

namespace XgagMobileApp
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string m_Username;
        private string m_Password;

        public string Username
        {
            get
            {
                return m_Username;
            }
            set
            {
                m_Username = value;
                NotifyPropertyChanged();
                LoginCommand.ChangeCanExecute();
            }
        }

        public string Password
        {
            get
            {
                return m_Password;
            }
            set
            {
                m_Password = value;
                NotifyPropertyChanged();
                LoginCommand.ChangeCanExecute();
            }
        }

        public Command LoginCommand { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(Login, CanLogin);
            IsBusyChanged += OnIsBusyChanged;
        }

        private void OnIsBusyChanged(object sender, EventArgs e)
        {
            LoginCommand.ChangeCanExecute();
        }

        private bool CanLogin(object arg)
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password) && !IsBusy;
        }

        private async void Login(object obj)
        {
            IsBusy = true;
            await Task.Delay(3000);
            IsBusy = false;
        }
    }
}
