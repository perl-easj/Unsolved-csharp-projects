using System.Collections.Generic;
using System.Linq;
// ReSharper disable UnusedVariable

namespace DataStructureCompare
{
    /// <summary>
    /// Specific test of LinkedList collection class
    /// </summary>
    public class LinkedListTester : DataStructureTesterBase<LinkedList<int>>
    {
        public LinkedListTester(LinkedList<int> collection) : base(collection)
        {
        }

        /// <summary>
        /// Adds an element using the AddLast method, 
        /// i.e. adds to end of list
        /// </summary>
        public override void AddInitialStatement(int valueToInsert)
        {
            Collection.AddLast(valueToInsert);
        }

        /// <summary>
        /// Adds an element using the AddLast method, 
        /// i.e. adds to end of list
        /// </summary>
        public override void InsertBackStatement(int valueToInsert)
        {
            Collection.AddLast(valueToInsert);
        }

        /// <summary>
        /// Adds an element using the AddFirst method, 
        /// i.e. adds to front of list
        /// </summary>
        public override void InsertFrontStatement(int valueToInsert)
        {
            Collection.AddFirst(valueToInsert);
        }

        /// <summary>
        /// Performs a lookup using the ElementAt method
        /// </summary>
        public override void LookupRandomStatement()
        {
            // Notice that the []-operator is not available for LinkedList (why not?)
            int value = Collection.ElementAt(Generator.Next(Collection.Count));
        }

        /// <summary>
        /// Performs a deletion using the Remove method.
        /// Note that this call also involves calling ElementAt.
        /// </summary>
        public override void DeleteRandomStatement()
        {
            // Notice that RemoveAt is not available for LinkedList
            Collection.Remove(Collection.ElementAt(Generator.Next(Collection.Count)));
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