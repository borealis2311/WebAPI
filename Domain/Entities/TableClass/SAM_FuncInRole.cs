namespace Domain.Entities.TableClass
{
    public partial class SAM_FuncInRole : BaseEntity
    {
        public int FID { get; set; }
        public int? RoleID { get; set; }
        public int? FuncID { get; set; }
        public virtual SAM_Role Role { get; set; }
        public virtual SAM_Function Function { get; set; }
    }
}
