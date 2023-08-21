namespace Jt.Cms.Data
{
    public class GetUserInfoOutput
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Avatar { get; set; }

        public DateTime RegisterTime { get; set; }

        public DateTime LoginTime { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
