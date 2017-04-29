namespace MVVMStarter.Validators.App
{
    public class ValidationOutcome
    {
        public string Message { get; }

        public ValidationOutcome(string message)
        {
            Message = message;
        }
    }
}
