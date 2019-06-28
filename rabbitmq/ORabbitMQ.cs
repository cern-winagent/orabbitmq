using plugin;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using System.Text;

namespace rabbitmq
{
    [PluginAttribute(PluginName = "RabbitMQ")]
    public class ORabbitMQ : IOutputPlugin
    {
        public void Execute(string jsonData, JObject set)
        {
            var settings = set.ToObject<Settings.Plugin>();

            var factory = new ConnectionFactory() {
                HostName = settings.HostName,
                UserName = settings.UserName,
                Password = settings.Password };
            using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: settings.Queue,
                                            durable: false,
                                            exclusive: false,
                                            autoDelete: false,
                                            arguments: null);

                    //string message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes(jsonData);

                    channel.BasicPublish(exchange: "",
                                            routingKey: settings.Queue,
                                            basicProperties: null,
                                            body: body);
                }
        }
    }
}