// ReSharper disable InconsistentNaming

using System.Text.Json.Serialization;

#pragma warning disable CS1591
namespace CryptoPay.Types;

/// <summary>
/// Buttons that will be shown to a user after the invoice is paid.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PaidButtonNames
{
    viewItem,
    openChannel,
    openBot,
    callback
}