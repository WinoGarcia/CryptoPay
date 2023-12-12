using System.Net;
using CryptoPay.Types;
using Xunit;

namespace CryptoPay.Tests.TestData;

public class CryptoPayClientData : TheoryData<HttpStatusCode?, Error?, string, string>
{
    public CryptoPayClientData()
    {
        this.Add(default, default, string.Empty, string.Empty);
        this.Add(default, default, CryptoPayTestHelper.Token, CryptoPayTestHelper.ApiUrl);
        this.Add(
            HttpStatusCode.Unauthorized,
            new Error(401, "UNAUTHORIZED"),
            CryptoPayTestHelper.Token + "abc",
            CryptoPayTestHelper.ApiUrl);
        this.Add(
            HttpStatusCode.MethodNotAllowed,
            new Error(405, "METHOD_NOT_FOUND"),
            CryptoPayTestHelper.Token,
            CryptoPayTestHelper.ApiUrl + "abc");
    }
}