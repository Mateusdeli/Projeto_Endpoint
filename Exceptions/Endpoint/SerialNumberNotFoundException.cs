using System;

namespace Exceptions.EndPoint
{
    public class SerialNumberNotFoundException : Exception
    {
        public SerialNumberNotFoundException()
        { }

        public SerialNumberNotFoundException(string message)
            : base(message)
        { }
    }
}