using System.Collections.Generic;
using CoRExample.Handlers;
using CoRExample.Helpers;

namespace CoRExample.Bureaucrats
{
    public class DirectorBureaucrat : Bureaucrat
    {
        public DirectorBureaucrat(string name, IHandler nextHandler)
            : base(name, new List<FormType>
            {
                FormType.S022, FormType.T505, FormType.T678, FormType.T902
            }, nextHandler)
        {
        }

        protected override void SignForm(Form aForm)
        {
            base.SignForm(aForm);
            aForm.SignedBy = aForm.SignedBy + " (Director Bureaucrat)";
        }
    }
}