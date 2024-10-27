using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace Domain.Base
{
    public abstract class BaseIdInt
    {
        public int Id { get; set; }
    }

    public abstract class BaseIdGuid
    {
        public Guid Id { get; set; }
    }

    public abstract class BaseCodeName : BaseIdInt
    {
        [DisplayName("Kode")]
        [MaxLength(15)]
        public string Code { get; set; } 
        [DisplayName("Nama")]
        [MaxLength(255)]
        public string Name { get; set; } 

        [MaxLength(2000)]
        public string Note { get; set; }

        [MaxLength(255)]
        public string CreatedUser { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

        [MaxLength(255)]
        public string ModifiedUser { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }

    public abstract class BaseDomainDetail : BaseIdInt
    {
        [MaxLength(255)]
        public string CreatedUser { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

        [MaxLength(255)]
        public string ModifiedUser { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }

    public abstract class BaseCodeNameGuid : BaseIdGuid
    {
        [DisplayName("Kode")]
        [MaxLength(15)]
        public string Code { get; set; }
        [DisplayName("Nama")]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string Note { get; set; }

        [MaxLength(255)]
        public string CreatedUser { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

        [MaxLength(255)]
        public string ModifiedUser { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }

    public abstract class BaseDomainDetailGuid : BaseIdGuid
    {
        [MaxLength(255)]
        public string CreatedUser { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

        [MaxLength(255)]
        public string ModifiedUser { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
