using System;
using System.Net;
using CryptoPay.Requests;
using CryptoPay.Types;
using Xunit;

namespace CryptoPay.Tests.TestData;

/// <summary>
/// For this test, you must have test coins.
/// </summary>
public sealed class GetTransfersData : TheoryData<HttpStatusCode, Error?, TransferRequest>
{
    public GetTransfersData()
    {
        this.Add(
            default,
            default,
            new TransferRequest(
                CryptoPayTestHelper.UserId,
                Assets.BNB.ToString(),
                0.0123,
                Guid.NewGuid().ToString(),
                disableSendNotification: true)
        );
    }
}