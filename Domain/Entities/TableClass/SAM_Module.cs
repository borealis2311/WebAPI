using System.Collections.Generic;

namespace Domain.Entities.TableClass
{
    public partial class SAM_Module : BaseEntity
    {
        public SAM_Module()
        {
            SamFunction = new List<SAM_Function>();
        }
        public int ModuleID { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleDesc { get; set; }
        public string Icon { get; set; }
        public int OrderNo { get; set; }
        public virtual ICollection<SAM_Function> SamFunction { get; set; }
    }
}
