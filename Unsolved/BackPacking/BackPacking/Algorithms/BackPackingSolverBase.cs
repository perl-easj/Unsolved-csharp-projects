using System;
using System.Collections.Generic;
using BackPacking.Containers;
using BackPacking.Item;

namespace BackPacking.Algorithms
{
    /// <summary>
    /// Base class for classes implementing a specific algorithm for
    /// packing a backpack. The items provided in the constructor are
    /// inserted into a "vault", from which they can later be removed 
    /// and put into a backpack.
    /// </summary>
    public abstract class BackPackingSolverBase : IBackPackingSolver
    {
        protected ItemVault _theVault;
        protected BackPack _theBackPack;

        #region Constructor
        protected BackPackingSolverBase(List<BackPackItem> items, double capacity)
        {
            _theVault = new ItemVault();
            _theBackPack = new BackPack(capacity);

            foreach (var item in items)
            {
                _theVault.AddItem(item);
            }
        } 
        #endregion

        #region Properties
        protected ItemVault TheVault
        {
            get { return _theVault; }
        }

        protected BackPack TheBackPack
        {
            get { return _theBackPack; }
        } 
        #endregion

        /// <summary>
        /// Solves the backpacking problem, and prints out information
        /// about the solution.
        /// </summary>
        public void Run()
        {
            Solve(TheBackPack.WeightCapacityLeft);
            TheBackPack.PrintContent();
            Console.WriteLine();
            TheVault.PrintContent();
        }

        /// <summary>
        /// Override this method to implement a specific algorithm
        /// for backpacking.
        /// </summary>
        public abstract void Solve(double capacityLeft);
    }
}