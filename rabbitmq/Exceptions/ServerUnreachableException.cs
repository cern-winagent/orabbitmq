using System;
using System.ComponentModel;

namespace rabbitmq.Exceptions
{
    class ServerUnreachableException : WarningException
    {
        public ServerUnreachableException(string message, Exception inner) : base(message, inner)
        {
            Data["continue"] = true;
        }
    }
}
