using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Common
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private bool m_IsBusy;

        public bool IsBusy
        {
            get
            {
                return m_IsBusy;
            }
            set
            {
                m_IsBusy = value;
                NotifyPropertyChanged();
                IsBusyChanged?.Invoke(this, null);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler IsBusyChanged;

        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
