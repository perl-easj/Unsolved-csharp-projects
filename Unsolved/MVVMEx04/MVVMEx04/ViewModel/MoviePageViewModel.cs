using System.Collections.Generic;
using Data.Transformed.Interfaces;
using Extensions.ViewModel.Implementation;
using MVVMEx04.Model;

namespace MVVMEx04.ViewModel
{
    /// <summary>
    /// This class acts as a Data Context for the View.
    /// </summary>
    public class MoviePageViewModel : PageViewModelCRUD<Movie>
    {
        #region Constructor
        public MoviePageViewModel() : 
            base(new MovieCatalog(), new List<string>{ "Title", "Year", "StudioName"}, new List<string> { "Mins" })
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