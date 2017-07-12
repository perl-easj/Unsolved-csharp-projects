using System.Collections.Generic;
using BackPacking.Item;

namespace BackPacking.Algorithms
{
    /// <summary>
    /// This class contains a very naive solver implementation
    /// </summary>
    public class BackPackingSolverStupid : BackPackingSolverBase
    {
        public BackPackingSolverStupid(List<BackPackItem> items, double capacity) 
            : base(items, capacity)
        {
        }

        /// <summary>
        /// Naive solver implementation (but it's recursive!)
        /// </summary>
        public override void Solve(double capacityLeft)
        {
            // Keep adding the first element from the vault, until
            // the first element cannot fit into the backpack...
            if (TheVault.Items[0].Weight <= capacityLeft)
            {
                BackPackItem item = TheVault.RemoveItem(TheVault.Items[0].Description);
                TheBackPack.AddItem(item);
                Solve(TheBackPack.WeightCapacityLeft);
            }
        }
    }
}