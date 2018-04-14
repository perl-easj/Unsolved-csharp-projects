using System.Collections.Generic;
using CoRExample.Handlers;
using CoRExample.Helpers;

namespace CoRExample.Bureaucrats
{
    public abstract class Bureaucrat : HandlerBase
    {
        private string _name;
        private List<FormType> _formsICanHandle;

        protected Bureaucrat(string name, List<FormType> formsICanHandle, IHandler nextHandler) : base(nextHandler)
        {
            _formsICanHandle = formsICanHandle;
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public override bool CanHandle(Request req)
        {
            return _formsICanHandle.Contains(req.TypeOfForm);
        }

        protected override void HandleRequest(Request req)
        {
            Form aForm = req.TheForm;
            aForm.Approved = true;
            SignForm(aForm);

            EmailCentral.Instance.Send(req.RespondTo, aForm);
        }

        protected virtual void SignForm(Form aForm)
        {
            aForm.SignedBy = Name;
        }
    }
}