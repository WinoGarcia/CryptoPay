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
                asset: Assets.TON,
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
                    currencyType: CurrencyTypes.fiat,
                    asset: default,
                    fiat: Assets.EUR,
                    acceptedAssets: default,
                    description: "description",
                    hiddenMessage: "hiddenMessage",
                    paidBtnName: PaidButtonNames.callback,
                    paidBtnUrl: "https://t.me/paidBtnUrl",
                    payload: "payload",
                    allowComments: true,
                    allowAnonymous: false,
                    expiresIn: 360)
        );
        
        this.Add(
            default,
            default,
            new CreateInvoiceRequest(
                0.0234,
                currencyType: CurrencyTypes.crypto,
                asset: Assets.BNB,
                fiat: default,
                acceptedAssets: default,
                description: "description",
                hiddenMessage: "hiddenMessage",
                paidBtnName: PaidButtonNames.callback,
                paidBtnUrl: "https://t.me/paidBtnUrl",
                payload: "payload",
                allowComments: true,
                allowAnonymous: false,
                expiresIn: 360)
        ); 

        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "PAID_BTN_URL_REQUIRED"),
            new CreateInvoiceRequest(
                0.105,
                asset: Assets.TON,
                paidBtnName: PaidButtonNames.callback)
        );
    }
}