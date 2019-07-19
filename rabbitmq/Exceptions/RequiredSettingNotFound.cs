using System;

namespace rabbitmq.Exceptions
{
    class RequiredSettingNotFound : Exception
    {
        public RequiredSettingNotFound(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
