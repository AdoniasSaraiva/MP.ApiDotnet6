using MP.ApiDotNet6.Domain.Entities.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public class User
    {
        public User(string email, string password)
        {
            Validation(email, password);
            UserPermissions = new List<UserPermission>();
        }

        public User(long id, string email, string password)
        {
            DomainValidationException.When(id <= 0, "Id deve ser informado");
            Id = id;
            Validation(email, password);
            UserPermissions = new List<UserPermission>();
        }

        public long Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public ICollection<UserPermission> UserPermissions { get; private set; }

        private void Validation(string email, string password)
        {
            DomainValidationException.When(string.IsNullOrEmpty(email), "E-mail deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(password), "Password deve ser informado");

            Email = email;
            Password = password;
        }
    }
}
