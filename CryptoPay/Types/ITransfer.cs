namespace CryptoPay.Types;

/// <summary>
/// Transfer. You can get invoice use <see cref="CryptoPay.CryptoPayExtensions.TransferAsync" />
/// </summary>
public interface ITransfer
{
    /// <summary>
    /// Telegram user ID the transfer was sent to.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Currency code. Currently, can be <see cref="Assets"/>.
    /// </summary>
    public Assets Asset { get; set; }

    /// <summary>
    /// Amount of the transfer.
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// Optional. Comment for this transfer.
    /// </summary>
    public string Comment { get; set; }
}