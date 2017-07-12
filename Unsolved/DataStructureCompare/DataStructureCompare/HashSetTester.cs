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

        public override void AddInitialStatement(int valueToInsert)
        {
            Collection.Add(valueToInsert);
        }

        public override void InsertBackStatement(int valueToInsert)
        {
            // Is "back" well-defined for a HashSet?
            Collection.Add(valueToInsert);
        }

        public override void InsertFrontStatement(int valueToInsert)
        {
            // Is "front" well-defined for a HashSet?
            Collection.Add(valueToInsert);
        }

        public override void LookupRandomStatement()
        {
            // Not really "lookup" - same code as "find"
            bool found = Collection.Contains(Generator.Next());
        }

        public override void DeleteRandomStatement()
        {
            Collection.Remove(Generator.Next());
        }

        public override void FindRandomStatement(int valueToFind)
        {
            bool found = Collection.Contains(valueToFind);
        }
    }
}