using ProxyExample.Helpers;

namespace ProxyExample.Subjects
{
    public class Subject : ISubject
    {
        public int Calculate(Context c)
        {
            // Code for calculation
            return 42;
        }
    }
}