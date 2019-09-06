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
        private RelayCommand<object> _loginCommand;

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

        #endregion
    }
}