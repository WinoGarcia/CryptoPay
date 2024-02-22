using System;
using System.Net;
using CryptoPay.Requests;
using CryptoPay.Types;
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
                Assets.TON.ToString(),
                0.5,
                Guid.NewGuid().ToString(),
                disableSendNotification: true)
        );

        this.Add(
            default,
            default,
            new TransferRequest(
                CryptoPayTestHelper.UserId,
                Assets.TON.ToString(),
                0.5,
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                false)
        );

        this.Add(
            default,
            default,
            new TransferRequest(
                CryptoPayTestHelper.UserId,
                Assets.BNB.ToString(),
                0.0123,
                Guid.NewGuid().ToString(),
                disableSendNotification: false)
        );

        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "AMOUNT_TOO_BIG"),
            new TransferRequest(
                CryptoPayTestHelper.UserId,
                Assets.BTC.ToString(),
                1000,
                Guid.NewGuid().ToString())
        );
        this.Add(
            HttpStatusCode.InternalServerError,
            new Error(500, "APP_ERROR"),
            new TransferRequest(
                CryptoPayTestHelper.UserId,
                Assets.Unknown.ToString(),
                10,
                Guid.NewGuid().ToString())
        );
    }
}