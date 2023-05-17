namespace ServiceOAuth2.data.Repositories
{
    public class AccessTokensRepository : BaseRepository
    {
        public AccessTokensRepository() { }

        #region SQL

        public const string SqlSelect = @"
            SELECT
                access_token_id AS AccessTokenId,
                user_id AS UserId,
                user_id AS UserNome,
                application_id AS ApplicationId,
                application_id AS ApplicationNome,
                scope AS Scope,
                created_at AS CreatedAt,
                expires_at AS ExpiresAt
            FROM
                OAuthDB.access_tokens";

        public const string SqlInsert = @"
            INSERT INTO
              OAuthDB.access_tokens(
                access_token_id,
                user_id,
                application_id,
                scope,
                created_at,
                expires_at
              ) VALUE(
                @AccessTokenId,
                @UserId,
                @ApplicationId,
                @Scope,
                @CreatedAt,
                @ExpiresAt
              )";

        public const string SqlUpdate = @"
            UPDATE
                OAuthDB.access_tokens
            SET
                user_id = @UserId,
                application_id = @ApplicationId,
                scope = @Scope,
                created_at = @CreatedAt,
                expires_at = @ExpiresAt
            WHERE
                access_token_id = @AccessTokenId";

        public const string SqlDelete = @"
            DELETE
            FROM
                OAuthDB.access_tokens
            WHERE
                access_token_id = @AccessTokenId";

        #endregion

    }
}
