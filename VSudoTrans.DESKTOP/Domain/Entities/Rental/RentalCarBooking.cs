using Domain.Base;
using Domain.Entities.Organization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Entities.Demography;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Transportation;
using Domain.Entities.Vehicle;
using System;
using Domain.Entities.HumanResource;
using System.Collections.Generic;

namespace Domain.Entities.Rental
{
    [Table("RentalCarBooking")]
    [DisplayName("Pemesanan Sewa Mobil")]
    public class RentalCarBooking : BaseDomainDetail
    {
        public RentalCarBooking()
        {
            RentalCarBookingEmployees = new HashSet<RentalCarBookingEmployee>();
            RentalCarBookingPayments = new HashSet<RentalCarBookingPayment>();
        }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        [MaxLength(40)]
        public string DocumentNumber { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
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
        public decimal TotalPrice { get; set; }
        public decimal BBM { get; set; }
        public decimal TotalOperationalCost { get; set; }
        public decimal TotalPayment { get; set; }
        public int CategoryVehicleId { get; set; }
        public virtual CategoryVehicle CategoryVehicle { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicles Vehicle { get; set; }
        public int PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }

        [MaxLength(2000)]
        public string Note { get; set; }
        public virtual ICollection<RentalCarBookingEmployee> RentalCarBookingEmployees { get; set; }
        public virtual ICollection<RentalCarBookingPayment> RentalCarBookingPayments { get; set; }
    }

    [Table("RentalCarBookingEmployee")]
    [DisplayName("Pemesanan Sewa Mobil Karyawan")]
    public class RentalCarBookingEmployee : BaseDomainDetail
    {
        public int RentalCarBookingId { get; set; }
        public virtual RentalCarBooking RentalCarBooking { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public decimal Amount { get; set; }
    }

    [Table("RentalCarBookingPayment")]
    [DisplayName("Pemesanan Sewa Mobil Payment")]
    public class RentalCarBookingPayment : BaseDomainDetail
    {
        public int RentalCarBookingId { get; set; }
        public virtual RentalCarBooking RentalCarBooking { get; set; }
        public EnumPaymentMethod PaymentMethod { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
