using Windows.UI.Xaml;
using AddOns.UI.Implementation;
using Commands.Implementation;
using MVVMEx05.Models.App;
using ViewModel.App.Implementation;

namespace MVVMEx05.ViewModels.App
{
    /// <summary>
    /// View model for the File view. Main purpose is to handle
    /// loading and saving events.
    /// </summary>
    public class FileViewModel : AppViewModelBase
    {
        #region Instance fields
        private bool _isLoading;
        private bool _isSaving;
        #endregion

        #region Constructor
        public FileViewModel()
        {
            _isLoading = false;
            _isSaving = false;

            AddCommands();
        }
        #endregion

        #region Properties for Data Binding
        public bool IsWorking
        {
            get { return _isLoading || _isSaving; }
        }

        public string LoadingText
        {
            get
            {
                if (_isLoading)
                {
                    return "Loading data...";
                }
                if (_isSaving)
                {
                    return "Saving data...";
                }
                return "";
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// This methods defines what should happen
        /// when load of data begins.
        /// </summary>
        private void OnLoadingBegins()
        {
            _isLoading = true;
            UpdateOnStateChange();
        }

        /// <summary>
        /// This methods defines what should happen
        /// when load of data ends.
        /// </summary>
        private void OnLoadingEnds()
        {
            _isLoading = false;
            UpdateOnStateChange();
        }

        /// <summary>
        /// This methods defines what should happen
        /// when save of data begins.
        /// </summary>
        private void OnSavingBegins()
        {
            _isSaving = true;
            UpdateOnStateChange();
        }

        /// <summary>
        /// This methods defines what should happen
        /// when save of data ends.
        /// </summary>
        private void OnSavingEnds()
        {
            _isSaving = false;
            UpdateOnStateChange();
        }

        /// <summary>
        /// This methods defines what should happens 
        /// whenever a state change occurs.
        /// </summary>
        private void UpdateOnStateChange()
        {
            OnPropertyChanged(nameof(IsWorking));
            OnPropertyChanged(nameof(LoadingText));
        }

        /// <summary>
        /// Add file-oriented menu entries and associated commands.
        /// </summary>
        public override void AddCommands()
        {
            NavigationCommands.Add("Load", new RelayCommandAsync(async () =>
            {
                DialogWithReturnValue.ReturnValueType retVal = await DialogWithReturnValue.PresentDialogWithReturnValue("Are you sure you want to LOAD model data?", "LOAD");
                if (retVal == DialogWithReturnValue.ReturnValueType.OK)
                {
                    OnLoadingBegins();
                    DomainModel.Instance.LoadEnds += OnLoadingEnds;
                    DomainModel.Instance.LoadModel();
                }
                else
                {
                    OnLoadingEnds();
                }
            }));

            NavigationCommands.Add("Save", new RelayCommandAsync(async () =>
            {
                DialogWithReturnValue.ReturnValueType retVal = await DialogWithReturnValue.PresentDialogWithReturnValue("Are you sure you want to SAVE model data?", "SAVE");
                if (retVal == DialogWithReturnValue.ReturnValueType.OK)
                {
                    OnSavingBegins();
                    DomainModel.Instance.SaveEnds += OnSavingEnds;
                    DomainModel.Instance.SaveModel();
                }
                else
                {
                    OnSavingEnds();
                }
            }));

            NavigationCommands.Add("Quit", new RelayCommandAsync(async () =>
            {
                DialogWithReturnValue.ReturnValueType retVal = await DialogWithReturnValue.PresentDialogWithReturnValue("Are you sure you want to QUIT?", "QUIT");
                if (retVal == DialogWithReturnValue.ReturnValueType.OK)
                {
                    Application.Current.Exit();
                }
            }));
        } 
        #endregion
    }
}