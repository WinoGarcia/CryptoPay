using System.Net;
using CryptoPay.Requests;
using CryptoPay.Types;
using Xunit;

namespace CryptoPay.Tests.TestData;

/// <summary>
/// For this test, you must have test coins.
/// </summary>
public sealed class CreateCheckData : TheoryData<HttpStatusCode, Error?, CreateCheckRequest>
{
    public CreateCheckData()
    {
        this.Add(
            default,
            default,
            new CreateCheckRequest(
                Assets.BNB.ToString(),
                0.0123)
        );
        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "NOT_ENOUGH_COINS"),
            new CreateCheckRequest(
                Assets.TON.ToString(),
                100.2345)
        );
        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "ASSET_INVALID"),
            new CreateCheckRequest(
                "FFF",
                0.0123)
        );
    }
}