using Newtonsoft.Json;

namespace rabbitmq.Settings
{
    class Plugin
    {
        [JsonProperty(PropertyName = "hostname")]
        public string HostName { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "queue")]
        public string Queue { get; set; }
    }
}
