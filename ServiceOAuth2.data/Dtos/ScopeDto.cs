namespace ServiceOAuth2.data.Dtos
{
    public class ScopeDto
    {
        private Guid _scopeId { get; set; }

        public ScopeDto(Guid scopeId)
        {
            _scopeId = scopeId;
        }

        public Guid ScopeId
        {
            get { return _scopeId; }
            set { value = _scopeId; }
        }

        public string ScopeName { get; set; }
        public string Description { get; set; }
    }
}
