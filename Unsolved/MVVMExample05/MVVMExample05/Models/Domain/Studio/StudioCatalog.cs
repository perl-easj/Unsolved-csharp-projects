using ExtensionsModel.Implementation;
using MVVMExample05.DataTransformation.Domain.Studio;

namespace MVVMExample05.Models.Domain.Studio
{
    public class StudioCatalog : FilePersistableCatalogNoDTO<Studio, StudioViewModel>
    {
        #region Model Singleton implementation
        private static StudioCatalog _instance;

        public static StudioCatalog Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = new StudioCatalog();
                return _instance;
            }
        }

        private StudioCatalog() : base(new StudioViewModelFactory())
        {
        }
        #endregion
    }
}