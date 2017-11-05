using DataTransformation.Implementation;

namespace MVVMExample04.Model
{
    /// <summary>
    /// The domain class needs to inherit from TransformedBase,
    /// since it also acts as a DTO class.
    /// </summary>
    public class Movie : TransformedBase<Movie>
    {
        #region Pure Domain Class implementation
        public Movie(string title, int year, int mins, int studioId) : base(NullKey)
        {
            Title = title;
            Year = year;
            RunningTimeInMins = mins;
            StudioId = studioId;
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public int RunningTimeInMins { get; set; }
        public int StudioId { get; set; }
        #endregion

        #region TransformedBase implementation
        public Movie() : base(NullKey)
        {
        }

        public override void SetValuesFromObject(Movie obj)
        {
            Key = obj.Key;
            Title = obj.Title;
            Year = obj.Year;
            RunningTimeInMins = obj.RunningTimeInMins;
            StudioId = obj.StudioId;
        }
        #endregion
    }
}