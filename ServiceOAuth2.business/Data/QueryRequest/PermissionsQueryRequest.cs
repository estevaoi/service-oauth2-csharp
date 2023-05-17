namespace ServiceOAuth2.business.Data.QueryRequest
{
    public class PermissionsQueryRequest : BaseQueryRequest
    {
        public Guid? PermissionId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ScopeId { get; set; }
    }
}
