using System;
using System.Windows.Controls;
using DbModels.Models;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using AppleTimer.Tools.Navigation;

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

        private void DoSignUp(PasswordBox pb)
        {
            User user = new User();
            user.Username = Username;
            user.Name = Name;
            user.Surname = Surname;
            user.Email = Email;
            user.Password = pb.Password;

        }

        private bool CanSignUp(PasswordBox pb)
        {
            return !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(pb.Password)
                                                   && !String.IsNullOrEmpty(Email);
        }

        #endregion
    }
}
