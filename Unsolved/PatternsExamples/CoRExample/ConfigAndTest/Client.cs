using CoRExample.Handlers;

namespace CoRExample.Helpers
{
    public class Client
    {
        private IHandler _handler;

        public Client(IHandler handler)
        {
            _handler = handler;
        }

        public void SubmitRequest(Request req)
        {
            _handler.Handle(req);
        }
    }
}