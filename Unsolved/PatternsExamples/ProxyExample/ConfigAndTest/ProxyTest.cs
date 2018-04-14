using ProxyExample.Helpers;
using ProxyExample.Proxies;
using ProxyExample.Subjects;

namespace ProxyExample.ConfigAndTest
{
    public class ProxyTest
    {
        public static void Run()
        {
            Context aContext = new Context();
            Client aClient = new Client();
            ISubject iSub = Configurator.Configure(ProxyType.Remote);

            aClient.UseSubject(iSub, aContext);
        }
    }
}