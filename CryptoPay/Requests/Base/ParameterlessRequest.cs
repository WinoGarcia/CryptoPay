using System.Net.Http;
using CryptoPay.Types;

namespace CryptoPay.Requests.Base;

/// <summary>
///     Represents a request that doesn't require any parameters.
/// </summary>
/// <typeparam name="TResult">Type of response. For example <see cref="Invoice"/></typeparam>
public class ParameterlessRequest<TResult> : RequestBase<TResult>
{
    #region Constructors

    /// <summary>
    ///     Initializes an instance of <see cref="ParameterlessRequest{TResult}" />
    /// </summary>
    /// <param name="methodName">Name of request method.</param>
    protected ParameterlessRequest(string methodName)
        : base(methodName) {}

    /// <summary>
    ///     Initializes an instance of <see cref="ParameterlessRequest{TResult}" />
    /// </summary>
    /// <param name="methodName">Name of request method.</param>
    /// <param name="method">HTTP request method.</param>
    protected ParameterlessRequest(string methodName, HttpMethod method)
        : base(methodName, method) {}

    #endregion
}