using Domain.Base;
using Domain.Entities.Organization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Entities.Demography;
using System.Collections.Generic;

namespace Domain.Entities.Travel
{
    [Table("Rute")]
    [DisplayName("Rute")]
    public class Rute : BaseCodeName
    {
        public Rute()
        {
            PickupPointDistricts = new List<PickupPointDistrict>();
            DeliveryPointDistricts = new List<DeliveryPointDistrict>();
            TravelPrices = new List<TravelPrice>();
            RuteSchedules = new List<RuteSchedule>();
        }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int PickupPointCityId { get; set; }
        public virtual City PickupPointCity { get; set; }
        public virtual List<PickupPointDistrict> PickupPointDistricts { get; set; }
        public int DeliveryPointCityId { get; set; }
        public virtual City DeliveryPointCity { get; set; }
        public virtual List<DeliveryPointDistrict> DeliveryPointDistricts { get; set; }

        public virtual List<TravelPrice> TravelPrices { get; set; }

        public virtual List<RuteSchedule> RuteSchedules { get; set; }
    }

    [Table("TravelPrice")]
    [DisplayName("TravelPrice")]
    public class TravelPrice : BaseDomainDetail
    {
        public int RuteId { get; set; }
        public virtual Rute Rute { get; set; }
        public EnumPriceType PriceType { get; set; }
        public decimal MinPrice { get; set; } // Minimal
        public decimal Price { get; set; } // Normal
        public decimal MaxPrice { get; set; } // Maximal
        public int StartCapacitySeat { get; set; } //
        public int EndCapacitySeat { get; set; } // 
    }


    [Table("PickupPointDistrict")]
    [DisplayName("PickupPointDistrict")]
    public class PickupPointDistrict : BaseDomainDetail
    {
        public int RuteId { get; set; }
        public virtual Rute Rute { get; set; }
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
    }

    [Table("DeliveryPointDistrict")]
    [DisplayName("DeliveryPointDistrict")]
    public class DeliveryPointDistrict : BaseDomainDetail
    {
        public int RuteId { get; set; }
        public virtual Rute Rute { get; set; }
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
    }

    [Table("RuteSchedule")]
    [DisplayName("RuteSchedule")]
    public class RuteSchedule : BaseDomainDetail
    {
        public int RuteId { get; set; }
        public virtual Rute Rute { get; set; }
        public int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
