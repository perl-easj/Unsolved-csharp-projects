using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

#pragma warning disable 4014

namespace MVVMStarter.Common
{
    public class UserActionPresenter
    {
        public static async Task PresentMessageNoAction(string message, string actionText)
        {
            var messageDialog = new MessageDialog(message);
            messageDialog.Commands.Add(new UICommand(actionText));
            await messageDialog.ShowAsync();
        }

        public static async Task PresentMessageOkOnly(string message, string actionText, RelayCommand userAction)
        {
            var messageDialog = new MessageDialog(message);
            messageDialog.Commands.Add(new UICommand(actionText, userAction.Execute));
            await messageDialog.ShowAsync();
        }

        public static async Task PresentMessageOkCancel(string message, string actionText, RelayCommand userAction)
        {
            var messageDialog = new MessageDialog(message);
            messageDialog.Commands.Add(new UICommand(actionText, userAction.Execute));
            messageDialog.Commands.Add(new UICommand("Cancel", command => { }));
            messageDialog.DefaultCommandIndex = 1;
            messageDialog.CancelCommandIndex = 1;
            await messageDialog.ShowAsync();
        }
    }
}
