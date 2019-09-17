using System.ComponentModel;

namespace rabbitmq.Exceptions
{
    class ServerUnreachableException : WarningException
    {
        public ServerUnreachableException(string message) : base(message)
        {

        }
    }
}
