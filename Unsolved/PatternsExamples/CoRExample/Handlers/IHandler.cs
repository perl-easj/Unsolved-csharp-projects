using CoRExample.Helpers;

namespace CoRExample.Handlers
{
    public interface IHandler
    {
        bool CanHandle(Request req);
        void Handle(Request req);
    }
}