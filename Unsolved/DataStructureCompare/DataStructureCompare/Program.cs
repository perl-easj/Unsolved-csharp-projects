using System;
using System.Collections.Generic;

namespace DataStructureCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Setup
            ListTester lt = new ListTester(new List<int>());
            LinkedListTester llt = new LinkedListTester(new LinkedList<int>());
            HashSetTester hst = new HashSetTester(new HashSet<int>());

            int noOfInserts = 10000;
            int noOfLookups = noOfInserts / 10;
            int noOfDeletes = noOfInserts / 10;
            int noOfFinds = noOfInserts / 10;
            int maxValue = Int32.MaxValue;
            #endregion

            #region List test
            Console.WriteLine("List:");
            Console.WriteLine("Inserting into empty with Add:                     " + lt.AddInitial(noOfInserts, maxValue) + " ms.");
            Console.WriteLine("Inserting back into non-empty with Add:            " + lt.InsertBack(noOfInserts, maxValue) + " ms.");
            Console.WriteLine("Inserting front into non-empty with Insert(0,...): " + lt.InsertFront(noOfInserts, maxValue) + " ms.");
            Console.WriteLine("Random index lookup in non-empty with []:          " + lt.LookupRandom(noOfLookups) + " ms.");
            Console.WriteLine("Random index delete in non-empty with RemoveAt:    " + lt.DeleteRandom(noOfDeletes) + " ms.");
            Console.WriteLine("Random value lookup in non-empty with Contains:    " + lt.FindRandom(noOfFinds, maxValue) + " ms.");
            Console.WriteLine();
            #endregion

            #region LinkedList test
            Console.WriteLine("LinkedList:");
            Console.WriteLine("Inserting into empty with AddLast:                 " + llt.AddInitial(noOfInserts, maxValue) + " ms.");
            Console.WriteLine("Inserting back into non-empty with AddLast:        " + llt.InsertBack(noOfInserts, maxValue) + " ms.");
            Console.WriteLine("Inserting front into non-empty with AddFirst:      " + llt.InsertFront(noOfInserts, maxValue) + " ms.");
            Console.WriteLine("Random index lookup in non-empty with ElementAt:   " + llt.LookupRandom(noOfLookups) + " ms.");
            Console.WriteLine("Random index delete in non-empty with Remove:      " + llt.DeleteRandom(noOfDeletes) + " ms.");
            Console.WriteLine("Random value lookup in non-empty with Contains:    " + llt.FindRandom(noOfFinds, maxValue) + " ms.");
            Console.WriteLine();
            #endregion

            #region HashSet test
            Console.WriteLine("HashSet:");
            Console.WriteLine("Inserting into empty with Add:                     " + hst.AddInitial(noOfInserts, maxValue) + " ms.");
            Console.WriteLine("Inserting back into non-empty with Add:            " + hst.InsertBack(noOfInserts, maxValue) + " ms.");
            Console.WriteLine("Inserting front into non-empty with Add:           " + hst.InsertFront(noOfInserts, maxValue) + " ms.");
            Console.WriteLine("Random value lookup in non-empty with Contains:    " + hst.LookupRandom(noOfLookups) + " ms.");
            Console.WriteLine("Random value delete in non-empty with Remove:      " + hst.DeleteRandom(noOfDeletes) + " ms.");
            Console.WriteLine("Random value lookup in non-empty with Contains:    " + hst.FindRandom(noOfFinds, maxValue) + " ms.");
            Console.WriteLine(); 
            #endregion

            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
