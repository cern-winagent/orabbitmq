using System;

namespace rabbitmq.Exceptions
{
    class SettingNotFoundException : Exception
    {
        public SettingNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
