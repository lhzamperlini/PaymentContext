using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _subscriptions = new List<Subscription>();
        }

        public Name Name {  get; set; } 
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubsCriptionActive = false;

            foreach(var sub in Subscriptions)
            {
                if(sub.Active)
                    hasSubsCriptionActive = true;
            }

            if(!hasSubsCriptionActive)
                _subscriptions.Add(subscription);

            AddNotifications(new Contract<Student>()
                                 .Requires()
                                 .IsFalse(hasSubsCriptionActive, "Student.Suscriptions", "Você já possui uma assinatura ativa")
                                 .AreEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "Essa assinatura não possui pagamentos."));

        }

    }
}
