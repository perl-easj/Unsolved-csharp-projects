using System;

namespace CoRExample.Helpers
{
    public class EmailCentral
    {
        private static EmailCentral _instance;
        public static EmailCentral Instance
        {
            get { return _instance ?? (_instance = new EmailCentral()); }
        }

        private EmailCentral()
        {
        }

        public void Send(string to, Form aForm)
        {
            Console.WriteLine($"To {to}: Form {aForm.Type} approved. Signed: {aForm.SignedBy}");
        }
    }
}