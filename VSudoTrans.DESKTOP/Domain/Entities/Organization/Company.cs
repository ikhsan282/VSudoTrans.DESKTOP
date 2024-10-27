using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Organization
{
    [Table("Company")]
    [DisplayName("Sekolah")]
    public class Company : BaseCodeName
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        [MaxLength(10)]
        public string CountryCode { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [MaxLength(300)]
        public string Website { get; set; }
        [MaxLength(1000)]
        public string Address { get; set; }
        public string Logo { get; set; }
        public string Watermark { get; set; }
        public string WatermarkPaid { get; set; }
        public string WatermarkUnpaid { get; set; }
        //public string SignatureHeadmaster { get; set; }


        public bool IsProduction { get; set; }
        public string Merchant { get; set; }
        public string SandboxServerKey { get; set; }
        public string SandboxClientKey { get; set; }
        public string ProductionServerKey { get; set; }
        public string ProductionClientKey { get; set; }


        [NotMapped]
        public string LogoUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(Logo))
                    return "https://vsudotechstorage.blob.core.windows.net/VSudoTrans/company/" + Logo;
                else
                    return string.Empty;
            }
            set
            {

            }
        }

        [NotMapped]
        public string WatermarkUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(Watermark))
                    return "https://vsudotechstorage.blob.core.windows.net/VSudoTrans/company/" + Watermark;
                else
                    return string.Empty;
            }
            set
            {

            }
        }

        [NotMapped]
        public string WatermarkPaidUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(WatermarkPaid))
                    return "https://vsudotechstorage.blob.core.windows.net/VSudoTrans/company/" + WatermarkPaid;
                else
                    return string.Empty;
            }
            set
            {

            }
        }

        [NotMapped]
        public string WatermarkUnpaidUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(WatermarkUnpaid))
                    return "https://vsudotechstorage.blob.core.windows.net/VSudoTrans/company/" + WatermarkUnpaid;
                else
                    return string.Empty;
            }
            set
            {

            }
        }
    }
}
