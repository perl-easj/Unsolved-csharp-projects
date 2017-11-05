using System.Collections.Generic;
using ExtensionsViewModel.Implementation;
using MVVMExample05.DataTransformation.Domain.Movie;
using MVVMExample05.Models.App;

namespace MVVMExample05.ViewModels.Domain.Movie
{
    public class MasterDetailsViewModel : MasterDetailsViewModelCRUD<
        Models.Domain.Movie.Movie,
        MovieViewModel, 
        Models.Domain.Movie.Movie>
    {
        public MasterDetailsViewModel()
            : base(new ViewModelFactory(),
                ObjectProvider.MovieCatalog,
                new List<string> { "Title", "Year", "StudioId" },
                new List<string> { "Mins" })
        {
        }
    }
}