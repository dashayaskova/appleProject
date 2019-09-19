using System;
using AppleTimer.Views;

namespace AppleTimer.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.LoginView:
                    ViewsDictionary.Add(viewType, new LoginControlView());
                    break;
                case ViewType.SignUpView:
                    ViewsDictionary.Add(viewType, new SignUpControlView());
                    break;
				case ViewType.MainView:
					ViewsDictionary.Add(viewType, new MainView());
					break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}