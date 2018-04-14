namespace CoRExample.Helpers
{
    public class Form
    {
        private FormType _formType;
        private bool _approved;
        private string _signedBy;

        public Form(FormType formType)
        {
            _formType = formType;
            _approved = false;
            _signedBy = "(not signed)";
        }

        public FormType Type
        {
            get { return _formType; }
        }

        public bool Approved
        {
            get { return _approved; }
            set { _approved = value; }
        }

        public string SignedBy
        {
            get { return _signedBy; }
            set { _signedBy = value; }
        }
    }
}