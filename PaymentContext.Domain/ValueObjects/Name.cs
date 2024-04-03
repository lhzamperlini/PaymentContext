using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaymentContext.Domain.ValueObjects;
public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<Name>()
            .Requires()
            .IsGreaterThan(firstName, 3, "Primeiro Nome", "O primeiro nome deve ter ao menos 3 caracteres")
            .IsGreaterThan(lastName, 3, "Sobrenome", "O sobrenome deve ter ao menos 3 caracteres"));
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}
