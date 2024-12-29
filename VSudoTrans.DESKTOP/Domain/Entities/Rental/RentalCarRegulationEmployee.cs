using Domain.Base;
using Domain.Entities.Organization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Rental
{
    [Table("RentalCarRegulationEmployee")]
    [DisplayName("Peraturan Karyawan Rental Mobil")]
    public class RentalCarRegulationEmployee : BaseDomainDetail
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IStartDate { get; set; }
        public int IEndDate { get; set; }
        [MaxLength(2000)]
        public string Note { get; set; }

        public RentalCarRegulationEmployee()
        {
            RentalCarRegulationEmployeeDetails = new HashSet<RentalCarRegulationEmployeeDetail>();
        }
        public virtual ICollection<RentalCarRegulationEmployeeDetail> RentalCarRegulationEmployeeDetails { get; set; }
    }

    [Table("RentalCarPaymentRegulationEmployee")]
    [DisplayName("Peraturan Karyawan Rental Mobil Detail")]
    public class RentalCarRegulationEmployeeDetail : BaseDomainDetail
    {
        public int RentalCarRegulationEmployeeId { get; set; }
        public virtual RentalCarRegulationEmployee RentalCarRegulationEmployee { get; set; }
        public EnumEmployeeRole EmployeeRole { get; set; }
        public EnumRentalCarEmployeeRegulationType Type { get; set; }
        public decimal Amount { get; set; }
    }
}
