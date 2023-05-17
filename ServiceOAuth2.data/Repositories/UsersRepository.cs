namespace ServiceOAuth2.data.Repositories
{
    public class UsersRepository : BaseRepository
    {
        public UsersRepository() { }

        #region SQL

        public const string SqlSelect = @"
            SELECT
                user_id AS UserId,
                username AS Username,
                password AS Password,
                name AS Name,
                email AS Email
            FROM
                OAuthDB.users";

        public const string SqlInsert = @"
            INSERT INTO
              OAuthDB.users (
                user_id,
                username,
                password,
                name,
                email
              ) VALUE (
                @UserId,
                @Username,
                @Password,
                @Name,
                @Email
              )";

        public const string SqlUpdate = @"
            UPDATE
                OAuthDB.users
            SET
                username = @Username,
                password = @Password,
                name = @Name,
                email = @Email
            WHERE
                user_id = @UserId";

        public const string SqlDelete = @"
            DELETE
            FROM
                OAuthDB.users
            WHERE
                user_id = @UserId";

        #endregion

    }
}
