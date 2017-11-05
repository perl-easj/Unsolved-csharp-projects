using DataTransformation.Implementation;

namespace MVVMExample05.DataTransformation.Domain.Movie
{
    public class MovieViewModel : TransformedWithDefaultBase<Models.Domain.Movie.Movie>
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Mins { get; set; }
        public string StudioId { get; set; }

        public override void SetValuesFromObject(Models.Domain.Movie.Movie obj)
        {
            Title = obj.Title;
            Year = obj.Year.ToString();
            Mins = obj.RunningTimeInMins.ToString();
            StudioId = obj.StudioId.ToString();
        }

        public override void SetDefaultValues()
        {
            Title = "(title)";
            Year = "(year)";
            Mins = "(minutes)";
            StudioId = "(studio id)";
        }
    }
}