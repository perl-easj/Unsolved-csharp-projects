using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MVVMStarter.Common;
using MVVMStarter.Models.Base;
using MVVMStarter.ViewModels.App;

#pragma warning disable 4014

namespace MVVMStarter.ViewModels.Base
{
    /// <summary>
    /// This class is a base class for any element-specific view model, 
    /// i.e. a view model that only wraps a single domain object.
    /// </summary>
    /// <typeparam name="TDomainClass">
    /// Type of domain object wrapped by the class
    /// </typeparam>
    public abstract class DetailsViewModelBase<TDomainClass> : INotifyPropertyChanged 
        where TDomainClass : DomainClassBase
    {
        #region Public properties
        /// <summary>
        /// The domain object wrapped by the view model
        /// </summary>
        public TDomainClass DomainObject;

        /// <summary>
        /// Manages dependencies between simple and
        /// aggregated properties
        /// /// </summary>
        public PropertyDependencyManager PropertyDependencies;
        #endregion

        protected DetailsViewModelBase(TDomainClass obj)
        {
            DomainObject = obj;
            PropertyDependencies = new PropertyDependencyManager();
        }

        /// <summary>
        /// Relays presentation of a validation error
        /// to the UserActionPresenter class
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="undo">Code for undoing invalid change</param>
        protected void PresentValidationError(string message, Action undo)
        {
            UserActionPresenter.PresentMessageOkOnly(message, "Undo", new RelayCommand(undo));
        }

        /// <summary>
        /// Calls OnPropertyChanged on the calling property,
        /// and also on all aggregated properties depending on it
        /// </summary>
        protected void OnPropertyChangedWithDependencies([CallerMemberName] string propertyName = null)
        {
            PropertyDependencies.Dependencies(propertyName).ForEach(OnPropertyChanged);
            OnPropertyChanged(propertyName);
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
