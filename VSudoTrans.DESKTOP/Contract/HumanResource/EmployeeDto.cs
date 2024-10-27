using Contract.Base;
using Domain;
using Domain.Entities.HumanResource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.HumanResource
{
    public class EmployeeDto : EntityDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int CompanyId { get; set; }
        public int OrganizationStructureId { get; set; }
        public DateTime? JoinDate { get; set; }
        //public DateTime? EndDate { get; set; }
        public DateTime? ResignationDate { get; set; }
        public int? PersonalDataId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int JobTitleId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int JobPositionId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int JobGradeId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public string CountryCode { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public EmployeePersonalData EmployeePersonalData { get; set; }
    }

    public class ImportEmployeeModel
    {
        public int Id { get; set; }
        public string SchoolCode { get; set; }
        public string OrganizationStructureCode { get; set; }
        public string JobPositionCode { get; set; }
        public string JobGradeCode { get; set; }
        public string JoinDate { get; set; }
        //public string EndDate { get; set; }
        public string ResignationDate { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string BirthPlace { get; set; }
        public string BirthDate { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryEmployeeModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportEmployeeModel> Data { get; set; }
    }

    public class ImportEmployeeExcelModel
    {
        [JsonProperty("School Code")]
        public string SchoolCode { get; set; }
        [JsonProperty("Organization Structure Code")]
        public string OrganizationStructureCode { get; set; }
        [JsonProperty("Job Position Code")]
        public string JobPositionCode { get; set; }
        [JsonProperty("Job Grade Code")]
        public string JobGradeCode { get; set; }
        [JsonProperty("Join Date")]
        public string JoinDate { get; set; }
        //[JsonProperty("End Date")]
        //public string EndDate { get; set; }
        [JsonProperty("Resignation Date")]
        public string ResignationDate { get; set; }
        [JsonProperty("Code")]
        public string Code { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Phone Number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("Gender")]
        public string Gender { get; set; }
        [JsonProperty("Religion")]
        public string Religion { get; set; }
        [JsonProperty("Birth Place")]
        public string BirthPlace { get; set; }
        [JsonProperty("Birth Date")]
        public string BirthDate { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}
