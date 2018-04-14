using System;
using AdapterExample.Implementations;
using AdapterExample.Interfaces;

namespace AdapterExample.ConfigAndTest
{
    public class AdapterTest
    {
        public static void Run()
        {
            IArrayCollection<Car> carArray = new ArrayCollection<Car>();
            carArray.Insert(new Car("AB 33 108", 12000), 0);
            carArray.Insert(new Car("CD 65 647", 15000), 1);
            carArray.Insert(new Car("EF 23 243", 35000), 2);
            carArray.Insert(new Car("GH 40 393", 24000), 3);
            carArray.Insert(new Car("IJ 82 553", 18000), 4);

            IIndexedCollection<Car> carIC = Configurator.Configure(carArray);
            Console.WriteLine("After Creation");
            PrintContent(carIC);

            carIC.DeleteAt(2);
            Console.WriteLine("After Delete at position 2");
            PrintContent(carIC);

            carIC.InsertAt(new Car("ZX 98 243", 20000), 1);
            Console.WriteLine("After Insert at position 1");
            PrintContent(carIC);

            carIC.Remove();
            Console.WriteLine("After Remove (at end)");
            PrintContent(carIC);

            carIC.Add(new Car("YP 80 626", 13000));
            Console.WriteLine("After Add (at end)");
            PrintContent(carIC);

            Car aCar = carIC.At(3);
            Console.WriteLine($"Car at index 3: {aCar}");
        }

        private static void PrintContent<T>(IIndexedCollection<T> ic)
        {
            for (int i = 0; i < ic.Count; i++)
            {
                Console.WriteLine($"[{i}]  {ic.At(i)}");
            }
            Console.WriteLine();
        }
    }
}