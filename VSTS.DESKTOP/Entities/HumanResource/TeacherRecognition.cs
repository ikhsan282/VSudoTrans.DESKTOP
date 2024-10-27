﻿using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Domain.Entities.HumanResource
{
    [Table("TeacherRecognition")]
    [DisplayName("Tanda Pengenal Teacher")]
    public class TeacherRecognition : BaseDomainDetail
    {
        public int TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public EnumRecognition Type { get; set; } // Type Recognation or Fingerprint
        public int Index { get; set; } //0 - 9, 0 jari kelingking kiri, 9 jadi kelingking kanan, default 10 for recognition
        public byte[]? FileTemplate { get; set; } = default!;// Untuk Menyimpan file face recog tujuan untuk identifikasi wajah
        [Column(TypeName = "varchar(MAX)")]
        public string? Template { get; set; } // Fingerprintnya berbentuk string base64
        public int? Size { get; set; } // Size Char Length Template
    }
}
