using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            IThreadSafeCatalog<long, long> catalog = new ThreadUnsafeCatalog();

            Task t1 = Task.Run(() => { InsertElements(catalog, 1, 10000); });
            Task t2 = Task.Run(() => { InsertElements(catalog, 10001, 20000); });
            Task t3 = Task.Run(() => { InsertElements(catalog, 20001, 30000); });
            Task t4 = Task.Run(() => { InsertElements(catalog, 30001, 40000); });
            Task.WaitAll(t1, t2, t3, t4);

            //InsertElements(catalog,     1, 10000);
            //InsertElements(catalog, 10001, 20000);
            //InsertElements(catalog, 20001, 30000);
            //InsertElements(catalog, 30001, 40000);

            Console.WriteLine("Count is " + catalog.Count + " (expected 40000)");
            Console.WriteLine("Sum of keys is " + catalog.Keys.Sum() + " (expected 800020000)");
            Console.WriteLine("Sum of values is " + catalog.Values.Sum() + " (expected 21334133340000)");

            Console.ReadKey();
        }

        static void InsertElements(IThreadSafeCatalog<long, long> catalog, int from, int to)
        {
            for (int i = from; i <= to; i++)
            {
                catalog.Add(i, i*i);
            }
        }
    }
}
