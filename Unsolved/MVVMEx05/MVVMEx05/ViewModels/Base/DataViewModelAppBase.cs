using AddOns.Images.Implementation;
using AddOns.Images.Interfaces;
using Extensions.AddOns.Implementation;
using Extensions.ViewModel.Implementation;
using MVVMEx05.Data.Base;

namespace MVVMEx05.ViewModels.Base
{
    /// <summary>
    /// Base class for all domain-specific  data view models. Note that TViewData 
    /// is required to inherit from DomainClassAppBase, since we have not defined
    /// separate domain view models.
    /// </summary>
    public abstract class DataViewModelAppBase<TViewData> : DataViewModelWithImage<TViewData>
        where TViewData : DomainClassAppBase
    {
        #region Constructor
        protected DataViewModelAppBase(TViewData obj) : base(obj)
        {
        } 
        #endregion

        #region Properties for Data Binding
        public override int ImageKey
        {
            get { return DataObject.ImageKey; }
        }

        /// <summary>
        /// Should be overrided in derived classes
        /// </summary>
        public virtual string HeaderText
        {
            get { return "Override HeaderText..."; }
        }

        /// <summary>
        /// Should be overrided in derived classes
        /// </summary>
        public virtual string ContentText
        {
            get { return "Override ContentText..."; }
        } 
        #endregion
    }
}