namespace TestApiRest.Model
{
    using System.Runtime.Serialization;

    public enum GrantTypes
    {
        [EnumMember(Value = "client_credentials")]
        ClientCredentials
    }
}