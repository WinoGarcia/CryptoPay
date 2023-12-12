using System.Collections.Generic;
using System.Net;
using CryptoPay.Types;
using Xunit;

namespace CryptoPay.Tests.TestData;

public class GetInvoicesData
    : TheoryData<
        HttpStatusCode,
        Error?,
        IList<Assets>?, // assets
        IList<long>?, // invoiceIds
        Statuses?, //status
        int, // offset 
        int> // count
{
    public GetInvoicesData()
    {
        this.Add(default, default, default, default, default, 0, 100);
        this.Add(default, default, default, default, default, 10, 100);
        this.Add(default, default, default, default, Statuses.paid, 0, 10);
        this.Add(
            default,
            default,
            new List<Assets>(),
            default,
            Statuses.active,
            5,
            15
        );
        this.Add(
            default,
            default,
            new List<Assets>
            {
                Assets.TON,
                Assets.BNB
            },
            default,
            Statuses.active,
            0,
            10
        );
        this.Add(
            default,
            default,
            default,
            new List<long>()
            {
                00000,
                11111
            },
            default,
            0,
            100
        );
        this.Add(
            HttpStatusCode.InternalServerError,
            new Error(500, "APP_ERROR"),
            default,
            default,
            default,
            -10,
            100
        );
        this.Add(
            HttpStatusCode.InternalServerError,
            new Error(500, "APP_ERROR"),
            default,
            default,
            default,
            5,
            -30
        );
    }
}