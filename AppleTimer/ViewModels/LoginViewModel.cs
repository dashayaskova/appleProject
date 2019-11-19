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
            using (var serv = new TimerService.TimerServerClient(StationManager.EndpointName))
            {
                var result = await Task.Run(() =>
                {
                    if (!serv.UserExists(Username, pb.Password))
                    {
                        return null;
                    }
                    User user = serv.GetUser(Username, pb.Password);
                    user.Groups = serv.GetUserGroups(user).ToList();
                    user.Records = serv.GetUserRecords(user).ToList();
                    return user;
                });


                if (result == null)
                {
                    MessageBox.Show("Oooops. Couldn't find you.");
                    LoaderManager.Instance.HideLoader();
                    return;
                }
                else
                {
                    StationManager.CurrentUser = result;
                    var record = await Task.Run(() => serv.GetUserRecords(result).Where(r => r.EndTime == null).FirstOrDefault());
                    if (record != null)
                    {
                        record.User = result;
                        StationManager.CurRecord = record;
                    }
                    else
                    {
                        Record rec = new Record();
                        rec.User = result;
                        rec.Id = Guid.NewGuid();
                        StationManager.CurRecord = rec;
                    }
                    LoaderManager.Instance.HideLoader();
                    pb.Clear();
                    NavigationManager.Instance.Navigate(ViewType.MainView);
                }

            }
        }
    }

}
