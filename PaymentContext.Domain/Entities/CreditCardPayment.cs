using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities;
public class CreditCardPayment : Payment
{
    public CreditCardPayment(
        DateTime paydDate, 
        DateTime expireDate, 
        decimal totalPaid, 
        string payer, 
        Document document, 
        Address address, 
        string cardNumber, 
        string cardHolderName, 
        string lastTransactionNumber,
        Email email) : base(
            paydDate, 
            expireDate, 
            totalPaid, 
            payer, 
            document, 
            address,
            email)
    {
        CardNumber = cardNumber;
        CardHolderName = cardHolderName;
        LastTransactionNumber = lastTransactionNumber;
    }

    public string CardNumber { get; private set; }
    public string CardHolderName { get; private set; }
    public string LastTransactionNumber { get; private set; }
}