using MP.ApiDotNet6.Domain.Entities.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }

        public ICollection<Purchase> Purchases{ get;set; }

        public Person(string name, string document, string phone)
        {
            Validation(name, document, phone);
            Purchases = new List<Purchase>();
        }

        //public Person(int id, string name, string document, string phone)
        //{
        //    //DomainValidationException.When(id <= 0, "Id deve ser maior que 0");
        //    Validation(name, document, phone);
        //    Id = id;
        //    Purchases = new List<Purchase>();
        //}

        private void Validation(string name, string document, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(document), "O Documento deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "O Telefone deve ser informado");

            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}
