namespace Services.Model.Update
{
    public class ModuleUpdateRequest : IsblockedRequest
    {
        public string ModuledescU { get; set; }
        public string IconU { get; set; }
        public int OrdernoU { get; set; } = 0;

    }
}
