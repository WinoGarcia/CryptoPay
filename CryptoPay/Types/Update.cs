using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
/// All requests from Crypto Pay API has this JSON object.
/// <para/>
/// You can verify use method <see cref="CryptoPayHelper.CheckSignature" /> the received update and the integrity of the received data by comparing the header parameter crypto-pay-api-signature
/// and the hexadecimal representation of HMAC-SHA-256 signature used to sign the entire request body (unparsed JSON string)
/// with a secret key that is SHA256 hash of your app's token.
/// </summary>
public sealed class Update
{
    /// <summary>
    /// Non-unique update ID.
    /// </summary>
    [JsonRequired]
    public long UpdateId { get; set; }

    /// <summary>
    /// Webhook update type.Supported update types:
    /// <see cref="UpdateTypes.invoice_paid" /> – the update sent after an invoice is paid.
    /// </summary>
    [JsonRequired]
    public UpdateTypes UpdateType { get; set; }

    /// <summary>
    /// Date the request was sent in ISO 8601 format.
    /// </summary>
    [JsonRequired]
    public DateTime RequestDate { get; set; }

    /// <summary>
    /// Payload of the update.
    /// </summary>
    public Invoice Payload { get; set; }

    /// <summary>
    /// Serialize object to string.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => JsonSerializer.Serialize(this);
}