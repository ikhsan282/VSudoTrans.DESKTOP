using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.EducationPayment
{
    public class StudentEducationPaymentDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int StudentId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int ClassId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountPaid { get; set; }
        public EnumPaymentStatus PaymentStatus { get; set; }
        public List<StudentEducationPaymentComponentDto> StudentEducationPaymentComponents { get; set; }
        //public List<StudentEducationPaymentHistoryDto> StudentEducationPaymentHistorys { get; set; }
    }
    public class PaymentStudentEducationDto
    {
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int StudentId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public EnumPaymentMethod PaymentMethod { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public DateTime ActualDate { get; set; }
        public string Attachment { get; set; }
    }
    public class ImportStudentEducationPaymentModel
    {
        public int Id { get; set; }
        public string SchoolCode { get; set; }
        public string ClassName { get; set; }
        public string NIS { get; set; }
        public string DueDate { get; set; }
        public string EducationComponentCode { get; set; }
        public string Amount { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryStudentEducationPaymentModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportStudentEducationPaymentModel> Data { get; set; }
    }

    public class ImportStudentEducationPaymentExcelModel
    {
        [JsonProperty("School Code")]
        public string SchoolCode { get; set; }
        [JsonProperty("Class Name")]
        public string ClassName { get; set; }
        [JsonProperty("NIS")]
        public string NIS { get; set; }
        [JsonProperty("Due Date")]
        public string DueDate { get; set; }
        [JsonProperty("Education Component Code")]
        public string EducationComponentCode { get; set; }
        [JsonProperty("Amount")]
        public string Amount { get; set; }
    }
}
