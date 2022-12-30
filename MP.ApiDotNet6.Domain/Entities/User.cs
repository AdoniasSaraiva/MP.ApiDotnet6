using MP.ApiDotNet6.Domain.Entities.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public class User
    {
        public User(string email, string password)
        {
            Validation(email, password);
        }

        public User(long id, string email, string password)
        {
            DomainValidationException.When(id <= 0, "Id deve ser informado");
            Id = id;
            Validation(email, password);
        }

        public long Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        private void Validation(string email, string password)
        {
            DomainValidationException.When(string.IsNullOrEmpty(email), "E-mail deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(password), "Password deve ser informado");

            Email = email;
            Password = password;
        }
    }
}
