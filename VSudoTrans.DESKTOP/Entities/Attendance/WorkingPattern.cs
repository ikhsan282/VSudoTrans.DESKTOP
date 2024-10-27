using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using System.Collections.Generic;
using Domain.Entities.Organization;

namespace Domain.Entities.Attendance
{
    [Table("WorkingPattern")]
    [DisplayName("Pola Kerja")]
    public class WorkingPattern : BaseCodeName
    {
        public int SchoolId { get; set; }
        public School? School { get; set; }
        public short CycleLength { get; set; } // Untuk menyimpan total hari pola kerja
        public short WorkingDay { get; set; } // Untuk menyimpan jumlah Working Days Pola Kerja Contoh (Senin-Jumat WorkDay, Sabtu-Minggu Off, yang di simpan adalah 5)
        public List<WorkingPatternDetail>? WorkingPatternDetails { get; set; }
    }
}
