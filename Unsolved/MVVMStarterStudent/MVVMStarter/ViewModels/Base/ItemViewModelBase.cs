using System;
using Windows.UI.Xaml;
using MVVMStarter.Models.Base;

namespace MVVMStarter.ViewModels.Base
{
    public abstract class ItemViewModelBase<TDomainClass> 
        where TDomainClass : DomainClassBase
    {
        public TDomainClass DomainObject;

        public Visibility ImageVisibility
        {
            get { return ImageIsVisible ? Visibility.Visible : Visibility.Collapsed; }
        }

        #region Properties (override in model-specific item view model)
        /// <summary>
        /// Override this property to provide a string description of a domain object. 
        /// This description is then displayed for each item in the Master part of the view.
        /// </summary>
        public virtual string Description
        {
            get { return DomainObject.ToString(); }
        }

        /// <summary>
        /// Override this property to provide a font size for the description. 
        /// </summary>
        public virtual int FontSize
        {
            get { return 18; }
        }

        /// <summary>
        /// Override this property to provide an image source for a domain object. 
        /// This image is then displayed for each item in the Master part of the view.
        /// </summary>
        public virtual string ImageSource
        {
            get { return String.Empty; }
        }

        /// <summary>
        /// Override this property to define the visibility of the image part
        /// </summary>
        public virtual bool ImageIsVisible
        {
            get { return true; }
        }

        /// <summary>
        /// Override this property to define the size of the image part
        /// </summary>
        public virtual int ImageSize
        {
            get { return 80; }
        }
        #endregion

        protected ItemViewModelBase(TDomainClass obj)
        {
            DomainObject = obj;
        }
    }
}
