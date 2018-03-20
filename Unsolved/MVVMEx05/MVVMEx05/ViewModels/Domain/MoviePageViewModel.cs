using System.Collections.Generic;
using Data.Transformed.Interfaces;
using MVVMEx05.Data.Domain;
using MVVMEx05.Models.App;
using MVVMEx05.ViewModels.Base;

namespace MVVMEx05.ViewModels.Domain
{
    /// <summary>
    /// Page view model class for studios.
    /// </summary>
    public class MoviePageViewModel : PageViewModelAppBase<Movie>
    {
        #region Constructor
        public MoviePageViewModel() :
            base(DomainModel.Catalogs.Movies, new List<string> { "Title", "Year", "StudioName" }, new List<string> { "Mins" })
        {
        }
        #endregion

        #region Methods
        // Implementation of abstract method from base class
        public override IDataWrapper<Movie> CreateDataViewModel(Movie obj)
        {
            return new MovieDataViewModel(obj);
        }
        #endregion
    }
}