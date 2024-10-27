using Contract.Base;
using Domain;
using Domain.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.Attendance
{
    public class AttendanceCodeDto : EntityDto
    {
        public int CompanyId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public EnumAbsenceType GroupType { get; set; } // Untuk Grouping
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public EnumAbsenceAssignmentType AssignmentType { get; set; } // Untuk fungsi
        public EnumGender Gender { get; set; }
        public int MaxLeave { get; set; }
        public decimal? DurationDay { get; set; } // HK 1.0 atau 0.5, atau 0.75
    }

    public class ImportAttendanceCodeModel
    {
        public int Id { get; set; }
        public string SchoolCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string GroupType { get; set; }
        public string AssignmentType { get; set; }
        public string Gender { get; set; }
        public string MaxLeave { get; set; }
        public string DurationDay { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryAttendanceCodeModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportAttendanceCodeModel> Data { get; set; }
    }

    public class ImportAttendanceCodeExcelModel
    {
        [JsonProperty("School Code")]
        public string SchoolCode { get; set; }
        [JsonProperty("Attendance Code Code")]
        public string Code { get; set; }
        [JsonProperty("Attendance Code Name")]
        public string Name { get; set; }
        [JsonProperty("Group Type")]
        public string GroupType { get; set; }
        [JsonProperty("Assignment Type")]
        public string AssignmentType { get; set; }
        [JsonProperty("Gender")]
        public string Gender { get; set; }
        [JsonProperty("Max Leave")]
        public string MaxLeave { get; set; }
        [JsonProperty("Duration Day")]
        public string DurationDay { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}
