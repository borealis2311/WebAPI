using System;

namespace Domain.Entities.TableClass
{
    public partial class SAM_UserInRole : BaseEntity
    {
        public int UID { get; set; }
        public DateTime ValidDateFrom { get; set; } = DateTime.Now;
        public DateTime? ValidDateTo { get; set; }
        public int? AccountID { get; set; }
        public int? RoleID { get; set; }
        public virtual SAM_UserAccount UserAccount { get; set; }
        public virtual SAM_Role Role { get; set; }
    }
}
