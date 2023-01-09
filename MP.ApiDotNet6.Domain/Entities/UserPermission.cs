using MP.ApiDotNet6.Domain.Entities.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public sealed class UserPermission
    {
        public UserPermission(long userId, long permissionId)
        {
            Validation(userId, permissionId);
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public long PermissionId { get; set; }
        public User User { get; set; }
        public Permission Permission { get; set; }

        private void Validation(long userId, long permissionId)
        {
            DomainValidationException.When(userId == 0, "Id do Usuário deve ser informada");
            DomainValidationException.When(permissionId == 0, "Id da Permissão deve ser informada");

            UserId = userId;
            PermissionId = permissionId;
        }
    }
}
