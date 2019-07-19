using Newtonsoft.Json;
using System.ComponentModel;

namespace rabbitmq.Settings
{
    class RabbitMQ
    {
        [JsonProperty(PropertyName = "HostName", Required =Required.Always)]
        public string HostName { get; set; }

        [JsonProperty(PropertyName = "UserName", Required = Required.Always)]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "Password", Required = Required.Always)]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "QueueName", Required = Required.Always)]
        public string QueueName { get; set; }

        [JsonProperty(PropertyName = "VirtualHost")]
        public string VirtualHost { get; set; }

        [DefaultValue("winagent")]
        [JsonProperty(PropertyName = "ExchangeName", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ExchangeName { get; set; }

        [DefaultValue("direct")]
        [JsonProperty(PropertyName = "ExchangeType", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ExchangeType { get; set; }

        [JsonProperty(PropertyName = "RoutingKey")]
        public string RoutingKey { get; set; }
    }
}
