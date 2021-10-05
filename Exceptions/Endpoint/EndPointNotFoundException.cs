using System;

namespace Exceptions.EndPoint
{
    public class EndPointNotFoundException : Exception
    {
        public EndPointNotFoundException()
        { }

        public EndPointNotFoundException(string message)
            : base(message)
        { }
    }
}