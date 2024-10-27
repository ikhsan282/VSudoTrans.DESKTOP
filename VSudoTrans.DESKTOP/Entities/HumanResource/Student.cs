using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;
using System;

namespace Domain.Entities.HumanResource
{
    [Table("Student")]
    [DisplayName("Murid")]
    public class Student : BaseCodeName
    {
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? PersonalDataId { get; set; }
        public virtual PersonalData? PersonalData { get; set; }
    }
}
