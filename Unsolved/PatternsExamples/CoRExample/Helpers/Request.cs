namespace CoRExample.Helpers
{
    public class Request
    {
        private Form _form;
        private string _respondTo;

        public Request(Form form, string respondTo)
        {
            _form = form;
            _respondTo = respondTo;
        }

        public FormType TypeOfForm
        {
            get { return _form.Type; }
        }

        public string RespondTo
        {
            get { return _respondTo; }
        }

        public Form TheForm
        {
            get { return _form; }
        }
    }
}