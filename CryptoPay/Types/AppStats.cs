using System;

namespace CryptoPay.Types;

/// <summary>
/// application statistics.
/// </summary>
public sealed record AppStats
{
    /// <summary>
    /// Total volume of paid invoices in USD.
    /// </summary>
    public decimal Volume { get; set; }

    /// <summary>
    /// Conversion of all created invoices.
    /// </summary>
    public decimal Conversion { get; set; }

    /// <summary>
    /// The unique number of users who have paid the invoice.
    /// </summary>
    public int UniqueUsersCount { get; set; }

    /// <summary>
    /// Total created invoice count.
    /// </summary>
    public int CreatedInvoiceCount { get; set; }

    /// <summary>
    /// Total paid invoice count.
    /// </summary>
    public int PaidInvoiceCount { get; set; }

    /// <summary>
    /// The date on which the statistics calculation was started.
    /// </summary>
    public DateTime StartAt { get; set; }

    /// <summary>
    /// The date on which the statistics calculation was ended.
    /// </summary>
    public DateTime EndAt { get; set; }
}