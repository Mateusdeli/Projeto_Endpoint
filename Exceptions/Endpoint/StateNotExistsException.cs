using System;

namespace Exceptions.EndPoint
{
    public class StateNotExistsException : Exception
    {
        public StateNotExistsException()
        { }

        public StateNotExistsException(string message)
            : base(message)
        { }
    }
}