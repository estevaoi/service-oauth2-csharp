namespace ServiceOAuth2.business.Data.Response
{
    public class PermissionResponse
    {
        public Guid PermissionId { get; set; }
        public Guid UserId { get; set; }
        public string UserNome { get; set; }
        public Guid ScopeId { get; set; }
        public string ScopeNome { get; set; }
    }
}
