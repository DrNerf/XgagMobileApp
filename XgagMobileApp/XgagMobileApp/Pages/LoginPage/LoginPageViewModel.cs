using Common;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;
using ServiceLayer;

namespace XgagMobileApp
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string m_Username;
        private string m_Password;
        private IAuthenticationProxy m_AuthenticationProxy;

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

        public event EventHandler LoginSuccessful;

        public Command LoginCommand { get; set; }

        public LoginPageViewModel(IAuthenticationProxy authenticationProxy)
        {
            LoginCommand = new Command(Login, CanLogin);
            IsBusyChanged += OnIsBusyChanged;
            m_AuthenticationProxy = authenticationProxy;
        }

        private void OnIsBusyChanged(object sender, EventArgs e)
        {
            LoginCommand.ChangeCanExecute();
        }

        private bool CanLogin(object arg)
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password) && !IsBusy;
        }

        private void Login(object obj)
        {
            BusyExecute(async () => 
            {
                var loginResult = await m_AuthenticationProxy.Login(Username, Password);
                if (loginResult)
                {
                    LoginSuccessful?.Invoke(this, null);
                }
            });
        }
    }
}
