using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;
using System;

namespace Domain.Entities.HumanResource
{

    [Table("PersonalData")]
    [DisplayName("Data Pribadi")]
    public class PersonalData : BaseDomainDetail
    {
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? AlternatePhone { get; set; }
        public string? Nis { get; set; }
        public string? Nisn { get; set; }
        public string? Nik { get; set; }
        public string? Npwp { get; set; }
        public string? PresentAddress { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? BirthPlace { get; set; }
        public EnumMaritalStatus? MaritalStatus { get; set; }
        public EnumReligion? Religion { get; set; }
        public EnumBloodType? BloodType { get; set; }
        public EnumGender? Gender { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string? Nationality { get; set; }
        public string? Ethnic { get; set; }
        public int? Child { get; set; }
        public int? Sibling { get; set; }
        public string? Photo { get; set; }
        public string? Signature { get; set; }
    }
}
