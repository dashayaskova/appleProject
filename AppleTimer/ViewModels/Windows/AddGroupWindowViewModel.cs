using DbModels.Models;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using System;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;

namespace AppleTimer.ViewModels.Windows
{
	class AddGroupWindowViewModel
	{

		public AddGroupWindowViewModel()
		{
            StationManager.CurGroup = new Group(StationManager.CurrentUser);
            Group = StationManager.CurGroup;
        }

		#region Fields

		private ICommand _saveCommand;
		private ICommand _cancelCommand;

        #endregion

        #region Props
        public Group Group { get; set; }

        public ICommand CancelCommand
		{
			get { return _cancelCommand ?? (_cancelCommand = new RelayCommand<Window>(w => w?.Close())); }
		}

		public ICommand SaveCommand
		{
			get
			{
				return _saveCommand ?? (_saveCommand = new RelayCommand<Window>(SaveImplementation, CanExecuteCommand));
			}
		}

        #endregion

        private bool CanExecuteCommand(Object o)
		{
			return !String.IsNullOrEmpty(Group.Name) && Group.Color != null;
		}

		private void SaveImplementation(Window win)
		{
            StationManager.CurrentUser.Groups.Add(Group);
            SubmitNewGroup(Group);
			win?.Close();
		}

        private async void SubmitNewGroup(Group group)
        {
            await Task.Run(() =>
            {
                using (var serv = new TimerService.TimerServerClient(StationManager.EndpointName))
                {
                    serv.AddGroup(group);
                }
            }
            );
        }
    }
}
