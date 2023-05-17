namespace ServiceOAuth2.data.Repositories
{
    public class ClientApplicationsRepository : BaseRepository
    {
        public ClientApplicationsRepository() { }

        #region SQL

        public const string SqlSelect = @"
            SELECT
                application_id,
                application_name,
                client_identifier,
                client_secret,
                redirect_urls
            FROM
                OAuthDB.client_applications";

        public const string SqlInsert = @"
            INSERT INTO
              OAuthDB.client_applications (
                application_id,
                application_name,
                client_identifier,
                client_secret,
                redirect_urls
              ) VALUE (
                @ApplicationId,
                @ApplicationName,
                @ClientIdentifier,
                @ClientSecret,
                @RedirectUrls
              )";

        public const string SqlUpdate = @"
            UPDATE
                OAuthDB.client_applications
            SET
                application_name = @ApplicationName,
                client_identifier = @ClientIdentifier,
                client_secret = @ClientSecret,
                redirect_urls = @RedirectUrls
            WHERE
                application_id = @ApplicationId";

        public const string SqlDelete = @"
            DELETE
            FROM
                OAuthDB.client_applications
            WHERE
                application_id = @ApplicationId";

        #endregion

    }
}
