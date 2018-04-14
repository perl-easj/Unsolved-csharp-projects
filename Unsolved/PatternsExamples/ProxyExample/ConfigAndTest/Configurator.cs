using ProxyExample.Proxies;
using ProxyExample.Subjects;

namespace ProxyExample.ConfigAndTest
{
    public class Configurator
    {
        public static ISubject Configure(ProxyType pt)
        {
            switch (pt)
            {
                case ProxyType.Simple:
                    return new SubjectProxySimple(new Subject());
                case ProxyType.Smart:
                    return new SubjectProxySmart(new Subject());
                case ProxyType.Remote:
                    return new SubjectProxyRemote(new Subject());
                case ProxyType.Protective:
                    return new SubjectProxyProtective(new Subject());
                case ProxyType.Virtual:
                    return new SubjectProxyVirtual();
                default:
                    return null;

            }
        }
    }
}