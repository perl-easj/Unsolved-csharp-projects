using ProxyExample.Helpers;
using ProxyExample.Subjects;

namespace ProxyExample.Proxies
{
    public class SubjectProxySimple : ISubject
    {
        private ISubject _subject;

        public SubjectProxySimple(ISubject subject)
        {
            _subject = subject;
        }

        public int Calculate(Context c)
        {
            return _subject.Calculate(c);
        }
    }
}