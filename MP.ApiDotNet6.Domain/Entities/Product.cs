using MP.ApiDotNet6.Domain.Entities.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodeErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Product(string name, string codeErp, decimal price)
        {
            Validation(name, codeErp, price);
            Purchases = new List<Purchase>();
        }

        private void Validation(string name, string codeErp, decimal price)
        {

            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(codeErp), "O Código deve ser informado");
            DomainValidationException.When(price <= 0, "O Preço deve ser informado ou maior que 0");

            Name = name;
            CodeErp = codeErp;
            Price = price;
            Purchases = new List<Purchase>();
        }

        public Product(int id, string name, string codeErp, decimal price)
        {
            Validation(name, codeErp, price);
            //DomainValidationException.When(id <= 0, "O IdProduct deve ser informado ou maior que 0");
            ////Id = id;
        }

        public Product() { }

    }
}
