using System;

namespace MVVMStarter.Validators.App
{
    public class ValidationException : ArgumentException
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}
