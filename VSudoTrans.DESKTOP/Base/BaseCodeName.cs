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

    public abstract class BaseCodeName : BaseIdInt
    {
        //public int Id { get; set; }
        [DisplayName("Kode")]
        [MaxLength(15)]
        public string Code { get; set; } = default!;
        [DisplayName("Nama")]
        [MaxLength(255)]
        public string Name { get; set; } = default!;

        //public string DisplayMember { get; set; } = default!;

        [MaxLength(2000)]
        public string? Note { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [MaxLength(255)]
        public string? CreatedUser { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

        [MaxLength(255)]
        public string? ModifiedUser { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Timestamp]
        public byte[]? Version { get; set; }
    }

    public abstract class BaseDomainDemography
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string Code { get; set; } = default!;

        [MaxLength(255)]
        public string Name { get; set; } = default!;
    }

    public abstract class BaseDomainDetail
    {
        public int Id { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [MaxLength(255)]
        public string? CreatedUser { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

        [MaxLength(255)]
        public string? ModifiedUser { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Timestamp]
        public byte[]? Version { get; set; }
    }

    public abstract class BaseDomainDeep
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string? CreatedUser { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }

        [MaxLength(255)]
        public string? ModifiedUser { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Timestamp]
        public byte[]? Version { get; set; }
    }
}
