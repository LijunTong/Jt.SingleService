namespace Jt.SingleService.Data
{
    public class RoleActionDto
    {
        public string RoleId { get; set; }
        public List<ActionDto> Actions { get; set; }

        public string UserId { get; set; }
    }
    public class ActionDto
    {
        public string Controller { get; set; }
        public string Action { get; set; }

    }
}
