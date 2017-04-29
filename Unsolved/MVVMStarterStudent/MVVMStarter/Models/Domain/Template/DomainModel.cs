using MVVMStarter.Models.Base;
using MVVMStarter.Persistency.Base;

/// <summary>
/// TEMPLATE: You must 
/// 1) Create a file called DomainModel.cs in your domain folder (under Model/Domain)
/// 2) Delete the entire content of the file
/// 3) Copy-paste the entire content of this template into the file
/// 4) replace the text _REPLACEME_ with the name of your domain
/// 5) Delete this comment
/// </summary>
namespace MVVMStarter.Models.Domain._REPLACEME_
{
    public class DomainModel : DomainModelBase<_REPLACEME_>
    {
        #region Model Singleton implementation
        private static DomainModel _instance = null;

        public static DomainModel Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = new DomainModel();
                return _instance;
            }
        }

        /// <summary>
        /// Use a file-based persistent source
        /// </summary>
        private DomainModel() : base(new CollectionBase<_REPLACEME_>(), new FileSourceBase<_REPLACEME_>())
        {
        }
        #endregion
    }
}
