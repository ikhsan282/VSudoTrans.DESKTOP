using Domain.Base;
using Domain.Entities.Organization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System;

namespace Domain.Entities.Travel
{
    [Table("Schedule")]
    [DisplayName("Schedule")]
    public class Schedule : BaseCodeName
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public TimeSpan StartBreak { get; set; }
        public TimeSpan EndBreak { get; set; }
        public decimal? Duration { get; set; }
        public decimal? TotalDuration { get; set; }
    }
}
