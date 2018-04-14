using ProxyExample.Helpers;
using ProxyExample.Subjects;

namespace ProxyExample.Proxies
{
    public class SubjectProxySmart : ISubject
    {
        private ISubject _subject;
        public int CallsToCalculate { get; private set; }

        public SubjectProxySmart(ISubject subject)
        {
            _subject = subject;
            CallsToCalculate = 0;
        }

        public int Calculate(Context c)
        {
            CallsToCalculate++;
            return _subject.Calculate(c);
        }
    }
}