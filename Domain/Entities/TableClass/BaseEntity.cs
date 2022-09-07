using System;

namespace Domain.Entities.TableClass
{
    public abstract class BaseEntity
    {
        public string CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsBlocked { get; set; }
    }
}