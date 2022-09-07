namespace Services.Model.Add
{
    public class UserRequest
    {
        public string Accountname { get; set; }
        public string Accpwd { get; set; }
        public string Accountemail { get; set; }
        public string Recoveryemail { get; set; }
        public string Phonenumber { get; set; }
        public int Customerid { get; set; }
    }
}
