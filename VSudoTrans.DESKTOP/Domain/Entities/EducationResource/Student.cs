using Domain.Entities.HumanResource;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;
using System.ComponentModel.DataAnnotations;
using System;
using Domain.Entities.EducationPayment;
using System.Collections.Generic;

namespace Domain.Entities.EducationResource
{
    [Table("Student")]
    [DisplayName("Murid")]
    public class Student : BaseCodeName
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int MajorId { get; set; }
        public Major Major { get; set; }
        public int ForceYearId { get; set; }
        public ForceYear ForceYear { get; set; }
        public int RombelId { get; set; }
        public Rombel Rombel { get; set; }
        public DateTime JoinDate { get; set; }
        public int IJoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? IEndDate { get; set; }
        [MaxLength(10)]
        public string CountryCode { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string NISN { get; set; }
        public decimal Balance { get; set; }
        public EnumParentalStatus ParentalStatus { get; set; }
        public virtual StudentPersonalData StudentPersonalData { get; set; }
        public virtual List<StudentEducationPayment> StudentEducationPayments { get; set; }
        public virtual List<StudentEducationPaymentHistory> StudentEducationPaymentHistorys { get; set; }
    }
}
