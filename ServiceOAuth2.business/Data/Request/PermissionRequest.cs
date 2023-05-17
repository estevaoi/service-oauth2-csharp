namespace ServiceOAuth2.business.Data.Request
{
    public class PermissionRequest
    {
        public Guid UserId { get; set; }
        public Guid ScopeId { get; set; }
    }
}
