using CryptoPay.Types;
using System.Net;
using Xunit;

namespace CryptoPay.Tests.TestData;

public class CryptoPayClientData : TheoryData<HttpStatusCode, Error?, string?, string?>
{
    public CryptoPayClientData()
    {
        this.Add(default, default, default, default);
        this.Add(default, default, CryptoPayTestHelper.Token, CryptoPayTestHelper.ApiUrl);
        this.Add(
            HttpStatusCode.Unauthorized,
            new Error(401, "UNAUTHORIZED"),
            CryptoPayTestHelper.Token + "abc",
            CryptoPayTestHelper.ApiUrl);
        this.Add(
            HttpStatusCode.NotFound,
            default,
            CryptoPayTestHelper.Token,
            CryptoPayTestHelper.ApiUrl + "abc");
    }
}