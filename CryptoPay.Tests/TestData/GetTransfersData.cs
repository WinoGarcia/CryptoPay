using CryptoPay.Requests;
using CryptoPay.Types;
using System;
using System.Net;
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
                "USDT",
                1.5,
                Guid.NewGuid().ToString(),
                disableSendNotification: true)
        );
    }
}