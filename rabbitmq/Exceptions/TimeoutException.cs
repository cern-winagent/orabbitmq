using System.ComponentModel;

namespace rabbitmq.Exceptions
{
    class TimeoutException : WarningException
    {
        public TimeoutException(string message) : base(message)
        {

        }
    }
}
