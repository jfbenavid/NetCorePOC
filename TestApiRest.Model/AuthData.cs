namespace TestApiRest.Model
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class AuthData
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        [JsonProperty("audience")]
        public string Audience { get; set; }

        [JsonProperty("grant_type")]
        public GrantTypes GrantType { get; set; }
    }
}