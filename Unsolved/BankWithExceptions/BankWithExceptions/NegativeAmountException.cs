using System;

namespace BankWithExceptions
{
    /// <summary>
    /// This exception is to be thrown in case it is 
    /// attempted to withdraw or deposit a negative amount
    /// </summary>
    class NegativeAmountException : Exception
    {
        public NegativeAmountException(double amount)
            : base($"bla bla bla {amount}")
        {
        }
    }
}
