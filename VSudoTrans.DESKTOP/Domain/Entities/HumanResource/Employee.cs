using Domain.Entities.HumanResource;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.HumanResource
{
    [Table("Teacher")]
    [DisplayName("Karyawan")]
    public class Employee : BaseCodeName
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int? OrganizationStructureId { get; set; }
        public OrganizationStructure OrganizationStructure { get; set; }
        public DateTime JoinDate { get; set; }
        //public DateTime? EndDate { get; set; }
        public DateTime? ResignationDate { get; set; }
        public int? EmployeePersonalDataId { get; set; }
        public virtual EmployeePersonalData EmployeePersonalData { get; set; }
        public int JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }
        public int? JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; }
        public int? JobGradeId { get; set; }
        public JobGrade JobGrade { get; set; }
        [MaxLength(10)]
        public string CountryCode { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
    }
}
