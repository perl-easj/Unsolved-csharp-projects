using DataTransformation.Implementation;
using MVVMExample04.Transformation;

namespace MVVMExample04.ViewModel
{
    /// <summary>
    /// Item View Model, to which the Data Template of e.g. a ListView
    /// can bind its properties. The Item View Model object will
    /// refer to a "wrapped" View Model domain object (MovieViewModel),
    /// from which actual data is fetched.
    /// </summary>
    public class ItemViewModel : DataWrapper<MovieViewModel>
    {
        /// <summary>
        /// Constructor takes the "wrapped" View Model domain object
        /// (of type MovieViewModel) as parameter 
        /// </summary>
        public ItemViewModel(MovieViewModel obj) : base(obj)
        {
        }

        /// <summary>
        /// ListView Data Template binds to this property
        /// </summary>
        public string Description
        {
            get { return DataObject.Title; }
        }
    }
}