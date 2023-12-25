using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
///     Object include list of <see cref="Check"/>.
/// </summary>
public sealed class Checks
{
    #region Constructors

    /// <summary>
    ///     Initializes a new object include list of <see cref="Check"/>.
    /// </summary>
    public Checks()
    {
        this.Items = Enumerable.Empty<Check>();
    }

    #endregion

    #region Public Fields

    /// <summary>
    ///     List of <see cref="Check"/>.
    /// </summary>
    [JsonRequired]
    public IEnumerable<Check> Items { get; set; }
    
    #endregion
}