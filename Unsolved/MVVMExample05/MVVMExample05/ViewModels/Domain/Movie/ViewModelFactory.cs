using DataTransformation.Interfaces;
using MVVMExample05.DataTransformation.Domain.Movie;
using ViewModel.Implementation;

namespace MVVMExample05.ViewModels.Domain.Movie
{
    public class ViewModelFactory : ViewModelFactoryBase<Models.Domain.Movie.Movie, MovieViewModel>
    {
        public override IDataWrapper<MovieViewModel> CreateDetailsViewModel(MovieViewModel obj)
        {
            return new DetailsViewModel(obj);
        }

        public override IDataWrapper<MovieViewModel> CreateItemViewModel(MovieViewModel obj)
        {
            return new ItemViewModel(obj);
        }
    }
}