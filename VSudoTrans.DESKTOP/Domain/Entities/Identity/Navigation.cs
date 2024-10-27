using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Domain.Entities.Identity
{
    [Table("Navigation")]
    [DisplayName("Navigation")]
    public class Navigation : BaseCodeName
    {
        public string ParentCode { get; set; }
        [MaxLength(300)]
        public string ObjectDesktop { get; set; } 
        [MaxLength(300)]
        public string ObjectWeb { get; set; } 
        [ForeignKey("Controller")]
        public int? ControllerId { get; set; }
        public virtual ApplicationController Controller { get; set; }
        public bool IsPopUp { get; set; }
        public int Index { get; set; } // Urutan Navigation
    }
}
