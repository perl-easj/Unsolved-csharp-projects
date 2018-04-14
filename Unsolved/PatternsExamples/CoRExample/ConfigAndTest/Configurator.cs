using CoRExample.Bureaucrats;
using CoRExample.Handlers;

namespace CoRExample.Helpers
{
    public class Configurator
    {
        public void Run()
        {
            IHandler handler = Configure();
            Request req = new Request(new Form(FormType.A012), "me@mail.dk");
            handler.Handle(req);
        }

        public IHandler Configure()
        {
            IHandler handler = new TopBureaucrat("H.R. Giger");
            handler = new DirectorBureaucrat("G. Helger", handler);
            handler = new SeniorBureaucrat("E. Frieger", handler);
            handler = new MidLevelBureaucrat("C. Dreger", handler);
            handler = new JuniorBureaucrat("A. Berger", handler);

            return handler;
        }
    }
}