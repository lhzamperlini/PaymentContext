using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities;
public class PaypalPayment : Payment
{
    public PaypalPayment(
        DateTime paydDate,
        DateTime expireDate,
        decimal totalPaid,
        string payer,
        Document document,
        Address address,
        string transactionCode,
        Email email) : base(
            paydDate,
            expireDate,
            totalPaid,
            payer,
            document,
            address,
            email)
    {
        TransactionCode = transactionCode;
    }

    public string TransactionCode { get; private set; }
}
