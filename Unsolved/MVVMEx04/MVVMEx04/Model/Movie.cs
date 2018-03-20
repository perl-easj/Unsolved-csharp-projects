using Data.Transformed.Implementation;

namespace MVVMEx04.Model
{
    /// <summary>
    /// The domain class inherits from CopyableWithDefaultValuesBase, in order 
    /// to be storable in a Catalog, and act as a view model class.
    /// </summary>
    public class Movie : CopyableWithDefaultValuesBase
    {
        #region Constructors
        public Movie()
        {
        }

        public Movie(string title, int year, int mins, string studioName)
        {
            Title = title;
            Year = year;
            RunningTimeInMins = mins;
            StudioName = studioName;
        }
        #endregion

        #region Properties
        public string Title { get; set; }
        public int Year { get; set; }
        public int RunningTimeInMins { get; set; }
        public string StudioName { get; set; }
        #endregion

        #region Methods
        public override void SetDefaultValues()
        {
            Title = "(not set)";
            Year = 2018;
            RunningTimeInMins = 100;
            StudioName = "(not set)";
        } 
        #endregion
    }
}