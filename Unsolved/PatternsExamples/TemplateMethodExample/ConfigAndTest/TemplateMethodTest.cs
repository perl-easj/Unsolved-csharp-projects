namespace TemplateMethodExample.ConfigAndTest
{
    public class TemplateMethodTest
    {
        public static void Run()
        {
            Client c = Configurator.Configure(true);
            c.Run();

            c = Configurator.Configure(false);
            c.Run();
        }
    }
}