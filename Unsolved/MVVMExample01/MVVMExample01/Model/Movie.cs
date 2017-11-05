using DataTransformation.Implementation;

namespace MVVMExample01.Model
{
    /// <summary>
    /// The domain class needs to inherit from TransformedBase,
    /// since it also acts as a Domain View Model class (and in 
    /// principle also as a Data Transfer class).
    /// </summary>
    public class Movie : TransformedBase<Movie>
    {
        #region Pure Domain Class implementation
        public Movie(string title, int year) : base(NullKey)
        {
            Title = title;
            Year = year;
        }

        public string Title { get; set; }
        public int Year { get; set; }
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
        }
        #endregion
    }
}