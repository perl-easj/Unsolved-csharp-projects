using Data.InMemory.Implementation;

namespace MVVMEx03.Model
{
    /// <summary>
    /// The domain class needs to inherit from CopyableBase, in order 
    /// to be storable in a Catalog, and act as a view model class.
    /// </summary>
    public class Movie : CopyableBase
    {
        #region Constructors
        public Movie()
        {
        }

        public Movie(string title, int year)
        {
            Title = title;
            Year = year;
        }
        #endregion

        #region Properties
        public string Title { get; set; }
        public int Year { get; set; }
        #endregion
    }
}