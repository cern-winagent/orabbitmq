using System;
using System.ComponentModel;

namespace rabbitmq.Exceptions
{
    class UnexpectedSettingValueException : WarningException
    {
        public UnexpectedSettingValueException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
