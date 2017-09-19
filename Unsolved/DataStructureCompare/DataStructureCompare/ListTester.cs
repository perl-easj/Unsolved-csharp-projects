using System.Collections.Generic;
// ReSharper disable UnusedVariable

namespace DataStructureCompare
{
    /// <summary>
    /// Specific test of List collection class
    /// </summary>
    public class ListTester : DataStructureTesterBase<List<int>>
    {
        public ListTester(List<int> collection) : base(collection)
        {
        }

        /// <summary>
        /// Adds an element using the Add method, 
        /// i.e. adds to end of list
        /// </summary>
        public override void AddInitialStatement(int valueToInsert)
        {
            Collection.Add(valueToInsert);
        }

        /// <summary>
        /// Adds an element using the Add method, 
        /// i.e. adds to end of list
        /// </summary>
        public override void InsertBackStatement(int valueToInsert)
        {
            Collection.Add(valueToInsert);
        }

        /// <summary>
        /// Adds an element using the Insert(0,...) method, 
        /// i.e. adds to front of list
        /// </summary>
        public override void InsertFrontStatement(int valueToInsert)
        {
            Collection.Insert(0, valueToInsert);
        }

        /// <summary>
        /// Performs a lookup using the index operator []
        /// </summary>
        public override void LookupRandomStatement()
        {
            int value = Collection[Generator.Next(Collection.Count)];
        }

        /// <summary>
        /// Performs a deletion using the RemoveAt method.
        /// </summary>
        public override void DeleteRandomStatement()
        {
            Collection.RemoveAt(Generator.Next(Collection.Count));
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