using System.Windows;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using appleTimer.DbProject;
using System.Linq;
using Managers;
using DbModels.Models;
using System;
using Providers;
using System.Web.UI;

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

			//StationManager.Records = DbManager.GetUserRecords(new User() { Id = new Guid("DF215E10-8BD4-4401-B2DC-99BB03135F2E") });

			//using (var context = new EFDBProvider())
			//{
			//	//StationManager.Records = context.SelectAll<Record>()
			//	StationManager.Groups = context.SelectAll<Group>().ToList();
			//}
			var serv = new TimerServer.TimerServerClient("TimerServerWCF");
			var users = serv.GetAllUsers();

		}
	}
}
