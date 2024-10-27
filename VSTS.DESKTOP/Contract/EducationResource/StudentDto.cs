using Contract.Base;
using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.EducationResource
{
    public class StudentDto : EntityDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int ClassId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int MajorId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int ForceYearId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int RombelId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public DateTime JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string NISN { get; set; }
        public decimal Balance { get; set; }
        public EnumParentalStatus ParentalStatus { get; set; }
        //public StudentPersonalDataDto? StudentPersonalData { get; set; }
    }

    public class ImportStudentModel
    {
        public int Id { get; set; }
        public string SchoolCode { get; set; }
        public string ClassName { get; set; }
        public string MajorCode { get; set; }
        public string ForceYearName { get; set; }
        public string RombelName { get; set; }
        public string JoinDate { get; set; }
        public string EndDate { get; set; }
        public string NISN { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string BirthPlace { get; set; }
        public string BirthDate { get; set; }
        public string ParentalStatus { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryStudentModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportStudentModel> Data { get; set; }
    }

    public class ImportStudentExcelModel
    {
        [JsonProperty("School Code")]
        public string SchoolCode { get; set; }
        [JsonProperty("Class Name")]
        public string ClassName { get; set; }
        [JsonProperty("Major Code")]
        public string MajorCode { get; set; }
        [JsonProperty("Force Name")]
        public string ForceYearName { get; set; }
        [JsonProperty("Rombel Name")]
        public string RombelName { get; set; }
        [JsonProperty("Join Date")]
        public string JoinDate { get; set; }
        [JsonProperty("End Date")]
        public string EndDate { get; set; }
        [JsonProperty("NISN")]
        public string NISN { get; set; }
        [JsonProperty("NIS")]
        public string Code { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Gender")]
        public string Gender { get; set; }
        [JsonProperty("Religion")]
        public string Religion { get; set; }
        [JsonProperty("Birth Place")]
        public string BirthPlace { get; set; }
        [JsonProperty("Birth Date")]
        public string BirthDate { get; set; }
        [JsonProperty("Parental Status")]
        public string ParentalStatus { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}
