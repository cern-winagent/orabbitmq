using System;
using System.ComponentModel;

namespace rabbitmq.Exceptions
{
    class TimeoutException : WarningException
    {
        public TimeoutException(string message, Exception inner) : base(message, inner)
        {
            Data["continue"] = true;
        }
    }
}
