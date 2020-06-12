namespace TestApiRest.Model
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum GrantTypes
    {
        [EnumMember(Value = "client_credentials")]
        ClientCredentials
    }
}