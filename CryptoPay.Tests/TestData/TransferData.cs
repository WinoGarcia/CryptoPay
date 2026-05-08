using CryptoPay.Requests;
using CryptoPay.Types;
using System;
using System.Net;
using Xunit;

namespace CryptoPay.Tests.TestData;

/// <summary>
/// For this test, you must have test coins.
/// </summary>
public class TransferData : TheoryData<HttpStatusCode, Error?, TransferRequest>
{
    public TransferData()
    {
        this.Add(
            default,
            default,
            new TransferRequest(
                CryptoPayTestHelper.UserId,
                "USDT",
                1.5m,
                Guid.NewGuid().ToString(),
                disableSendNotification: true)
        );

        this.Add(
            default,
            default,
            new TransferRequest(
                CryptoPayTestHelper.UserId,
                "USDT",
                1.5m,
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                false)
        );

        this.Add(
            default,
            default,
            new TransferRequest(
                CryptoPayTestHelper.UserId,
                "TON",
                1.02m,
                Guid.NewGuid().ToString(),
                disableSendNotification: false)
        );

        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "AMOUNT_TOO_BIG"),
            new TransferRequest(
                CryptoPayTestHelper.UserId,
                "BTC",
                1000,
                Guid.NewGuid().ToString())
        );
        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "AMOUNT_INVALID"),
            new TransferRequest(
                CryptoPayTestHelper.UserId,
                "Unknown",
                10,
                Guid.NewGuid().ToString())
        );
    }
}