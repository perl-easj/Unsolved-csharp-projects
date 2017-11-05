using System;
using DataTransformation.Implementation;

namespace MVVMExample05.DataTransformation.Domain.Movie
{
    public class MovieViewModelFactory : FactoryBase<Models.Domain.Movie.Movie, MovieViewModel>
    {
        public override Models.Domain.Movie.Movie CreateDomainObject(MovieViewModel vmObj)
        {
            return new Models.Domain.Movie.Movie(
                vmObj.Key,
                vmObj.Title,
                Int32.Parse(vmObj.Year),
                Int32.Parse(vmObj.Mins),
                Int32.Parse(vmObj.StudioId));
        }
    }
}