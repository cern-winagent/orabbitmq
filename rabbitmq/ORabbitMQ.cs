using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using System.Text;

using plugin;
using System;

namespace rabbitmq
{
    [PluginAttribute(PluginName = "RabbitMQ")]
    public class ORabbitMQ : IOutputPlugin
    {
        public void Execute(string jsonData, JObject set)
        {
            try
            {
                var settings = set.ToObject<Settings.RabbitMQ>();

                var factory = new ConnectionFactory()
                {
                    HostName = settings.HostName,
                    VirtualHost = settings.VirtualHost,
                    UserName = settings.UserName,
                    Password = settings.Password
                };

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.ExchangeDeclare(exchange: settings.ExchangeName, 
                                                type: settings.ExchangeType);

                        channel.QueueDeclare(queue: settings.QueueName,
                                             durable: true,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                        channel.QueueBind(queue: settings.QueueName,
                                          exchange: settings.ExchangeName,
                                          routingKey: settings.RoutingKey ?? settings.QueueName);

                        var correlationId = Guid.NewGuid().ToString();
                        var properties = channel.CreateBasicProperties();
                        properties.CorrelationId = correlationId;
                        properties.Persistent = true;

                        var body = Encoding.UTF8.GetBytes(jsonData);

                        channel.BasicPublish(exchange: settings.ExchangeName,
                                             routingKey: settings.RoutingKey ?? settings.QueueName,
                                             basicProperties: properties,
                                             body: body);
                    }
                }
            }
            catch(Newtonsoft.Json.JsonReaderException jre)
            {
                throw new Exceptions.UnexpectedSettingValueException("RabbitMQ: Unexpected setting value", jre);
            }
            catch(Newtonsoft.Json.JsonSerializationException jse)
            {
                throw new Exceptions.RequiredSettingNotFound("RabbitMQ: Could not find a required setting", jse);
            }

        }
    }
}