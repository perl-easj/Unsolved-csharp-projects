using System.Collections.Generic;
using ExtensionsViewModel.Implementation;
using MVVMExample04.Model;
using MVVMExample04.Transformation;

namespace MVVMExample04.ViewModel
{
    public class MasterDetailsViewModel : MasterDetailsViewModelCRUD<Movie, MovieViewModel, Movie>
    {
        public MasterDetailsViewModel()
            : base(new ViewModelFactory(),
                MovieCatalog.Instance,
                new List<string> { "Title", "Year", "StudioId" },
                new List<string> { "Mins" })
        {
        }
    }
}