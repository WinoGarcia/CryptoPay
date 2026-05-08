![CryptoPay](/header.png)
[![package](https://img.shields.io/nuget/vpre/CryptoPay.svg?label=CryptoPay%20Package&style=flat-square)](https://www.nuget.org/packages/CryptoPay)
[![NuGet downloads](https://img.shields.io/nuget/dt/CryptoPay.svg?label=Downloads&style=flat-square&color=orange)](https://www.nuget.org/packages/CryptoPay)
[![Bot API Version](https://img.shields.io/badge/CryptoPay%20API-1.5.1%20(June%2016,%202025)-f36caf.svg?style=flat-square)](https://help.send.tg/en/articles/10279948-crypto-pay-api)
[![documentations](https://img.shields.io/badge/Documentations-Book-Green.svg?style=flat-square)](https://help.send.tg/en/articles/10279948-crypto-pay-api)
# .NET Client for CryptoPay by [@CryptoBot](https://t.me/CryptoBot)

**[Crypto Pay](https://t.me/CryptoBot/?start=pay)** is a payment system based on [@CryptoBot](https://t.me/CryptoBot), which allows you to accept payments in cryptocurrency using the API.

This **.NET** library help you to work with **Crypto Pay** via [Crypto Pay API](https://help.send.tg/en/articles/10279948-crypto-pay-api).

## Install

Use the [nuget package](https://www.nuget.org/packages/CryptoPay/).

## Usage

### API

First, you need to create your application and get an API token. Open [@CryptoBot](https://t.me/CryptoBot?start=pay) or [@CryptoTestnetBot](https://t.me/CryptoTestnetBot?start=pay) (for testnet), send a command `/pay` to create a new app and get API Token.

Don't forget to configure the `ApiUrl` and your `CryptoPayApiToken`:

```csharp
builder.Services.AddHttpClient<ICryptoPayClient, CryptoPayClient>(client =>
{
  client.BaseAddress = new Uri("https://pay.crypt.bot/");
  client.DefaultRequestHeaders.Add("Crypto-Pay-API-Token", "token");
});
```

Next step: try to call a simple `GetMeAsync(...)` method to check that everything is working well:

```csharp
var application = await cryptoPayClient.GetMeAsync(cancellationToken);
```

Net     | Bot                                                          | Hostname
------- |--------------------------------------------------------------|------------------------
mainnet | [@CryptoBot](https://t.me/CryptoBot?start=pay)               | `https://pay.crypt.bot/`
testnet | [@CryptoTestnetBot](https://t.me/CryptoTestnetBot?start=pay) | `https://testnet-pay.crypt.bot/`

> All queries to the Crypto Pay API must be sent over **HTTPS**

You can find all available methods in the [documentation](https://help.send.tg/en/articles/10279948-crypto-pay-api).

Also, you can create invoice with supported [assets](#Assets) and [paid button names](#Paid-Button-Names):

```csharp
var invoice = await cryptoPayClient.CreateInvoiceAsync(
    Assets.BNB,
    1.505,
    description: "kitten",
    paid_btn_name: PaidButtonNames.viewItem,
    paid_btn_url: "https://placekitten.com/150",
    cancellationToken: cancellationToken);
```

### Webhooks

Use Webhooks to get updates for the app.

If you'd like to make sure that the Webhook request comes from Crypto Pay, we recommend using a secret path in the URL, e.g. `https://www.example.com/<secret>`.

> Webhooks will send may at least one time

Example endpoint. You should use `CryptoPayHelper.CheckSignature(...)` to check `signature` from `crypto-pay-api-signature`
```csharp
[HttpPost]
public async Task<IActionResult> PostAsync(CancellationToken cancellationToken = default)
{
    var updateBodyBytes = new byte[this.HttpContext.Request.ContentLength!.Value];
    await this.HttpContext.Request.Body.ReadExactlyAsync(updateBodyBytes, cancellationToken);

    var update = JsonSerializer.Deserialize<Update>(updateBodyBytes, new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
    });

    if (update is not null &&
        update.UpdateType == UpdateTypes.invoice_paid &&
        this.HttpContext.Request.Headers.TryGetValue("crypto-pay-api-signature", out var signature) &&
        CryptoPayHelper.CheckSignature(signature, cryptoPayApiToken, updateBodyBytes))
    {
        // Here your processing of successful payment
        return this.Ok();
    }

    return this.BadRequest();
}
```

Explore all available methods from the [documentation](https://help.send.tg/en/articles/10279948-crypto-pay-api).