using System;
using System.Windows.Controls;
using DbModels.Models;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using AppleTimer.Tools.Navigation;
using System.Threading.Tasks;

namespace AppleTimer.ViewModels
{
    internal class SignUpViewModel
    {
        #region Fields

        private RelayCommand<PasswordBox> _signUpCommand;
        private RelayCommand<object> _cancelCommand;

        #endregion

        #region Props

        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        public RelayCommand<PasswordBox> SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand<PasswordBox>(DoSignUp, CanSignUp));
            }
        }

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(o =>
                {
                    NavigationManager.Instance.Navigate(ViewType.LoginView);
                }));
            }
        }

        private bool CanSignUp(PasswordBox pb)
        {
            return !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(pb.Password)
                                                   && !String.IsNullOrEmpty(Email);
        }

        #endregion

        private async void DoSignUp(PasswordBox pb)
        {
            User user = new User(Username, Email, pb.Password);
            user.Name = Name;
            user.Surname = Surname;

            LoaderManager.Instance.ShowLoader();

            await Task.Run(() =>
            {
                using (var serv = new TimerService.TimerServerClient(StationManager.EndpointName))
                {
                    serv.AddUser(user);
                }
            });

            LoaderManager.Instance.HideLoader();

            StationManager.CurrentUser = user;
            NavigationManager.Instance.Navigate(ViewType.MainView);
        }
    }
}
