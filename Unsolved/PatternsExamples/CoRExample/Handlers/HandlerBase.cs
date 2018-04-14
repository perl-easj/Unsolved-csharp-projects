using System;
using CoRExample.Helpers;

namespace CoRExample.Handlers
{
    public abstract class HandlerBase : IHandler
    {
        private IHandler _nextHandler;

        protected HandlerBase(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(Request req)
        {
            if (CanHandle(req))
            {
                HandleRequest(req);
            }
            else if (_nextHandler != null)
            {
                _nextHandler.Handle(req);
            }
            else
            {
                throw new ArgumentException($"Could not handle request {req}");
            }
        }

        public abstract bool CanHandle(Request req);
        protected abstract void HandleRequest(Request req);
    }
}