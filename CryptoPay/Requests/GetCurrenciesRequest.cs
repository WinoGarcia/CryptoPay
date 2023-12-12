using System.Collections.Generic;
using CryptoPay.Requests.Base;
using CryptoPay.Types;

namespace CryptoPay.Requests;

/// <summary>
///     Use this class to get list of <see cref="Currency"/> request.
/// </summary>
internal sealed class GetCurrenciesRequest : ParameterlessRequest<List<Currency>>
{
    /// <summary>
    ///     Initializes a new request to get list of <see cref="Currency"/>
    /// </summary>
    public GetCurrenciesRequest()
        : base("getCurrencies") {}
}