using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
///     Object include list of <see cref="Transfer"/>.
/// </summary>
public sealed class Transfers
{
    #region Constructors

    /// <summary>
    ///     Initializes a new object include list of <see cref="Transfer"/>.
    /// </summary>
    public Transfers()
    {
        this.Items = Enumerable.Empty<Transfer>();
    }

    #endregion

    #region Public Fields

    /// <summary>
    ///     List of <see cref="Transfer"/>.
    /// </summary>
    [JsonRequired]
    public IEnumerable<Transfer> Items { get; set; }

    #endregion
}