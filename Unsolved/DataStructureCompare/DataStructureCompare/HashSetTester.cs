using System.Collections.Generic;
// ReSharper disable UnusedVariable

namespace DataStructureCompare
{
    /// <summary>
    /// Specific test of HashSet collection class
    /// </summary>
    public class HashSetTester : DataStructureTesterBase<HashSet<int>>
    {
        public HashSetTester(HashSet<int> collection) : base(collection)
        {
        }

        /// <summary>
        /// Adds an element using the Add method.
        /// Note that "front" and "back" does not really
        /// make sense for a HashSet.
        /// </summary>
        public override void AddInitialStatement(int valueToInsert)
        {
            Collection.Add(valueToInsert);
        }

        /// <summary>
        /// Adds an element using the Add method.
        /// Note that "front" and "back" does not really
        /// make sense for a HashSet.
        /// </summary>
        public override void InsertBackStatement(int valueToInsert)
        {
            Collection.Add(valueToInsert);
        }

        /// <summary>
        /// Adds an element using the Add method.
        /// Note that "front" and "back" does not really
        /// make sense for a HashSet.
        /// </summary>
        public override void InsertFrontStatement(int valueToInsert)
        {
            Collection.Add(valueToInsert);
        }

        /// <summary>
        /// Performs a lookup using the Contains method.
        /// Not really comparable to index-based lookups.
        /// </summary>
        public override void LookupRandomStatement()
        {
            // Not really "lookup" - same code as "find"
            bool found = Collection.Contains(Generator.Next());
        }


        /// <summary>
        /// Performs a deletion using the Remove method.
        /// </summary>
        public override void DeleteRandomStatement()
        {
            Collection.Remove(Generator.Next());
        }

        /// <summary>
        /// Performs a value lookup using the Contains method
        /// </summary>
        public override void FindRandomStatement(int valueToFind)
        {
            bool found = Collection.Contains(valueToFind);
        }
    }
}