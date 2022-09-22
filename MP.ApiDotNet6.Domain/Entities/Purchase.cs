using System;
using MP.ApiDotNet6.Domain.Entities.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; private set; }
        public Product Product { get; private set; }

        public Purchase(int productId, int personId)
        {
            Validation(productId, personId);
        }

        public Purchase(int id, int productId, int personId)
        {
            Validation(productId, personId);
            DomainValidationException.When(id <= 0, "Deve informar um purchase com o Id v�lido");
            Id = id;
        }
        private void Validation(int productId, int personId)
        {
            DomainValidationException.When(productId <= 0, "Deve informar um produto com o Id v�lido");
            DomainValidationException.When(personId <= 0, "Deve informar uma Person com o Id v�lido");

            ProductId = productId;
            PersonId = personId;
            Date = DateTime.Now;
        }
    }
}