using DataTransformation.Interfaces;
using MVVMExample03.Model;
using MVVMExample03.Transformation;
using ViewModel.Implementation;

namespace MVVMExample03.ViewModel
{
    /// <summary>
    /// The Factory class handles the (simple) job of creating
    /// Item View Model and Details View Model objects from a 
    /// given View Model domain object (in this case MovieViewModel).
    /// An instance of this factory will be used as a parameter 
    /// to the MasterDetailsViewModel.
    /// </summary>
    public class ViewModelFactory : ViewModelFactoryBase<Movie, MovieViewModel>
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