using System.Collections.Generic;

namespace Domain.Entities.TableClass
{
    public partial class SAM_UserAccount : BaseEntity
    {
        public SAM_UserAccount()
        {
            SamUserInRole = new List<SAM_UserInRole>();
        }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string AccPwd { get; set; }
        public bool? IsActivated { get; set; }
        public string AccountEmail { get; set; }
        public string RecoveryEmail { get; set; }
        public string PhoneNumber { get; set; }
        public int? CustomerID { get; set; }
        public virtual MD_Customer Customer { get; set; }
        public virtual ICollection<SAM_UserInRole> SamUserInRole { get; set; }
    }
}
