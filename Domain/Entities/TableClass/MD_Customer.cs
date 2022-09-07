using System.Collections.Generic;

namespace Domain.Entities.TableClass
{
    public partial class MD_Customer : BaseEntity
    {
        public MD_Customer()
        {
            SamUserAccount = new List<SAM_UserAccount>();
        }

        public int CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public string TaxCode { get; set; }
        public string Address { get; set; }
        public virtual ICollection<SAM_UserAccount> SamUserAccount { get; set; }
    }
}
