using System.Collections.Generic;

namespace Domain.Entities.TableClass
{
    public partial class SAM_Role : BaseEntity
    {
        public SAM_Role()
        {
            SamUserInRole = new List<SAM_UserInRole>();
            SamFuncInRole = new List<SAM_FuncInRole>();
        }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleNotes { get; set; }
        public string RoleCode { get; set; }
        public virtual ICollection<SAM_UserInRole> SamUserInRole { get; set; }
        public virtual ICollection<SAM_FuncInRole> SamFuncInRole { get; set; }
    }
}
