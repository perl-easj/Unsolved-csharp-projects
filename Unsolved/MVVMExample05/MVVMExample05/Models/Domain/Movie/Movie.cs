using DataTransformation.Implementation;

namespace MVVMExample05.Models.Domain.Movie
{
    public class Movie : TransformedBase<Movie>
    {
        public Movie()
        {
        }

        public Movie(int key, string title, int year, int mins, int studioId) 
            : base(key)
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

        public override void SetValuesFromObject(Movie obj)
        {
            Key = obj.Key;
            Title = obj.Title;
            Year = obj.Year;
            RunningTimeInMins = obj.RunningTimeInMins;
            StudioId = obj.StudioId;
        }
    }
}