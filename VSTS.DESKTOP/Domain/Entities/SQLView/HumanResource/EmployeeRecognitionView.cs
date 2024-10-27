
namespace Domain.Entities.SQLView.HumanResource
{
    public class EmployeeRecognitionView
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public EnumRecognition Type { get; set; } // Type Recognation or Fingerprint
        public string IndexType { get; set; }
        public int IndexTotal { get; set; } //0 - 9, 0 jari kelingking kiri, 9 jadi kelingking kanan, default 10 for recognition
    }
}
