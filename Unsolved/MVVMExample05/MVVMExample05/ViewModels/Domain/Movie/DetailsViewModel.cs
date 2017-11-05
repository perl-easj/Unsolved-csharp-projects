using MVVMExample05.DataTransformation.Domain.Movie;
using ViewModel.Implementation;

namespace MVVMExample05.ViewModels.Domain.Movie
{
    public class DetailsViewModel : DetailsViewModelBase<MovieViewModel>
    {
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

        public string Mins
        {
            get { return DataObject.Mins; }
            set
            {
                DataObject.Mins = value;
                OnPropertyChanged();
            }
        }

        public string StudioId
        {
            get { return DataObject.StudioId; }
            set
            {
                DataObject.StudioId = value;
                OnPropertyChanged();
            }
        }

        public DetailsViewModel(MovieViewModel obj) : base(obj)
        {
        }
    }
}