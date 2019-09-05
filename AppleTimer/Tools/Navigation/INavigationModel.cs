namespace AppleTimer.Tools.Navigation
{
    internal enum ViewType
    {
        LoginView,
        SignUpView
        
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}