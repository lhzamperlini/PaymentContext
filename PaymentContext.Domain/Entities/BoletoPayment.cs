using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities;

public class BoletoPayment : Payment
{
    public BoletoPayment(
        DateTime paydDate, 
        DateTime expireDate, 
        decimal totalPaid, 
        string payer, 
        Document document,
        Address address, 
        string barCode, 
        string boletoNumber,
        Email email) : base(
            paydDate, 
            expireDate, 
            totalPaid, 
            payer, 
            document, 
            address,
            email)
    {
        BarCode = barCode;
        BoletoNumber = boletoNumber;
    }

    public string BarCode { get; private set; }
    public string BoletoNumber { get; private set; }
}
