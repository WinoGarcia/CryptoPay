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

namespace CryptoPay.Tests;

public class AvailableMethodsTests
{
    #region Public Fields

    private readonly CancellationToken cancellationToken = new CancellationTokenSource().Token;

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
            var cryptoPayClient = new CryptoPayClient(token, apiUrl: apiUrl);
            var application = await cryptoPayClient.GetMeAsync(this.cancellationToken);

            Assert.NotNull(application);
            Assert.NotEmpty(application.Name);
            Assert.NotEmpty(application.PaymentProcessingBotUsername);
            Assert.Equal(cryptoPayClient.AppId, application.AppId);
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
            var cryptoPayClient = new CryptoPayClient(CryptoPayTestHelper.Token, apiUrl: CryptoPayTestHelper.ApiUrl);
            var invoice = await cryptoPayClient.CreateInvoiceAsync(
                invoiceRequest.Asset,
                invoiceRequest.Amount,
                invoiceRequest.Description,
                invoiceRequest.HiddenMessage,
                invoiceRequest.PaidBtnName,
                invoiceRequest.PaidBtnUrl,
                invoiceRequest.Payload,
                invoiceRequest.AllowComments!.Value,
                invoiceRequest.AllowAnonymous!.Value,
                invoiceRequest.ExpiresIn, this.cancellationToken);

            Assert.NotNull(invoice);
            Assert.NotNull(invoice.PayUrl);
            Assert.NotNull(invoice.Hash);
            Assert.Equal(invoiceRequest.Asset, invoice.Asset);
            Assert.Equal(invoiceRequest.Amount, invoice.Amount);
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
        var cryptoPayClient = new CryptoPayClient(CryptoPayTestHelper.Token, apiUrl: CryptoPayTestHelper.ApiUrl);
        var balance = await cryptoPayClient.GetBalanceAsync(this.cancellationToken);

        Assert.NotNull(balance);
        Assert.True(balance.Any());
    }

    [Fact]
    public async Task GetExchangeRatesTest()
    {
        var cryptoPayClient = new CryptoPayClient(CryptoPayTestHelper.Token, apiUrl: CryptoPayTestHelper.ApiUrl);
        var exchangeRates = await cryptoPayClient.GetExchangeRatesAsync(this.cancellationToken);

        Assert.NotNull(exchangeRates);
        Assert.True(exchangeRates.Any());
    }

    [Fact]
    public async Task GetCurrenciesTest()
    {
        var cryptoPayClient = new CryptoPayClient(CryptoPayTestHelper.Token, apiUrl: CryptoPayTestHelper.ApiUrl);
        var currencies = await cryptoPayClient.GetCurrenciesAsync(this.cancellationToken);

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
            var cryptoPayClient = new CryptoPayClient(CryptoPayTestHelper.Token, apiUrl: CryptoPayTestHelper.ApiUrl);
            var transfer = await cryptoPayClient.TransferAsync(
                transferRequest.UserId,
                transferRequest.Asset,
                transferRequest.Amount,
                transferRequest.SpendId,
                transferRequest.Comment,
                transferRequest.DisableSendNotification, this.cancellationToken);

            Assert.NotNull(transfer);
            Assert.Equal(transferRequest.UserId, transfer.UserId);
            Assert.Equal(transferRequest.Asset, transfer.Asset);
            Assert.Equal(transferRequest.Amount, transfer.Amount);
            Assert.Equal(transferRequest.Comment, transfer.Comment);
            Assert.Equal(transferRequest.DisableSendNotification, transferRequest.DisableSendNotification);
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
            var cryptoPayClient = new CryptoPayClient(CryptoPayTestHelper.Token, apiUrl: CryptoPayTestHelper.ApiUrl);
            var transfer = await cryptoPayClient.GetInvoicesAsync(
                assets,
                invoiceIds,
                status,
                offset,
                count, this.cancellationToken);

            Assert.NotNull(transfer);
        }
        catch (RequestException requestException)
        {
            AssertException(requestException, statusCode, error);
        }
    }

    #endregion
}