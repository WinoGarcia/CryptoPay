using CryptoPay.Requests;
using CryptoPay.Types;
using System.Net;
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
                "USDT",
                0.1m,
                default,
                default));

        this.Add(
            default,
            default,
            new CreateCheckRequest(
                "USDT",
                0.1m,
                CryptoPayTestHelper.UserId,
                default)
        );

        this.Add(
            default,
            default,
            new CreateCheckRequest(
                "USDT",
                0.1m,
                default,
                CryptoPayTestHelper.UserUsername)
        );

        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "AMOUNT_TOO_SMALL"),
            new CreateCheckRequest(
                "USDT",
                0.001m,
                default,
                default));

        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "NOT_ENOUGH_COINS"),
            new CreateCheckRequest(
                "TON",
                100.2345m,
                default,
                default));

        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "ASSET_INVALID"),
            new CreateCheckRequest(
                "FFF",
                0.0123m,
                default,
                default));
    }
}