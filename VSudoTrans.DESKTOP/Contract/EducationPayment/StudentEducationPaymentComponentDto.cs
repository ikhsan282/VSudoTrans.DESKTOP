using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.EducationPayment
{
    public class StudentEducationPaymentComponentDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int StudentEducationPaymentId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int EducationComponentId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public EnumPaymentStatus PaymentStatus { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int Priority { get; set; }
    }
}
