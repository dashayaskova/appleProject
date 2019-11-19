using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using AppleTimer.Tools;
using AppleTimer.Tools.Managers;
using AppleTimer.Tools.Navigation;
using System.Linq;
using DbModels.Models;

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
                return _loginCommand ?? (_loginCommand = new RelayCommand<PasswordBox>(DoLogin, pb => !String.IsNullOrEmpty(pb.Password) && !String.IsNullOrEmpty(Username)));
            }
        }

        public string Username { get; set; }
        public string Password { get; set; }


        #endregion
        
        private async void DoLogin(PasswordBox pb)
        {
            LoaderManager.Instance.ShowLoader();

            var result = await Task.Run(() =>
            {
                using (var serv = new TimerService.TimerServerClient(StationManager.EndpointName))
                {
                    
                    if (!serv.UserExists(Username, pb.Password))
                    {
                        return null;
                    }

                    User user = serv.GetUser(Username, pb.Password);
                    user.Groups = serv.GetUserGroups(user).ToList();
                    user.Records = serv.GetUserRecords(user).ToList();

                    return user;
                }
            });
            LoaderManager.Instance.HideLoader();

            if (result == null)
            {
                MessageBox.Show("Oooops. Couldn't find you.");
            }
            else
            {
                StationManager.CurrentUser = result;
                StationManager.CurRecord = new Record(result);

                NavigationManager.Instance.Navigate(ViewType.MainView);
            }
        }

    }
}