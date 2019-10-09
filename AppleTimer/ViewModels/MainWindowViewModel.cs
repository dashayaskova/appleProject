using System.Windows;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using appleTimer.DbProject;
using System.Linq;
using DbModels.Models;
using System;
using Providers;
using System.Web.UI;
using AppleTimer.TimerServer;
using System.ServiceModel;
using Managers;

namespace AppleTimer.ViewModels
{
    internal class MainWindowViewModel: BaseViewModel, ILoaderOwner
    {
        #region Fields
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;
        #endregion

        #region Properties
        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {

                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            LoaderManeger.Instance.Initialize(this);

            using (var myChannelFactory = new ChannelFactory<ITimerServer>("BasicHttpBinding_ITimerServer"))
            {
                ITimerServer client = myChannelFactory.CreateChannel();
                client.UserExists("bla");
            }

            DBManager.UserExists("blo");
        }
	}
}
