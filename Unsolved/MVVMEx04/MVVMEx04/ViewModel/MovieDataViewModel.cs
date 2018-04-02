using System;
using MVVMEx04.Model;
using ViewModel.Data.Implementation;

namespace MVVMEx04.ViewModel
{
    /// <summary>
    /// The Data View Model class provides properties for Data Binding
    /// in the Details part of the view, and for each item in the list
    /// view collection. It also handles (a very modest) data validation
    /// and transformation.
    /// </summary>
    public class MovieDataViewModel : DataViewModelBase<Movie>
    {
        #region Constructor
        public MovieDataViewModel(Movie obj) : base(obj)
        {
        }
        #endregion

        #region Properties for Data Binding
        public string Title
        {
            get { return DataObject.Title; }
            set
            {
                DataObject.Title = value;
                OnPropertyChanged();
            }
        }

        public int Year
        {
            get { return DataObject.Year; }
            set
            {
                DataObject.Year = value;
                OnPropertyChanged();
            }
        }



        public int RunningTimeInMins
        {
            get { return DataObject.RunningTimeInMins; }
            set
            {
                    DataObject.RunningTimeInMins = value;
                OnPropertyChanged();
            }
        }

        public string StudioName
        {
            get { return DataObject.StudioName; }
            set
            {
                DataObject.StudioName = value;
            }
        }
        #endregion
    }
}