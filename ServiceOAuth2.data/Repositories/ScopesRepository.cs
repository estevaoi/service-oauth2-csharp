namespace ServiceOAuth2.data.Repositories
{
    public class ScopesRepository : BaseRepository
    {
        public ScopesRepository() { }

        #region SQL

        public const string SqlSelect = @"
            SELECT
                scope_id AS ScopeId,
                scope_name AS ScopeName,
                description AS Description
            FROM
                OAuthDB.scopes";

        public const string SqlInsert = @"
            INSERT INTO
              OAuthDB.scopes (
                scope_id,
                scope_name,
                description
              ) VALUE (
                @ScopeId,
                @ScopeName,
                @Description
              )";

        public const string SqlUpdate = @"
            UPDATE
                OAuthDB.scopes
            SET
                scope_name = @ScopeName,
                description = @Description
            WHERE
                scope_id = @ScopeId";

        public const string SqlDelete = @"
            DELETE
            FROM
                OAuthDB.scopes
            WHERE
                scope_id = @ScopeId";

        #endregion

    }
}
