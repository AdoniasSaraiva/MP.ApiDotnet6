using MP.ApiDotNet6.Domain.Entities.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public sealed class Permission
    {
        public Permission(string visualName, string permissionName)
        {
            Validation(visualName, permissionName);
            UserPermissions = new List<UserPermission>();
        }

        public long Id { get; set; }
        public string VisualName { get; set; }
        public string PermissionName { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }

        private void Validation(string visualName, string permissionName)
        {
            DomainValidationException.When(string.IsNullOrEmpty(visualName), "Nome Visual deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(permissionName), "Permissão deve ser informado");

            VisualName = visualName;
            PermissionName = permissionName;
        }
    }
}
