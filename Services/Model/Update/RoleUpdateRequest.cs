namespace Services.Model.Update
{
    public class RoleUpdateRequest : IsblockedRequest
    {
        public string Rolename { get; set; }
        public string Rolenotes { get; set; }
    }
}
