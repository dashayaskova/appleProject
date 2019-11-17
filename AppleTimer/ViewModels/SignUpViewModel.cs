using System;
using System.Windows.Controls;
using DbModels.Models;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using AppleTimer.Tools.Navigation;
using System.Threading.Tasks;
using System.Linq;

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
            Guid newId = Guid.NewGuid();
            UserCandidate userCand = new UserCandidate();
            userCand.Id = newId;
            userCand.Username = Username;
            userCand.Email = Email;
            userCand.Password = pb.Password;
            userCand.Name = Name;
            userCand.Surname = Surname;

            User user = new User();
            user.Id = newId;
            user.Username = Username;
            user.Email = Email;
            user.Name = Name;
            user.Surname = Surname;

            LoaderManager.Instance.ShowLoader();

            await Task.Run(() =>
            {
                using (var serv = new TimerService.TimerServerClient(StationManager.EndpointName))
                {
                    serv.AddUser(userCand);
                }
            });

            LoaderManager.Instance.HideLoader();

            StationManager.CurrentUser = user;
            NavigationManager.Instance.Navigate(ViewType.MainView);
        }
    }
}
