namespace Services.Model.Update
{
    public class CustomerUpdateRequest : IsblockedRequest
    {
        public string FullNameU { get; set; }
        public string TaxCodeU { get; set; }
        public string AddressU { get; set; }

    }
}
