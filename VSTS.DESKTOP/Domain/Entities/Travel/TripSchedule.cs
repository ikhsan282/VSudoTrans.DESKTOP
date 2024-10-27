using Domain.Base;
using Domain.Entities.Organization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Domain.Entities.HumanResource;
using Domain.Entities.Vehicle;
using Domain.Entities.Demography;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Travel
{
    [Table("TripSchedule")]
    [DisplayName("Jadwalkan Perjalanan")]
    public class TripSchedule : BaseDomainDetail
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        [MaxLength(40)]
        public string DocumentNumber { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicles Vehicle { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal? TotalDuration { get; set; }
        public int? PickupPointProvinceId { get; set; }
        [ForeignKey("PickupPointProvinceId")]
        public virtual Province PickupPointProvince { get; set; }

        public int? PickupPointCityId { get; set; }
        [ForeignKey("PickupPointCityId")]
        public virtual City PickupPointCity { get; set; }

        public int PickupPointDistrictId { get; set; }
        [ForeignKey("PickupPointDistrictId")]
        public virtual District PickupPointDistrict { get; set; }

        public int? DeliveryPointProvinceId { get; set; }
        [ForeignKey("DeliveryPointProvinceId")]
        public virtual Province DeliveryPointProvince { get; set; }

        public int? DeliveryPointCityId { get; set; }
        [ForeignKey("DeliveryPointCityId")]
        public virtual City DeliveryPointCity { get; set; }

        public int DeliveryPointDistrictId { get; set; }
        [ForeignKey("DeliveryPointDistrictId")]
        public virtual District DeliveryPointDistrict { get; set; }
        public virtual List<TripScheduleDetail> TripScheduleDetails { get; set; }
    }

    [Table("TripScheduleDetail")]
    [DisplayName("Jadwalkan Perjalanan Detail")]
    public class TripScheduleDetail : BaseDomainDetail
    {
        public int LineNumberPickup { get; set; } // Urutan
        public int LineNumberDelivery { get; set; } // Urutan
        public int TripScheduleId { get; set; }
        public virtual TripSchedule TripSchedule { get; set; }
        public int TravelTicketBookingId { get; set; }
        public virtual TravelTicketBooking TravelTicketBooking { get; set; }
    }
}
