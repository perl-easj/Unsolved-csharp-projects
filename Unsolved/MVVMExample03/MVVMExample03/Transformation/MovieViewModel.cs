using DataTransformation.Implementation;
using MVVMExample03.Model;

namespace MVVMExample03.Transformation
{
    /// <summary>
    /// The MovieViewModel is a simple transformation from the
    /// Movie domain class to a class used in the View Model layer.
    /// </summary>
    public class MovieViewModel : TransformedWithDefaultBase<Movie>
    {
        #region Pure ViewModel implementation
        public MovieViewModel(Movie obj) : base(obj)
        {
        }

        public string Title { get; set; }
        public string Year { get; set; } 
        #endregion

        #region TransformedWithDefaultBase implementation
        public MovieViewModel()
        {
        }

        /// <summary>
        /// Used when constructing a View Model object from a given 
        /// Domain object (called from base class constructor)
        /// </summary>
        public override void SetValuesFromObject(Movie obj)
        {
            Key = obj.Key;
            Title = obj.Title;
            Year = obj.Year.ToString();
        }

        /// <summary>
        /// These values can be shown in e.g. the Details part of 
        /// a View, when a new entry is about to be created.
        /// </summary>
        public override void SetDefaultValues()
        {
            Key = NullKey;
            Title = "(title)";
            Year = "(year)";
        } 
        #endregion
    }
}