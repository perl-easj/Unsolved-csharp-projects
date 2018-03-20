using System;
using MVVMEx05.Data.Domain;
using MVVMEx05.ViewModels.Base;

namespace MVVMEx05.ViewModels.Domain
{
    /// <summary>
    /// Data view model class for movies.
    /// </summary>
    public class MovieDataViewModel : DataViewModelAppBase<Movie>
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

        public string Year
        {
            get { return DataObject.Year.ToString(); }
            set
            {
                if (int.TryParse(value, out var year))
                {
                    DataObject.Year = year;
                    OnPropertyChanged();
                }
                else
                {
                    throw new ArgumentException("Illegal value in Year field");
                }
            }
        }

        public string RunningTimeInMins
        {
            get { return DataObject.RunningTimeInMins.ToString(); }
            set
            {
                if (int.TryParse(value, out var runTime))
                {
                    DataObject.RunningTimeInMins = runTime;
                    OnPropertyChanged();
                }
                else
                {
                    throw new ArgumentException("Illegal value in RunningTimeInMins field");
                }
            }
        }

        public string StudioName
        {
            get { return DataObject.StudioName; }
            set
            {
                DataObject.StudioName = value;
                OnPropertyChanged();
            }
        }

        public override string HeaderText
        {
            get { return Title; }
        }

        public override string ContentText
        {
            get { return $"({Year})"; }
        }
        #endregion
    }
}