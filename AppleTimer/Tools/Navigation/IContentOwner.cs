using System.Windows.Controls;

namespace AppleTimer.Tools.Navigation
{
    internal interface IContentOwner
    {
        ContentControl ContentControl { get; }
    }
}