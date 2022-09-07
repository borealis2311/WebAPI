namespace Services.Model.Add
{
    public class FunctionRequest
    {
        public string Funccode { get; set; }
        public string Funcdesc { get; set; }
        public string UrL { get; set; }
        public int Orderno { get; set; } = 0;
        public int Moduleid { get; set; }
    }
}
