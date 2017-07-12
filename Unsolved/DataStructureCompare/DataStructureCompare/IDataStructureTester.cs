namespace DataStructureCompare
{
    /// <summary>
    /// This interface should be implemented by any class
    /// participating in the comparative test. All implementations
    /// should return the running time measured in milliseconds.
    /// </summary>
    public interface IDataStructureTester
    {
        /// <summary>
        /// Add values to an empty collection object
        /// </summary>
        long AddInitial(int valuesToAdd, int maxValue);

        /// <summary>
        /// Add values to the back of a collection object.
        /// (note that "back" may not be well-defined for
        /// all collection classes).
        /// </summary>
        long InsertBack(int valuesToAdd, int maxValue);

        /// <summary>
        /// Add values to the front of a collection object.
        /// (note that "front" may not be well-defined for
        /// all collection classes).
        /// </summary>
        long InsertFront(int valuesToAdd, int maxValue);

        /// <summary>
        /// Perform randomised lookup of values
        /// </summary>
        long LookupRandom(int numberOfLookups);

        /// <summary>
        /// Perform randomised lookup of values
        /// </summary>
        long DeleteRandom(int numberOfDeletes);

        /// <summary>
        /// Find random values in collection object.
        /// </summary>
        long FindRandom(int numberOfFinds, int maxValue);
    }
}