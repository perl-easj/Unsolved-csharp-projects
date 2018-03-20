using System.Collections.Generic;
using Data.Transformed.Interfaces;
using MVVMEx05.Data.Domain;
using MVVMEx05.Models.App;
using MVVMEx05.ViewModels.Base;

namespace MVVMEx05.ViewModels.Domain
{
    /// <summary>
    /// Page view model class for studios.
    /// </summary>
    public class StudioPageViewModel : PageViewModelAppBase<Studio>
    {
        #region Constructor
        public StudioPageViewModel() :
            base(DomainModel.Catalogs.Studios, new List<string> { "Name", "HQCity" }, new List<string> { "NoOfEmployees" })
        {
        }
        #endregion

        #region Methods
        // Implementation of abstract method from base class
        public override IDataWrapper<Studio> CreateDataViewModel(Studio obj)
        {
            return new StudioDataViewModel(obj);
        }
        #endregion
    }
}