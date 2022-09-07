namespace Services.Model.Add
{
    public class ModuleRequest
    {
        public string Modulecode { get; set; }
        public string Moduledesc { get; set; }
        public string Icon { get; set; }
        public int Orderno { get; set; } = 0;

    }
}
