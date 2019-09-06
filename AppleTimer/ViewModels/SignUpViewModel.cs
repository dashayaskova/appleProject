using System;
using System.Windows;
using System.Windows.Controls;
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
            MessageBox.Show(pb.Password + "BLlAAAAA");
        }

        private bool CanSignUp(object obj)
        {
            return !String.IsNullOrEmpty(Username);
        }

        #endregion
    }
}
