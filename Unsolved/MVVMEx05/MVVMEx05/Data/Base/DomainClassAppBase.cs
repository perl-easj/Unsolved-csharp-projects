using Data.Transformed.Implementation;

namespace MVVMEx05.Data.Base
{
    /// <summary>
    /// The intention is that all domain classes inherit 
    /// from this base class, and thereby have an image key.
    /// </summary>
    public abstract class DomainClassAppBase : CopyableWithDefaultValuesBase
    {
        public const string NotSet = "(not set)";

        protected DomainClassAppBase(int imageKey)
        {
            ImageKey = imageKey;
        }

        public int ImageKey { get; set; }
    }
}