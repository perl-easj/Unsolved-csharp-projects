using Data.Transformed.Implementation;

namespace BioDemo.Data.Base
{
    /// <summary>
    /// This class will be a base class for all domain classes.
    /// This is preferred instead of letting domain classes inherit
    /// directly from CopyableWithDefaultValuesBase, since we can then
    /// change inheritance setup for all domain classes by changing
    /// this single base class.
    /// </summary>
    public abstract class DomainAppBase : CopyableWithDefaultValuesBase
    {
    }
}
