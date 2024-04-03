using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    private readonly Student _student;
    private readonly Subscription _subscription;
    private readonly Email _email;
    private readonly Address _address;
    private readonly Document _document;


    public StudentTests()
    {
        var name = new Name("Luis Henrique", "Zamperlini de Campos");
        _email = new Email("lhzamperlini@gmail.com");
        _document = new Document("31295192039", EDocumentType.CPF);
        _address = new Address("a", "b", "c", "d", "e", "f", "g");
        _student = new Student(name, _document, _email, _address);
        _subscription = new Subscription(null);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        var payment = new PaypalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, "Bruce Wayne", _document, _address, "address", _email);
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);
        Assert.IsFalse(_student.IsValid);
    }


    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        var subscription = new Subscription(null);
        _student.AddSubscription(subscription);
        Assert.IsFalse(_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCreatedStudent()
    {

        var payment = new PaypalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, "Bruce Wayne", _document, _address, "address", _email);
        
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        
        Assert.IsTrue(_student.IsValid);
    }
}
