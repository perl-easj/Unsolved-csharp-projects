using ProxyExample.Helpers;
using ProxyExample.Subjects;

namespace ProxyExample.Proxies
{
    public class SubjectProxyVirtual : ISubject
    {
        private ISubject _subject;

        public SubjectProxyVirtual() // NB!
        {
            _subject = null;
        }

        public int Calculate(Context c)
        {
            InitSubject();
            return _subject.Calculate(c);
        }

        private void InitSubject()
        {
            _subject = _subject ?? new Subject();
        }
    }
}