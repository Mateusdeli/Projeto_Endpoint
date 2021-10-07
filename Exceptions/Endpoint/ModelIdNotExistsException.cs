using System;

namespace Exceptions.EndPoint
{
    public class ModelIdNotExistsException : Exception
    {
        public ModelIdNotExistsException()
        { }

        public ModelIdNotExistsException(string message)
            : base(message)
        { }
    }
}