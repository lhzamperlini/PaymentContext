using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;
public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public string BarCode { get; set; }
    public string BoletoNumber { get; set; }
    public string TransactionCode { get; set; }
    public string PaymentNumber { get; set; }
    public DateTime PaydDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; }
    public string PayerDocument { get; set; }
    public EDocumentType PayerDocumentType { get; set; }
    public string PayerEmail { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }

    public event EventHandler? CanExecuteChanged;

    public void Validate()
    {
        AddNotifications(new Contract<Name>()
                .Requires()
                .IsGreaterThan(FirstName, 3, "Primeiro Nome", "O primeiro nome deve ter ao menos 3 caracteres")
                .IsGreaterThan(LastName, 3, "Sobrenome", "O sobrenome deve ter ao menos 3 caracteres"));
    }
}
