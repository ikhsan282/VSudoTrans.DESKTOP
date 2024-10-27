using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System;

namespace Domain.Entities.Identity
{
    [Table("NavigationRole")]
    [DisplayName("NavigationRole")]
    public class NavigationRole : BaseDomainDetail
    {
        [ForeignKey("Navigation")]
        public int NavigationId { get; set; }
        public virtual Navigation Navigation { get; set; }
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
