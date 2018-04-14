using CoRExample.Handlers;
using CoRExample.Helpers;

namespace CoRExample.Bureaucrats
{
    public class Bureaucracy
    {
        private IHandler _handler;

        public Bureaucracy(IHandler handler)
        {
            _handler = handler;
        }

        public void SubmitRequest(Request req)
        {
            _handler.Handle(req);
        }
    }
}