using System.Collections.Generic;
using CoRExample.Helpers;

namespace CoRExample.Bureaucrats
{
    public class TopBureaucrat : Bureaucrat
    {
        public TopBureaucrat(string name)
            : base(name, new List<FormType>
            {
                FormType.Z044, FormType.Z096
            }, null)
        {
        }

        protected override void SignForm(Form aForm)
        {
            base.SignForm(aForm);
            aForm.SignedBy = aForm.SignedBy + " (Top Bureaucrat)";
        }
    }
}