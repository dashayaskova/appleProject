using System;
using System.Windows.Controls;
using System.Windows.Input;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using AppleTimer.Tools.Navigation;

namespace AppleTimer.ViewModels
{
    internal class LoginViewModel
    {
        #region Fields

        private RelayCommand<object> _signUpCommand;
        private RelayCommand<PasswordBox> _loginCommand;

        #endregion

        #region Props

        public RelayCommand<object> SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(o =>
                {
                    NavigationManager.Instance.Navigate(ViewType.SignUpView);
                }));
            }
        }

        public RelayCommand<PasswordBox> LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand<PasswordBox>(pb =>
                {

                }, pb => !String.IsNullOrEmpty(pb.Password) && !String.IsNullOrEmpty(Username)));
            }
        }

        public string Username { get; set; }
        public string Password { get; set; }


        #endregion
    }
}