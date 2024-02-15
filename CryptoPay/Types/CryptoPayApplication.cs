using System.Text.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
/// Basic information about an application.
/// </summary>
public sealed class CryptoPayApplication
{
    /// <summary>
    /// Your application Id.
    /// </summary>
    [JsonRequired]
    public long AppId { get; set; }

    /// <summary>
    /// Your application Name.
    /// </summary>
    [JsonRequired]
    public string Name { get; set; }

    /// <summary>
    /// Payment processing bot username, main or test bot username.
    /// </summary>
    [JsonRequired]
    public string PaymentProcessingBotUsername { get; set; }
}