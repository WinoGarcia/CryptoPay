using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CryptoPay.Exceptions;
using CryptoPay.Requests;
using CryptoPay.Tests.TestData;
using CryptoPay.Types;
using Xunit;

#pragma warning disable CS0618 // Type or member is obsolete

namespace CryptoPay.Tests;

public class AvailableMethodsTests
{
    #region Public Fields

    private readonly CancellationToken cancellationToken = new CancellationTokenSource().Token;

    private readonly ICryptoPayClient cryptoPayClient = new CryptoPayClient(
        CryptoPayTestHelper.Token,
        apiUrl: CryptoPayTestHelper.ApiUrl);

    #endregion

    #region Private Methods

    private static void AssertException(RequestException requestException, HttpStatusCode statusCode, Error error)
    {
        Assert.NotNull(requestException);
        Assert.Equal(statusCode, requestException.HttpStatusCode);

        var errorException = requestException.Error;
        Assert.NotNull(errorException);
        Assert.Equal(error.Code, errorException.Code);
        Assert.Equal(error.Name, errorException.Name);
    }

    #endregion

    /// Enter your own actual values in
    /// <see cref="CryptoPayTestHelper.Token" />
    /// <see cref="CryptoPayTestHelper.ApiUrl" />
    /// <see cref="CryptoPayTestHelper.UserId" />
    /// For test <see cref="TransferTest"/>, you must have test <see cref="Assets.TON"/>> coins in you application wallet.

    #region Tests

    [Theory]
    [ClassData(typeof(CryptoPayClientData))]
    public async Task AuthorizationAndGetMeTest(
        HttpStatusCode statusCode,
        Error error,
        string token,
        string apiUrl)
    {
        try
        {
            var localCryptoPayClient = new CryptoPayClient(token, apiUrl: apiUrl);
            var application = await localCryptoPayClient.GetMeAsync(this.cancellationToken);

            Assert.NotNull(application);
            Assert.NotEmpty(application.Name);
            Assert.NotEmpty(application.PaymentProcessingBotUsername);
            Assert.Equal(localCryptoPayClient.AppId, application.AppId);
        }
        catch (ArgumentNullException argumentNullException)
        {
            Assert.NotNull(argumentNullException);
        }
        catch (RequestException requestException)
        {
            AssertException(requestException, statusCode, error);
        }
    }

    [Theory]
    [ClassData(typeof(CreateInvoiceData))]
    public async Task CreateInvoiceTest(HttpStatusCode statusCode, Error error, CreateInvoiceRequest invoiceRequest)
    {
        try
        {
            var invoice = await this.cryptoPayClient.CreateInvoiceAsync(
                invoiceRequest.Amount,
                invoiceRequest.CurrencyType,
                invoiceRequest.Asset,
                invoiceRequest.Fiat,
                invoiceRequest.AcceptedAssets,
                invoiceRequest.Description,
                invoiceRequest.HiddenMessage,
                invoiceRequest.PaidBtnName,
                invoiceRequest.PaidBtnUrl,
                invoiceRequest.Payload,
                invoiceRequest.AllowComments!.Value,
                invoiceRequest.AllowAnonymous!.Value,
                invoiceRequest.ExpiresIn,
                this.cancellationToken);

            Assert.NotNull(invoice);
            Assert.NotNull(invoice.PayUrl);
            Assert.NotNull(invoice.Hash);
            Assert.Equal(invoiceRequest.Amount, invoice.Amount);
            Assert.Equal(invoiceRequest.CurrencyType, invoice.CurrencyType);
            Assert.Equal(invoiceRequest.Asset, invoice.Asset);
            Assert.Equal(invoiceRequest.Fiat, invoice.Fiat);
            // Assert.Equal(invoiceRequest.AcceptedAssets, invoice.AcceptedAssets);
            Assert.Equal(invoiceRequest.Description, invoice.Description);
            Assert.Equal(invoiceRequest.HiddenMessage, invoice.HiddenMessage);
            Assert.Equal(invoiceRequest.PaidBtnName, invoice.PaidBtnName);
            Assert.Equal(invoiceRequest.PaidBtnUrl, invoice.PaidBtnUrl);
            Assert.Equal(invoiceRequest.Payload, invoice.Payload);
            Assert.Equal(invoiceRequest.AllowComments!.Value, invoice.AllowComments);
            Assert.Equal(invoiceRequest.AllowAnonymous!.Value, invoice.AllowAnonymous);
            Assert.Equal(invoice.CreatedAt.AddSeconds(invoiceRequest.ExpiresIn).ToString("g"), invoice.ExpirationDate?.ToString("g"));
        }
        catch (RequestException requestException)
        {
            AssertException(requestException, statusCode, error);
        }
    }

    [Fact]
    public async Task GetBalanceTest()
    {
        var balance = await this.cryptoPayClient.GetBalanceAsync(this.cancellationToken);

        Assert.NotNull(balance);
        Assert.True(balance.Any());
    }

    [Fact]
    public async Task GetExchangeRatesTest()
    {
        var exchangeRates = await this.cryptoPayClient.GetExchangeRatesAsync(this.cancellationToken);

        Assert.NotNull(exchangeRates);
        Assert.True(exchangeRates.Any());
    }

    [Fact]
    public async Task GetCurrenciesTest()
    {
        var currencies = await this.cryptoPayClient.GetCurrenciesAsync(this.cancellationToken);

        Assert.NotNull(currencies);
        Assert.True(currencies.Any());
    }

    /// <summary>
    ///     For this test, you must have test coins.
    /// </summary>
    [Theory]
    [ClassData(typeof(TransferData))]
    public async Task TransferTest(HttpStatusCode statusCode, Error error, TransferRequest transferRequest)
    {
        try
        {
            var transfer = await this.cryptoPayClient.TransferAsync(
                transferRequest.UserId,
                transferRequest.Asset,
                transferRequest.Amount,
                transferRequest.SpendId,
                transferRequest.Comment,
                transferRequest.DisableSendNotification,
                this.cancellationToken);

            Assert.NotNull(transfer);
            Assert.Equal(transferRequest.UserId, transfer.UserId);
            Assert.Equal(transferRequest.Asset, transfer.Asset);
            Assert.Equal(transferRequest.Amount, transfer.Amount);
            //Assert.Equal(transferRequest.Comment, transfer.Comment);
            Assert.Equal(transferRequest.DisableSendNotification, transferRequest.DisableSendNotification);
        }
        catch (RequestException requestException)
        {
            AssertException(requestException, statusCode, error);
        }
    }

    /// <summary>
    ///     For this test, you must have test coins.
    /// </summary>
    [Theory]
    [ClassData(typeof(GetTransfersData))]
    public async Task GetTransfersTest(HttpStatusCode statusCode, Error error, TransferRequest transferRequest)
    {
        try
        {
            var transfer = await this.cryptoPayClient.TransferAsync(
                transferRequest.UserId,
                transferRequest.Asset,
                transferRequest.Amount,
                transferRequest.SpendId,
                transferRequest.Comment,
                transferRequest.DisableSendNotification,
                this.cancellationToken);

            var transfers = await this.cryptoPayClient.GetTransfersAsync(cancellationToken: this.cancellationToken);

            Assert.NotNull(transfer);

            Assert.NotNull(transfers);
            Assert.True(transfers.Items.Any());
        }
        catch (RequestException requestException)
        {
            AssertException(requestException, statusCode, error);
        }
    }

    [Theory]
    [ClassData(typeof(GetInvoicesData))]
    public async Task GetInvoicesTest(
        HttpStatusCode statusCode,
        Error error,
        IList<Assets> assets,
        IList<long> invoiceIds,
        Statuses? status,
        int offset,
        int count)
    {
        try
        {
            var invoices = await this.cryptoPayClient.GetInvoicesAsync(
                assets,
                invoiceIds,
                status,
                offset,
                count,
                this.cancellationToken);

            Assert.NotNull(invoices);
        }
        catch (RequestException requestException)
        {
            AssertException(requestException, statusCode, error);
        }
    }

    [Theory]
    [ClassData(typeof(DeleteInvoicesData))]
    public async Task DeleteInvoiceTest(HttpStatusCode statusCode, Error error, CreateInvoiceRequest invoiceRequest)
    {
        try
        {
            var invoice = await this.cryptoPayClient.CreateInvoiceAsync(
                invoiceRequest.Amount,
                invoiceRequest.CurrencyType,
                invoiceRequest.Asset,
                invoiceRequest.Fiat,
                invoiceRequest.AcceptedAssets,
                invoiceRequest.Description,
                invoiceRequest.HiddenMessage,
                invoiceRequest.PaidBtnName,
                invoiceRequest.PaidBtnUrl,
                invoiceRequest.Payload,
                invoiceRequest.AllowComments!.Value,
                invoiceRequest.AllowAnonymous!.Value,
                invoiceRequest.ExpiresIn,
                this.cancellationToken);

            var deleted = await this.cryptoPayClient.DeleteInvoiceAsync(invoice.InvoiceId, this.cancellationToken);

            Assert.NotNull(invoice);
            Assert.True(deleted);
        }
        catch (RequestException requestException)
        {
            AssertException(requestException, statusCode, error);
        }
    }

    [Theory]
    [ClassData(typeof(CreateCheckData))]
    public async Task CreateCheckTest(HttpStatusCode statusCode, Error error, CreateCheckRequest createCheckRequest)
    {
        try
        {
            var check = await this.cryptoPayClient.CreateCheckAsync(
                createCheckRequest.Asset,
                createCheckRequest.Amount,
                this.cancellationToken);

            Assert.NotNull(check);
            Assert.Equal(createCheckRequest.Asset, check.Asset);
            Assert.Equal(createCheckRequest.Amount, check.Amount);
        }
        catch (RequestException requestException)
        {
            AssertException(requestException, statusCode, error);
        }
    }

    [Theory]
    [ClassData(typeof(CreateCheckData))]
    public async Task DeleteCheckTest(HttpStatusCode statusCode, Error error, CreateCheckRequest createCheckRequest)
    {
        try
        {
            var check = await this.cryptoPayClient.CreateCheckAsync(
                createCheckRequest.Asset,
                createCheckRequest.Amount,
                this.cancellationToken);

            var deleted = await this.cryptoPayClient.DeleteCheckAsync(check.CheckId, this.cancellationToken);

            Assert.True(deleted);
        }
        catch (RequestException requestException)
        {
            AssertException(requestException, statusCode, error);
        }
    }

    [Theory]
    [ClassData(typeof(CreateCheckData))]
    public async Task GetCheckTest(HttpStatusCode statusCode, Error error, CreateCheckRequest createCheckRequest)
    {
        try
        {
            var check = await this.cryptoPayClient.CreateCheckAsync(
                createCheckRequest.Asset,
                createCheckRequest.Amount,
                this.cancellationToken);

            var checks = await this.cryptoPayClient.GetChecksAsync(cancellationToken: this.cancellationToken);

            Assert.NotNull(check);
            Assert.NotNull(checks);
            Assert.True(checks.Items.Any());
        }
        catch (RequestException requestException)
        {
            AssertException(requestException, statusCode, error);
        }
    }

    #endregion
}