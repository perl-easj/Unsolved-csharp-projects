using MVVMExample03.Transformation;
using ViewModel.Implementation;

namespace MVVMExample03.ViewModel
{
    /// <summary>
    /// Details View Model, to which the Details part of the view
    /// can bind its properties. The Details View Model object will
    /// refer to a "wrapped" View Model domain object (MovieViewModel),
    /// from which actual data is fetched.
    /// Note that INotifyPropertyChanged is implemented by the base class.
    /// </summary>
    public class DetailsViewModel : DetailsViewModelBase<MovieViewModel>
    {
        /// <summary>
        /// Constructor takes the "wrapped" View Model domain object
        /// (of type MovieViewModel) as parameter 
        /// </summary>
        public DetailsViewModel(MovieViewModel obj) : base(obj)
        {
        }

        public string Title
        {
            get { return DataObject.Title; }
            set
            {
                DataObject.Title = value;
                OnPropertyChanged();
            }
        }

        public string Year
        {
            get { return DataObject.Year; }
            set
            {
                DataObject.Year = value;
                OnPropertyChanged();
            }
        }
    }
}