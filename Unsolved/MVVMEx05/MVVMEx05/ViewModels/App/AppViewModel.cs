using System;
using Windows.UI.Xaml.Controls;
using Commands.Implementation;
using ViewModel.App.Implementation;
using MVVMEx05.Views.Domain;

namespace MVVMEx05.ViewModels.App
{
    /// <summary>
    /// View model for the application as such. Main purpose is to handle
    /// user choice in navigation Menu.
    /// </summary>
    public class AppViewModel : AppViewModelBase
    {
        #region Instance fields
        private NavigationViewItem _selectedMenuItem;
        #endregion

        #region Constructor
        public AppViewModel()
        {
            _selectedMenuItem = null;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Handle menu selection
        /// </summary>
        public NavigationViewItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                // If no menu item selected; do nothing
                _selectedMenuItem = value;
                if (_selectedMenuItem == null) return;

                // If unknown menu item selected; throw exception
                string tag = _selectedMenuItem.Tag.ToString();
                if (!NavigationCommands.ContainsKey(tag))
                {
                    throw new ArgumentException($"Menu entry {tag} has no matching navigation command");
                }

                // Menu item is known; execute corresponding command.
                NavigationCommands[tag].Execute(null);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add valid navigation entries and associated commands.
        /// </summary>
        public override void AddCommands()
        {
            NavigationCommands.Add("File", new RelayCommand(() =>
            {
                AppFrame.Navigate(typeof(Views.App.FileView));
            }));

            NavigationCommands.Add("OpenMovieView", new RelayCommand(() =>
            {
                AppFrame.Navigate(typeof(MovieView));
            }));

            NavigationCommands.Add("OpenStudioView", new RelayCommand(() =>
            {
                AppFrame.Navigate(typeof(StudioView));
            }));
        } 
        #endregion
    }
}