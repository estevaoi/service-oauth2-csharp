namespace ServiceOAuth2.data.Repositories
{
    public class PermissionsRepository : BaseRepository
    {
        public PermissionsRepository() { }

        #region SQL

        public const string SqlSelect = @"
            SELECT
                permission_id AS PermissionId,
                user_id AS UserId,
                user_id AS UserNome,
                scope_id AS ScopeId,
                scope_id AS ScopeNome
            FROM
                OAuthDB.permissions";

        public const string SqlInsert = @"
            INSERT INTO
              OAuthDB.permissions (
                permission_id,
                user_id,
                scope_id
              ) VALUE (
                @PermissionId,
                @UserId,
                @ScopeId
              )";

        public const string SqlUpdate = @"
            UPDATE
                OAuthDB.permissions
            SET
                user_id = @UserId,
                scope_id = @ScopeId
            WHERE
                permission_id = @PermissionId";

        public const string SqlDelete = @"
            DELETE
            FROM
                OAuthDB.permissions
            WHERE
                permission_id = @PermissionId";

        #endregion

    }
}
