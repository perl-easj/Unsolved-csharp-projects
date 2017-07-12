namespace BackPacking.Algorithms
{
    /// <summary>
    /// Minimal interface for classes implementing a 
    /// backpacking solver algorithm
    /// </summary>
    public interface IBackPackingSolver
    {
        /// <summary>
        /// Implement this method to implement a specific algorithm
        /// for backpacking.
        /// </summary>
        void Solve(double capacityLeft);

        /// <summary>
        /// This method should manage pre- and post-solving actions, 
        /// and start the solver algorithm itself.
        /// </summary>
        void Run();
    }
}