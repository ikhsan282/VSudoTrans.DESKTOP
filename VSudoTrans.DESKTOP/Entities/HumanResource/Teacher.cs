using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using System;
using System.Collections.Generic;
using Domain.Entities.Organization;

namespace Domain.Entities.HumanResource
{
    [Table("Teacher")]
    [DisplayName("Guru")]
    public class Teacher : BaseCodeName
    {
        public int SchoolId { get; set; }
        public School? School { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? PersonalDataId { get; set; }
        public virtual PersonalData? PersonalData { get; set; }
        public virtual ICollection<TeacherJobTitle>? TeacherJobTitles { get; set; }
    }
}
