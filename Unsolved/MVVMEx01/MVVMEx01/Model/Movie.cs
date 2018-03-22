using Data.InMemory.Implementation;

namespace MVVMEx01.Model
{
    /// <summary>
    /// The domain class needs to inherit from StorableBase,
    /// in order to be storable in a Catalog.
    /// </summary>
    public class Movie : StorableBase
    {
        #region Constructor
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