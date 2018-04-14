using System.Collections.Generic;
using CoRExample.Handlers;
using CoRExample.Helpers;

namespace CoRExample.Bureaucrats
{
    public class SeniorBureaucrat : Bureaucrat
    {
        public SeniorBureaucrat(string name, IHandler nextHandler)
            : base(name, new List<FormType>
            {
                FormType.J072, FormType.J880
            }, nextHandler)
        {
        }

        protected override void SignForm(Form aForm)
        {
            base.SignForm(aForm);
            aForm.SignedBy = aForm.SignedBy + " (Senior Bureaucrat)";
        }
    }
}