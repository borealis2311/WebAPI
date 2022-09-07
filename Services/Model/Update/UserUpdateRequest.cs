namespace Services.Model.Update
{
    public class UserUpdateRequest : IsblockedRequest
    {
        public string Accpwd { get; set; }
        public string Accountemail { get; set; }
        public string Recoveryemail { get; set; }
        public string Phonenumber { get; set; }

    }
}
