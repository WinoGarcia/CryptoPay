using System.Net;
using CryptoPay.Requests;
using CryptoPay.Types;
using Xunit;

namespace CryptoPay.Tests.TestData;

public class CreateInvoiceData : TheoryData<HttpStatusCode, Error?, CreateInvoiceRequest>
{
    public CreateInvoiceData()
    {
        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                Assets.TON,
                5.105,
                "description",
                "hiddenMessage",
                PaidButtonNames.callback,
                "https://t.me/paidBtnUrl",
                "payload",
                false,
                false,
                1800)
        );

        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "PAID_BTN_URL_REQUIRED"),
            new CreateInvoiceRequest(
                Assets.TON,
                0.105,
                paidBtnName: PaidButtonNames.callback)
        );
    }
}