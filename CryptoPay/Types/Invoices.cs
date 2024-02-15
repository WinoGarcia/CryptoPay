using System.Collections.Generic;

namespace CryptoPay.Types;

/// <summary>
/// List of <see cref="Invoice"/>. You can get invoices use <see cref="CryptoPay.CryptoPayExtensions.GetInvoicesAsync"/>
/// </summary>
public sealed class Invoices
{
    /// <summary>
    /// List of <see cref="Invoice"/>.
    /// </summary>

    public List<Invoice> Items { get; set; }
}