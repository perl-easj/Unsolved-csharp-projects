namespace MVVMExample05.Models.App
{
    public class ObjectProvider
    {
        public static Domain.Movie.MovieCatalog MovieCatalog
        {
            get { return Domain.Movie.MovieCatalog.Instance; }
        }

        public static Domain.Studio.StudioCatalog StudioCatalog
        {
            get { return Domain.Studio.StudioCatalog.Instance; }
        }
    }
}