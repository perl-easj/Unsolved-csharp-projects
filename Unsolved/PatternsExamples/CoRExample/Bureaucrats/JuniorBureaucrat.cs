using System.Collections.Generic;
using CoRExample.Handlers;
using CoRExample.Helpers;

namespace CoRExample.Bureaucrats
{
    public class JuniorBureaucrat : Bureaucrat
    {
        public JuniorBureaucrat(string name, IHandler nextHandler)
            : base(name, new List<FormType>
            {
                FormType.A012, FormType.A041, FormType.A767
            }, nextHandler)
        {
        }

        protected override void SignForm(Form aForm)
        {
            base.SignForm(aForm);
            aForm.SignedBy = aForm.SignedBy + " (Junior Bureaucrat)";
        }
    }
}