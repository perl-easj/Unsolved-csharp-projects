using ViewModel.Data.Implementation;

namespace BioDemo.ViewModels.Base
{
    /// <summary>
    /// This class will be a base class for all Data view model classes.
    /// A Data view model object will refer to a single domain object, which
    /// is provided as a parameter to the constructor.
    /// </summary>
    /// <typeparam name="T">Type of domain object being referred to</typeparam>
    public abstract class DataViewModelAppBase<T> : DataViewModelBase<T>
        where T : class
    {
        #region Constructor
        protected DataViewModelAppBase(T obj) : base(obj)
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// This property can be overrided in derived classes, but it
        /// is not mandatory to use this property at all.
        /// </summary>
        public virtual string HeaderText
        {
            get { return "Override HeaderText..."; }
        }

        /// <summary>
        /// This property can be overrided in derived classes, but it
        /// is not mandatory to use this property at all.
        /// </summary>
        public virtual string ContentText
        {
            get { return "Override ContentText..."; }
        } 
        #endregion
    }
}