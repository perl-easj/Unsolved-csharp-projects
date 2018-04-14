using System.Collections.Generic;
using ProxyExample.Helpers;
using ProxyExample.Subjects;

namespace ProxyExample.Proxies
{
    public class SubjectProxyRemote : ISubject
    {
        private ISubject _subject;
        private Dictionary<Context, int> _cache;

        public SubjectProxyRemote(ISubject subject)
        {
            _cache = new Dictionary<Context, int>();
            _subject = subject;
        }

        public int Calculate(Context c)
        {
            if (!_cache.ContainsKey(c))
            {
                int result = _subject.Calculate(c);
                _cache.Add(c, result);
                return result;
            }

            return _cache[c];
        }
    }
}