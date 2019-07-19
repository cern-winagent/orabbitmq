using System;

namespace rabbitmq.Exceptions
{
    class UnexpectedSettingValueException : Exception
    {
        public UnexpectedSettingValueException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
