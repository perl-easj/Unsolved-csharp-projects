namespace MVVMStarter.Models.Base
{
    /// <summary>
    /// Base class for domain classes. A domain class MUST inherit 
    /// from this class, and implement the abstract methods
    /// </summary>
    public abstract class DomainClassBase
    {
        /// <summary>
        /// Key property. NB: Keys are handled by the model base classes,
        /// and any key value set externally will be overwritten.
        /// </summary>
        public int Key { get; set; }

        /// <summary>
        /// Ensures that default values are set when a domain
        /// object is created.
        /// </summary>
        protected DomainClassBase()
        {
            SetDefaultValues();
        }

        public virtual DomainClassBase Clone()
        {
            return (DomainClassBase)MemberwiseClone();
        }

        public abstract void SetDefaultValues();
    }
}
