using System;
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
                5.105,
                asset: Enum.GetName(Assets.TON))
        );
        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                1.105,
                CurrencyTypes.fiat,
                fiat: Enum.GetName(Assets.USD))
        );
        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                5.105,
                asset: Enum.GetName(Assets.TON),
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
                Enum.GetName(Assets.EUR),
                default,
                "description",
                "hiddenMessage",
                PaidButtonNames.callback,
                "https://t.me/paidBtnUrl",
                "payload",
                true,
                false,
                360)
        );

        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                0.0234,
                CurrencyTypes.crypto,
                Enum.GetName(Assets.BNB),
                default,
                default,
                "description",
                "hiddenMessage",
                PaidButtonNames.callback,
                "https://t.me/paidBtnUrl",
                "payload",
                true,
                false,
                360)
        );

        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "PAID_BTN_URL_REQUIRED"),
            new CreateInvoiceRequest(
                0.105,
                asset: Enum.GetName(Assets.TON),
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