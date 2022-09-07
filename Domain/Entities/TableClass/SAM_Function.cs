using System.Collections.Generic;

namespace Domain.Entities.TableClass
{
    public partial class SAM_Function : BaseEntity
    {
        public SAM_Function()
        {
            SamFuncInRole = new List<SAM_FuncInRole>();
        }
        public int FuncID { get; set; }
        public string FuncCode { get; set; }
        public string FuncDesc { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }
        public int OrderNo { get; set; }
        public int? ModuleID { get; set; }
        public virtual ICollection<SAM_FuncInRole> SamFuncInRole { get; set; }
        public virtual SAM_Module Module { get; set; }
    }
}
