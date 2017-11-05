using System;
using DataTransformation.Implementation;
using MVVMExample04.Model;

namespace MVVMExample04.Transformation
{
    /// <summary>
    /// This class implements a "Domain class to View Model Domain class"
    /// factory, able to transform between the two classes. An instance of
    /// this factory will be used as a parameter to the MovieCatalog.
    /// </summary>
    public class MovieViewModelFactory : FactoryBase<Movie, MovieViewModel>
    {
        public override Movie CreateDomainObject(MovieViewModel tObj)
        {
            // We do not worry about error handling...
            return new Movie(tObj.Title, int.Parse(tObj.Year), int.Parse(tObj.Mins), Int32.Parse(tObj.StudioId))
            {
                Key = tObj.Key
            };
        }
    }
}