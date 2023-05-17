﻿namespace ServiceOAuth2.business.Data.Request
{
    public class AuthorizationTokenRequest
    {
        public Guid UserId { get; set; }
        public Guid ApplicationId { get; set; }
        public string Scope { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
