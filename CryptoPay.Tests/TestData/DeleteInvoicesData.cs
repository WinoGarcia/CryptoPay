using System.Net;
using CryptoPay.Requests;
using CryptoPay.Types;
using Xunit;

namespace CryptoPay.Tests.TestData;

public sealed class DeleteInvoicesData : TheoryData<HttpStatusCode, Error?, CreateInvoiceRequest>
{
    public DeleteInvoicesData()
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
                allowAnonymous: false, expiresIn: 1800)
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
    }
}