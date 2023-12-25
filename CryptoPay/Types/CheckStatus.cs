using System.Text.Json.Serialization;

namespace CryptoPay.Types;

#pragma warning disable CS1591

/// <summary>
///     Status of the check.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CheckStatus
{
    active,
    activated
}