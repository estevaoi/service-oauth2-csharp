namespace ServiceOAuth2.data.Dtos
{
    public class PermissionDto
    {
        private Guid _permissionId { get; set; }

        public PermissionDto(Guid permissionId)
        {
            _permissionId = permissionId;
        }

        public Guid PermissionId
        {
            get { return _permissionId; }
            set { value = _permissionId; }
        }

        public Guid UserId { get; set; }
        public Guid ScopeId { get; set; }
    }
}
