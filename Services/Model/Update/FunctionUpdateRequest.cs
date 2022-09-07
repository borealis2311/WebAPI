namespace Services.Model.Update
{
    public class FunctionUpdateRequest : IsblockedRequest
    {
        public string Funcdesc { get; set; }
        public string UrL { get; set; }
        public int Orderno { get; set; } = 0;

    }
}
