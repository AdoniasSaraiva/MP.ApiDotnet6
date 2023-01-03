using MP.ApiDotNet6.Domain.Entities.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public sealed class UserPermission
    {
        public UserPermission(int userId, int permissionId)
        {
            Validation(userId, permissionId);
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public User User { get; set; }
        public Permission Permission { get; set; }

        private void Validation(int userId, int permissionId)
        {
            DomainValidationException.When(userId == 0, "Id do Usuário deve ser informada");
            DomainValidationException.When(permissionId == 0, "Id da Permissão deve ser informada");

            UserId = userId;
            PermissionId = permissionId;
        }
    }
}
