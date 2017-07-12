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

        public override void AddInitialStatement(int valueToInsert)
        {
            Collection.AddLast(valueToInsert);
        }

        public override void InsertBackStatement(int valueToInsert)
        {
            Collection.AddLast(valueToInsert);
        }

        public override void InsertFrontStatement(int valueToInsert)
        {
            Collection.AddFirst(valueToInsert);
        }

        public override void LookupRandomStatement()
        {
            // Notice that the []-operator is not available for LinkedList (why not?)
            int value = Collection.ElementAt(Generator.Next(Collection.Count));
        }

        public override void DeleteRandomStatement()
        {
            // Notice that RemoveAt is not available for LinkedList
            Collection.Remove(Collection.ElementAt(Generator.Next(Collection.Count)));
        }

        public override void FindRandomStatement(int valueToFind)
        {
            bool found = Collection.Contains(valueToFind);
        }
    }
}