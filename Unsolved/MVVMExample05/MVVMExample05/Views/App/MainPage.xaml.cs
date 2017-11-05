using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Command.Implementation;
using MVVMExample05.Configuration.App;
using MVVMExample05.Views.Domain.Movie;
using Persistency.Implementation;
using UI.Implementation;

// ReSharper disable UnusedParameter.Local
#pragma warning disable 4014

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MVVMExample05.Views.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            AppConfig.Setup();
            AppFrame.Navigate(typeof(OpeningView));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            AppSplitView.IsPaneOpen = !AppSplitView.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MovieView.IsSelected)
            {
                TryNavigate(typeof(View), "MovieView");
            }
            if (StudioView.IsSelected)
            {
                TryNavigate(typeof(Domain.Studio.View), "StudioView");
            }
            if (Load.IsSelected)
            {
                AppFrame.Navigate(typeof(OpeningView));
                UIService.PresentMessageSingleActionCancel("Are you sure you want to LOAD model data?", "LOAD", new RelayCommand(PersistencyManager.Load));
            }
            if (Save.IsSelected)
            {
                AppFrame.Navigate(typeof(OpeningView));
                UIService.PresentMessageSingleActionCancel("Are you sure you want to SAVE model data?", "SAVE", new RelayCommand(PersistencyManager.Save));
            }
            if (Quit.IsSelected)
            {
                AppFrame.Navigate(typeof(OpeningView));
                UIService.PresentMessageSingleActionCancel("Are you sure you want to QUIT?", "QUIT", new RelayCommand(Application.Current.Exit));
            }
        }

        private void TryNavigate(System.Type viewType, string viewName)
        {
            if (true) // Replace if you want to use login-based access restrictions
            {
                AppFrame.Navigate(viewType);
            }
            else
            {
                // Inform user about insufficient access rights
            }
        }
    }
}
