using CryptoPay.Requests.Base;
using CryptoPay.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Requests;

/// <summary>
///     A simple method for testing your bot's auth token. Requires no parameters. Returns basic information
///     about the bot in form of a <see cref="CryptoPayApplication" /> object.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetMeRequest : ParameterlessRequest<CryptoPayApplication>
{
    /// <summary>
    ///     Initializes a new request to get a <see cref="CryptoPayApplication"/>
    /// </summary>
    public GetMeRequest()
        : base("getMe") {}
}