using Data.InMemory.Implementation;

namespace MVVMEx02.Model
{
    /// <summary>
    /// The domain class needs to inherit from CopyableBase,
    /// in order to be storable in a Catalog, and be the
    /// target of a Delete command.
    /// </summary>
    public class Movie : CopyableBase
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