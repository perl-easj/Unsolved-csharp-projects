using System;
using ProxyExample.Helpers;
using ProxyExample.Subjects;

namespace ProxyExample.Proxies
{
    public class SubjectProxyProtective : ISubject
    {
        private ISubject _subject;

        public SubjectProxyProtective(ISubject subject)
        {
            _subject = subject;
        }

        public int Calculate(Context c)
        {
            if (c.SubjectAccessManager.CheckCredentials(c.UserCredentials))
            {
                return _subject.Calculate(c);
            }
            else
            {
                throw new ArgumentException();  //..or other handling
            }
        }
    }
}