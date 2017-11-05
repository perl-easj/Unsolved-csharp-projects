using System.Collections.Generic;
using ExtensionsViewModel.Implementation;
using MVVMExample05.DataTransformation.Domain.Studio;
using MVVMExample05.Models.App;

namespace MVVMExample05.ViewModels.Domain.Studio
{
    public class MasterDetailsViewModel : MasterDetailsViewModelCRUD<
        Models.Domain.Studio.Studio,
        StudioViewModel,
        Models.Domain.Studio.Studio>
    {
        public MasterDetailsViewModel()
            : base(new ViewModelFactory(),
                ObjectProvider.StudioCatalog,
                new List<string> { "Name", "HQCity" },
                new List<string> { "NoOfEmployees" })
        {
        }
    }
}