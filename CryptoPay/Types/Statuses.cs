// ReSharper disable InconsistentNaming

using System.Text.Json.Serialization;

#pragma warning disable CS1591
namespace CryptoPay.Types;

/// <summary>
/// Status of invoices to be returned.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Statuses
{
    active,
    paid,
    expired
}