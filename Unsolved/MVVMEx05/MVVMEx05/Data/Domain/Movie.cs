using MVVMEx05.Data.Base;

namespace MVVMEx05.Data.Domain
{
    public class Movie : DomainClassAppBase
    {
        #region Constructors
        public Movie() : base(NullKey)
        {
        }

        public Movie(int imageKey, string title, int year, int mins, string studioName)
            : base(imageKey)
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
            Title = NotSet;
            Year = 2018;
            RunningTimeInMins = 120;
            StudioName = NotSet;
        } 
        #endregion
    }
}