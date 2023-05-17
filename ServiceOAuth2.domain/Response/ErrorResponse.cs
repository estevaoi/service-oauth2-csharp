namespace ServiceOAuth2.domain.Response
{
    public class ErrorResponse
    {
        public Guid CorrelationId { get; set; }
        public string Message { get; set; }
    }
}
