using System.Collections.Generic;
using CryptoPay.Requests.Base;
using CryptoPay.Types;

namespace CryptoPay.Requests;

/// <summary>
///     Use this class to create <see cref="Balance"/> request.
/// </summary>
internal sealed class GetBalanceRequest : ParameterlessRequest<List<Balance>>
{
    /// <summary>
    ///     Initializes a new request to get <see cref="Balance"/>.
    /// </summary>
    public GetBalanceRequest()
        : base("getBalance") {}
}