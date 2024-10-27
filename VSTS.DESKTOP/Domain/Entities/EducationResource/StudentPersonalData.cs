using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Demography;
using System;
using Domain.Entities.HumanResource;

namespace Domain.Entities.EducationResource
{

    [Table("StudentPersonalData")]
    [DisplayName("Data Pribadi Murid")]
    public class StudentPersonalData : BaseDomainDetail
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [MaxLength(10)]
        public string AlternateCountryCode { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string AlternateEmail { get; set; }

        [ForeignKey("FromSchoolProvinceId")]
        public virtual Province FromSchoolProvince { get; set; }
        public int? FromSchoolProvinceId { get; set; }
        [ForeignKey("FromSchoolCityId")]
        public virtual City FromSchoolCity { get; set; }
        public int? FromSchoolCityId { get; set; }
        public string FromSchool { get; set; }
        public string NoSKHUN { get; set; }
        [MaxLength(4)]
        public string GraduationYear { get; set; }

        public string NoKTP { get; set; } // NIK KTP
        public string NoKK { get; set; } // NIK KK
        public string PresentAddress { get; set; } // Alamat Tinggal
        public string Address { get; set; } // Alamat Tetap
        public DateTime BirthDay { get; set; }
        public string BirthPlace { get; set; }
        public EnumMaritalStatus? MaritalStatus { get; set; }
        public EnumReligion? Religion { get; set; }
        public EnumBloodType? BloodType { get; set; }
        public EnumGender? Gender { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string Nationality { get; set; }
        public string Ethnic { get; set; }
        public int? Child { get; set; }
        public int? Sibling { get; set; }

        public string FatherName { get; set; }
        [MaxLength(10)]
        public string CountryCodeFather { get; set; }
        public string PhoneNumberFather { get; set; }
        public string FatherWork { get; set; }

        public string MotherName { get; set; }
        [MaxLength(10)]
        public string CountryCodeMother { get; set; }
        public string PhoneNumberMother { get; set; }
        public string MotherWork { get; set; }

        public string Photo { get; set; }
        public string Signature { get; set; }

        [NotMapped]
        public string PhotoUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(Photo))
                    return "https://vsudotechstorage.blob.core.windows.net/vsts/student/" + Photo;
                else
                    return string.Empty;
            }
            set
            {

            }
        }

        [NotMapped]
        public string SignatureUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(Signature))
                    return "https://vsudotechstorage.blob.core.windows.net/vsts/student/" + Signature;
                else
                    return string.Empty;
            }
            set
            {

            }
        }
    }
}
