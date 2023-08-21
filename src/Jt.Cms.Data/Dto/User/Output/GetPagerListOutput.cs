namespace Jt.Cms.Data
{
    public class GetPagerListOutput
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public DateTime RegisterTime { get; set; }

        public DateTime LoginTime { get; set; }

        public int Status { get; set; }

        public string StatusText
        {
            get
            {
                return Status == 0 ? "正常" : "关闭";
            }
        }

        public string Avatar { get; set; }

        public int FollowCount
        {
            get
            {
                if (UserFollows != null) return UserFollows.Count;
                return 0;
            }
        }

        public List<UserRole> UserRoles { get; set; }

        public List<UserFollow> UserFollows { get; set; }
    }
}
