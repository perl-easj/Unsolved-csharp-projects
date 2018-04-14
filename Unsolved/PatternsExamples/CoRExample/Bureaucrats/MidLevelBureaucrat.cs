using System.Collections.Generic;
using CoRExample.Handlers;
using CoRExample.Helpers;

namespace CoRExample.Bureaucrats
{
    public class MidLevelBureaucrat : Bureaucrat
    {
        public MidLevelBureaucrat(string name, IHandler nextHandler)
            : base(name, new List<FormType>
            {
                FormType.B113, FormType.B096
            }, nextHandler)
        {
        }

        protected override void SignForm(Form aForm)
        {
            base.SignForm(aForm);
            aForm.SignedBy = aForm.SignedBy + " (Mid Level Bureaucrat)";
        }
    }
}