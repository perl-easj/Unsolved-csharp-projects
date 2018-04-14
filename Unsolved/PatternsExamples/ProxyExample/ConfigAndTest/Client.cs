using ProxyExample.Helpers;
using ProxyExample.Subjects;

namespace ProxyExample.ConfigAndTest
{
    public class Client
    {
        public void UseSubject(ISubject subject, Context c)
        {
            int result = subject.Calculate(c);
        }
    }
}