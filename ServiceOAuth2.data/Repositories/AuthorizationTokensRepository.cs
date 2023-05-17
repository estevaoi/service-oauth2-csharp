namespace ServiceOAuth2.data.Repositories
{
    public class AuthorizationTokensRepository : BaseRepository
    {
        public AuthorizationTokensRepository() { }

        #region SQL

        public const string SqlSelect = @"
            SELECT
                authorization_token_id AS AuthorizationTokenId,
                user_id AS UserId,
                user_id AS UserName,
                application_id AS ApplicationId,
                application_id AS ApplicationNome,
                scope AS Scope,
                created_at AS CreatedAt,
                expires_at AS ExpiresAt,
                additional_info AS AdditionalInfo
            FROM
                OAuthDB.authorization_tokens";

        public const string SqlInsert = @"
            INSERT INTO
              OAuthDB.authorization_tokens (
                authorization_token_id,
                user_id,
                application_id,
                scope,
                created_at,
                expires_at,
                additional_info
              ) VALUE (
                @AuthorizationTokenId,
                @UserId,
                @ApplicationId,
                @Scope,
                @CreatedAt,
                @ExpiresAt,
                @AdditionalInfo
              )";

        public const string SqlUpdate = @"
            UPDATE
                OAuthDB.authorization_tokens
            SET
                user_id = @UserId,
                application_id = @ApplicationId,
                scope = @Scope,
                created_at = @CreatedAt,
                expires_at = @ExpiresAt,
                additional_info = @AdditionalInfo
            WHERE
                authorization_token_id = @AuthorizationTokenId";

        public const string SqlDelete = @"
            DELETE
            FROM
                OAuthDB.authorization_tokens
            WHERE
                authorization_token_id = @AuthorizationTokenId";

        #endregion

    }
}
