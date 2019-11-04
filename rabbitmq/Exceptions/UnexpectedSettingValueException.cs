using System;
using System.ComponentModel;

namespace rabbitmq.Exceptions
{
    class UnexpectedSettingValueException : Exception
    {
        public UnexpectedSettingValueException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
