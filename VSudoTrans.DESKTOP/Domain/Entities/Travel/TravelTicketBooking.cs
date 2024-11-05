using Domain.Base;
using Domain.Entities.Organization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Entities.Demography;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Domain.Entities.Transportation;

namespace Domain.Entities.Travel
{
    [Table("TravelTicketBooking")]
    [DisplayName("Pemesanan Tiket Perjalanan")]
    public class TravelTicketBooking : BaseDomainDetail
    {
        public TravelTicketBooking()
        {
            TravelTicketBookingDetails = new List<TravelTicketBookingDetail>();
        }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        [MaxLength(40)]
        public string DocumentNumber { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int RuteId { get; set; }
        public virtual Rute Rute { get; set; }
        public virtual Schedule Schedule { get; set; }
        [MaxLength(2000)]
        public string PickupAddress { get; set; }

        public int? PickupPointProvinceId { get; set; }
        [ForeignKey("PickupPointProvinceId")]
        public virtual Province PickupPointProvince { get; set; }

        public int? PickupPointCityId { get; set; }
        [ForeignKey("PickupPointCityId")]
        public virtual City PickupPointCity { get; set; }

        public int PickupPointDistrictId { get; set; }
        [ForeignKey("PickupPointDistrictId")]
        public virtual District PickupPointDistrict { get; set; }

        [MaxLength(2000)]
        public string DeliveryAddress { get; set; }

        public int? DeliveryPointProvinceId { get; set; }
        [ForeignKey("DeliveryPointProvinceId")]
        public virtual Province DeliveryPointProvince { get; set; }

        public int? DeliveryPointCityId { get; set; }
        [ForeignKey("DeliveryPointCityId")]
        public virtual City DeliveryPointCity { get; set; }

        public int DeliveryPointDistrictId { get; set; }
        [ForeignKey("DeliveryPointDistrictId")]
        public virtual District DeliveryPointDistrict { get; set; }
        public int TotalTicket { get; set; }
        public decimal TotalPrice { get; set; }
        public EnumPaymentType PaymentType { get; set; } // Cash, Transfer
        public EnumStatusBooking Status { get; set; }
        public EnumPriceType PriceType { get; set; }

        [MaxLength(2000)]
        public string Note { get; set; }
        public virtual List<TravelTicketBookingDetail> TravelTicketBookingDetails { get; set; }
    }

    [Table("TravelTicketBookingDetail")]
    [DisplayName("Pemesanan Tiket Perjalanan Detail")]
    public class TravelTicketBookingDetail : BaseDomainDetail
    {
        public int TravelTicketBookingId { get; set; }
        public virtual TravelTicketBooking TravelTicketBooking { get; set; }
        public int PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }
        public EnumPassengerType PassengerType { get; set; }
        public decimal Price { get; set; }
    }
}
