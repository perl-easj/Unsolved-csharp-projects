using DataTransformation.Implementation;
using MVVMExample05.DataTransformation.Domain.Movie;

namespace MVVMExample05.ViewModels.Domain.Movie
{
    public class ItemViewModel : DataWrapper<MovieViewModel>
    {
        public ItemViewModel(MovieViewModel obj) : base(obj)
        {
        }

        public string Description
        {
            get { return DataObject.Title; }
        }
    }
}