using CryptoPay.Requests;
using CryptoPay.Types;
using System.Net;
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
                5.105,
                asset: "TON")
        );
        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                1.105,
                CurrencyTypes.fiat,
                fiat: "USD")
        );
        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                5.105,
                asset: "TON",
                description: "description",
                hiddenMessage: "hiddenMessage",
                paidBtnName: PaidButtonNames.callback,
                paidBtnUrl: "https://t.me/paidBtnUrl",
                payload: "payload",
                allowComments: false,
                allowAnonymous: false,
                expiresIn: 1800)
        );
        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                2.35,
                CurrencyTypes.fiat,
                default,
                "EUR",
                default,
                "description",
                "hiddenMessage",
                PaidButtonNames.callback,
                "https://t.me/paidBtnUrl",
                "payload",
                true,
                false,
                360,
                default)
        );

        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                0.0234,
                CurrencyTypes.crypto,
                "BNB",
                default,
                default,
                "description",
                "hiddenMessage",
                PaidButtonNames.callback,
                "https://t.me/paidBtnUrl",
                "payload",
                true,
                false,
                360,
                default)
        );

        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                1.23,
                CurrencyTypes.fiat,
                default,
                "EUR",
                new[] { "TON", "USDT" },
                "description",
                "hiddenMessage")
        );

        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                amount: 1.23,
                currencyType: CurrencyTypes.crypto,
                asset: "USDT",
                swapTo: "TON")
        );

        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "PAID_BTN_URL_REQUIRED"),
            new CreateInvoiceRequest(
                0.105,
                asset: "TON",
                paidBtnName: PaidButtonNames.callback)
        );
        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "UNSUPPORTED_ASSET"),
            new CreateInvoiceRequest(
                0.123,
                asset: "FFF",
                paidBtnName: PaidButtonNames.callback)
        );
    }
}