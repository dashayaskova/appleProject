namespace AppleTimer.Tools.Navigation
{
    internal enum ViewType
    {
        LoginView,
        SignUpView,
		MainView
        
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
        void Dispose(ViewType viewType);
    }
}