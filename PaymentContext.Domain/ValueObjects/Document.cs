﻿using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects;
public class Document : ValueObject
{
    public Document(string number, EDocumentType documentType)
    {
        Number = number;
        Type = documentType;

        AddNotifications(new Contract<Document>()
                             .Requires()
                             .IsTrue(Validate(), "Document.Number", "Documento Inválido"));
    }

    private bool Validate()
    {
        if (Type == EDocumentType.CNPJ && Number.Length == 14)
            return true;

        if (Type == EDocumentType.CPF && Number.Length == 11)
            return true;
        
        return false;
    }

    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }
}
