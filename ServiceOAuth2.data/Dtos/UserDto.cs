namespace ServiceOAuth2.data.Dtos
{
    public class UserDto
    {
        private Guid _userId { get; set; }

        public UserDto(Guid userId)
        {
            _userId = userId;
        }

        public Guid UserId
        {
            get { return _userId; }
            set { value = _userId; }
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
