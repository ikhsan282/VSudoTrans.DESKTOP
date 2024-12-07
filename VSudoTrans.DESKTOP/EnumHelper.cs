using Domain;

namespace VSudoTrans.DESKTOP
{
    public static class EnumHelper
    {
        public static string EnumRentalCarEmployeeRegulationTypeToString(EnumRentalCarEmployeeRegulationType value)
        {
            switch (value)
            {
                case EnumRentalCarEmployeeRegulationType.Fix:
                    return "Tetap";
                case EnumRentalCarEmployeeRegulationType.Percentage:
                    return "Persentase";
                default:
                    return string.Format("{0} Description", value);
            }
        }

        public static string EnumParentalStatusToString(EnumParentalStatus value)
        {
            switch (value)
            {
                case EnumParentalStatus.Complete:
                    return "Lengkap";
                case EnumParentalStatus.Yatim:
                    return "Yatim";
                case EnumParentalStatus.Piatu:
                    return "Piatu";
                case EnumParentalStatus.YatimPiatu:
                    return "Yatim Piatu";
                default:
                    return string.Format("{0} Description", value);
            }
        }

        public static string EnumClassToString(EnumClass value)
        {
            switch (value)
            {
                case EnumClass.KelasMin2:
                    return "Kelompok Bermain";
                case EnumClass.KelasMin1:
                    return "TK A";
                case EnumClass.Kelas0:
                    return "TK B";
                case EnumClass.Kelas1:
                    return "SD Kelas 1";
                case EnumClass.Kelas2:
                    return "SD Kelas 2";
                case EnumClass.Kelas3:
                    return "SD Kelas 3";
                case EnumClass.Kelas4:
                    return "SD Kelas 4";
                case EnumClass.Kelas5:
                    return "SD Kelas 5";
                case EnumClass.Kelas6:
                    return "SD Kelas 6";
                case EnumClass.Kelas7:
                    return "SMP Kelas 1";
                case EnumClass.Kelas8:
                    return "SMP Kelas 2";
                case EnumClass.Kelas9:
                    return "SMP Kelas 3";
                case EnumClass.Kelas10:
                    return "SMA Kelas 1";
                case EnumClass.Kelas11:
                    return "SMA Kelas 2";
                case EnumClass.Kelas12:
                    return "SMA Kelas 3";
                default:
                    return string.Format("{0} Description", value);
            }
        }

        public static string EnumGroupAbsenceAssignmentTypeToString(EnumAbsenceType value)
        {
            switch (value)
            {
                case EnumAbsenceType.CT:
                    return "Cuti Tahunan";

                case EnumAbsenceType.CK:
                    return "Cuti Khusus";

                case EnumAbsenceType.S:
                    return "Sakit";

                case EnumAbsenceType.P:
                    return "Izin";

                case EnumAbsenceType.D:
                    return "Dinas";

                case EnumAbsenceType.H:
                    return "Hadir Kerja";

                case EnumAbsenceType.M:
                    return "Mangkir";

                case EnumAbsenceType.L:
                    return "Libur";

                default:
                    return "";
            }
        }

        public static string EnumTypeEducationToString(EnumTypeEducation value)
        {
            switch (value)
            {
                case EnumTypeEducation.KP:
                    return "Kelompok Bermain";
                case EnumTypeEducation.TK:
                    return "Taman Kanak-Kanak";
                case EnumTypeEducation.SD:
                    return "Perusahaan Dasar";
                case EnumTypeEducation.SDIT:
                    return "Perusahaan Dasar Islam Terpadu";
                case EnumTypeEducation.SMP:
                    return "Perusahaan Menengah Pertama";
                case EnumTypeEducation.MTS:
                    return "Madrasah Tsanawiyah";
                case EnumTypeEducation.SMA:
                    return "Perusahaan Menengah Atas";
                case EnumTypeEducation.MA:
                    return "Madrasah Aliyah";
                case EnumTypeEducation.SMK:
                    return "Perusahaan Menengah Kejuruan";
                case EnumTypeEducation.D1:
                    return "Diploma 1";
                case EnumTypeEducation.D2:
                    return "Diploma 2";
                case EnumTypeEducation.D3:
                    return "Diploma 3";
                case EnumTypeEducation.D4:
                    return "Diploma 4";
                case EnumTypeEducation.S1:
                    return "Sarjana (S1)";
                case EnumTypeEducation.S2:
                    return "Magister (S2)";
                case EnumTypeEducation.S3:
                    return "Doktor (S3)";
                case EnumTypeEducation.Prof:
                    return "Profesor";
                default:
                    return string.Format("{0} Description", value);
            }
        }

        public static string EnumYearlyAbsenceAssignmentTypeToString(EnumAbsenceAssignmentType value)
        {
            switch (value)
            {
                case EnumAbsenceAssignmentType.CT:
                    return "Cuti Tahunan Sehari Penuh";

                case EnumAbsenceAssignmentType.CTP:
                    return "Cuti Tahunan Setengah Hari Pagi";

                case EnumAbsenceAssignmentType.CTS:
                    return "Cuti Tahunan Setengah Hari Sore";

                default:
                    return "";
            }
        }
        public static string EnumSpecialAbsenceAssignmentTypeToString(EnumAbsenceAssignmentType value)
        {
            switch (value)
            {
                case EnumAbsenceAssignmentType.CH:
                    return "Cuti Haid";

                case EnumAbsenceAssignmentType.CPA:
                    return "Cuti Pengkhinatan/Pembatisan Anak";

                case EnumAbsenceAssignmentType.CKA:
                    return "Cuti Perkawinan Anak";

                case EnumAbsenceAssignmentType.CAS:
                    return "Cuti Anak Sunat";

                case EnumAbsenceAssignmentType.CKN:
                    return "Cuti Kawin";

                case EnumAbsenceAssignmentType.CKG:
                    return "Cuti Istri Melahirkan/Keguguran";

                case EnumAbsenceAssignmentType.CKM:
                    return "Cuti Suami/Istri, Anak, Orang Tua/Mertua Meninggal Dunia";

                case EnumAbsenceAssignmentType.CIM:
                    return "Cuti Saudara kandung/ipar meninggal dunia";

                case EnumAbsenceAssignmentType.CM:
                    return "Cuti Melahirkan";

                case EnumAbsenceAssignmentType.CNH:
                    return "Cuti Naik Haji";

                case EnumAbsenceAssignmentType.CW:
                    return "Cuti Wisuda";

                default:
                    return "";
            }
        }
        public static string EnumSickAbsenceAssignmentTypeToString(EnumAbsenceAssignmentType value)
        {
            switch (value)
            {
                case EnumAbsenceAssignmentType.S:
                    return "Sakit Sehari Penuh";

                case EnumAbsenceAssignmentType.SP:
                    return "Sakit Setengah Hari Pagi";

                case EnumAbsenceAssignmentType.SS:
                    return "Sakit Setengah Hari Sore";

                default:
                    return "";
            }
        }
        public static string EnumPermitAbsenceAssignmentTypeToString(EnumAbsenceAssignmentType value)
        {
            switch (value)
            {
                case EnumAbsenceAssignmentType.P:
                    return "Izin Sehari Penuh";

                case EnumAbsenceAssignmentType.PJK:
                    return "Izin Jam Khusus";

                case EnumAbsenceAssignmentType.PP:
                    return "Izin Setengah Hari Pagi";

                case EnumAbsenceAssignmentType.PS:
                    return "Izin Setengah Hari Sore";

                default:
                    return "";
            }
        }
        public static string EnumBusinessTripAbsenceAssignmentTypeToString(EnumAbsenceAssignmentType value)
        {
            switch (value)
            {
                case EnumAbsenceAssignmentType.D:
                    return "Pengajuan Dinas";

                case EnumAbsenceAssignmentType.D1:
                    return "Deklarasi Dinas";

                default:
                    return "";
            }
        }
        public static string EnumPresenceAbsenceAssignmentTypeToString(EnumAbsenceAssignmentType value)
        {
            switch (value)
            {
                case EnumAbsenceAssignmentType.H:
                    return "Hadir Kerja";

                //case EnumAbsenceAssignmentType.KM:
                //    return "Hadir Kerja Libur";

                case EnumAbsenceAssignmentType.HKE:
                    return "Hadir Kurang dari Sehari";

                case EnumAbsenceAssignmentType.HS:
                    return "Hadir Kerja Open Fingerprint";

                case EnumAbsenceAssignmentType.HSI:
                    return "Koreksi Kehadiran Masuk";

                case EnumAbsenceAssignmentType.HSO:
                    return "Koreksi Kehadiran Keluar";

                default:
                    return "";
            }
        }
        public static string EnumLeaveAbsenceAssignmentTypeToString(EnumAbsenceAssignmentType value)
        {
            switch (value)
            {
                case EnumAbsenceAssignmentType.M:
                    return "Mangkir";

                default:
                    return "";
            }
        }

        public static string EnumLiburAbsenceAssignmentTypeToString(EnumAbsenceAssignmentType value)
        {
            switch (value)
            {
                case EnumAbsenceAssignmentType.HL:
                    return "Hari Libur";

                default:
                    return "";
            }
        }

        public static string EnumPaymentStatusToString(EnumPaymentStatus value)
        {
            switch (value)
            {
                case EnumPaymentStatus.Unpaid:
                    return "Belum Dibayar";
                case EnumPaymentStatus.PartiallyPaid:
                    return "Dibayar Sebagian";
                case EnumPaymentStatus.Paid:
                    return "Lunas";
                case EnumPaymentStatus.Canceled:
                    return "Dibatalkan";
                case EnumPaymentStatus.Refund:
                    return "Pengembalian Dana";
                case EnumPaymentStatus.Overpaid:
                    return "Kelebihan Bayar";
                default:
                    return string.Format("{0} Description", value);
            }
        }

        public static string EnumPaymentMethodToString(EnumPaymentMethod value)
        {
            switch (value)
            {
                case EnumPaymentMethod.Cash:
                    return "Uang Tunai";
                case EnumPaymentMethod.Transfer:
                    return "Transfer";
                default:
                    return string.Format("{0} Description", value);
            }
        }

        public static string EnumPassengerTypeToString(EnumPassengerType value)
        {
            switch (value)
            {
                case EnumPassengerType.Person:
                    return "Orang";
                case EnumPassengerType.Animal:
                    return "Hewan";
                case EnumPassengerType.Food:
                    return "Makanan";
                case EnumPassengerType.Package:
                    return "Paket";
                case EnumPassengerType.Others:
                    return "Lain-lain";
                default:
                    return string.Format("{0} Description", value);
            }
        }

        public static string EnumStatusBookingToString(EnumStatusBooking value)
        {
            switch (value)
            {
                case EnumStatusBooking.New:
                    return "Baru";
                case EnumStatusBooking.Scheduled:
                    return "Dijadwalkan";
                case EnumStatusBooking.Pickup:
                    return "Penjemputan";
                case EnumStatusBooking.Delivery:
                    return "Pengantaran";
                case EnumStatusBooking.Canceled:
                    return "Dibatalkan";
                case EnumStatusBooking.FailedPickup:
                    return "Penjemputan Gagal";
                case EnumStatusBooking.Success:
                    return "Sukses";
                default:
                    return string.Format("{0} Description", value);
            }
        }

        public static string EnumReligionToString(EnumReligion value)
        {
            switch (value)
            {
                case EnumReligion.Islam:
                    return "Islam";
                case EnumReligion.Katholik:
                    return "Katholik";
                case EnumReligion.Protestan:
                    return "Protestan";
                case EnumReligion.Hindu:
                    return "Hindu";
                case EnumReligion.Budha:
                    return "Budha";
                case EnumReligion.Konghucu:
                    return "Konghucu";
                default:
                    return string.Format("{0} Description", value);
            }
        }
        public static string EnumBloodTypeToString(EnumBloodType value)
        {
            switch (value)
            {
                case EnumBloodType.A:
                    return "A";
                case EnumBloodType.B:
                    return "B";
                case EnumBloodType.AB:
                    return "AB";
                case EnumBloodType.O:
                    return "O";
                case EnumBloodType.AP:
                    return "A+";
                case EnumBloodType.BP:
                    return "B+";
                case EnumBloodType.ABP:
                    return "AB+";
                case EnumBloodType.OP:
                    return "O+";
                case EnumBloodType.AN:
                    return "AB+";
                case EnumBloodType.BN:
                    return "B-";
                case EnumBloodType.ABN:
                    return "AB-";
                case EnumBloodType.ON:
                    return "O-";
                default:
                    return string.Format("{0} Description", value);
            }
        }
        public static string EnumMaritalStatusToString(EnumMaritalStatus value)
        {
            switch (value)
            {
                case EnumMaritalStatus.Single:
                    return "Belum Menikah";
                case EnumMaritalStatus.Married:
                    return "Menikah";
                case EnumMaritalStatus.Divorced:
                    return "Cerai";
                default:
                    return string.Format("{0} Description", value);
            }
        }
        public static string EnumGenderToString(EnumGender value)
        {
            switch (value)
            {
                case EnumGender.Lakilaki:
                    return "Laki-laki";
                case EnumGender.Perempuan:
                    return "Perempuan";
                case EnumGender.LakiLakiPerempuan:
                    return "Laki-Laki dan Perempuan";
                default:
                    return string.Format("{0} Description", value);
            }
        }
        public static string EnumGenderAttendanceCodeToString(EnumGender value)
        {
            switch (value)
            {
                case EnumGender.Lakilaki:
                    return "Laki-Laki";
                case EnumGender.Perempuan:
                    return "Perempuan";
                case EnumGender.LakiLakiPerempuan:
                    return "Laki-Laki dan Perempuan";
                default:
                    return string.Format("{0} Description", value);
            }
        }

        public static string EnumPaymentTypeToString(EnumPaymentType value)
        {
            switch (value)
            {
                case EnumPaymentType.Cash:
                    return "Uang Tunai";
                case EnumPaymentType.Transfer:
                    return "Transfer";
                default:
                    return string.Format("{0} Description", value);
            }
        }

        public static string EnumDayTypeToString(EnumDayType value)
        {
            switch (value)
            {
                case EnumDayType.HariKerja:
                    return "Hari Kerja";
                case EnumDayType.HariKerjaPendek:
                    return "Hari Kerja Pendek";
                case EnumDayType.HariLibur:
                    return "Hari Libur";
                case EnumDayType.HariLiburNasional:
                    return "Hari Libur Nasional";
                case EnumDayType.HariLiburWilayah:
                    return "Hari Libur Wilayah";
                case EnumDayType.HariCutiBersama:
                    return "Hari Cuti Bersama";
                default:
                    return string.Format("{0} Description", value);
            }
        }

        public static string EnumApprovalStatusToString(EnumApprovalStatus value)
        {
            switch (value)
            {
                case EnumApprovalStatus.WaitingApproval:
                    return "Menunggu Persetujuan";
                case EnumApprovalStatus.Approved:
                    return "Disetujui";
                case EnumApprovalStatus.Reject:
                    return "Ditolak";
                case EnumApprovalStatus.FullyApproved:
                    return "Disetujui Sepenuhnya";
                default:
                    return string.Format("{0} Description", value);
            }
        }

        public static string EnumAbsenceTypeToString(EnumAbsenceType value)
        {
            switch (value)
            {
                case EnumAbsenceType.CT:
                    return "Cuti Tahunan";

                case EnumAbsenceType.CK:
                    return "Cuti Khusus";

                case EnumAbsenceType.S:
                    return "Sakit";

                case EnumAbsenceType.P:
                    return "Ijin";

                case EnumAbsenceType.D:
                    return "Dinas";

                case EnumAbsenceType.H:
                    return "Hadir";

                case EnumAbsenceType.M:
                    return "Mangkir";

                default:
                    return string.Format("{0} Description", value);

            }
        }

        public static string EnumAbsenceAssignmentTypeToString(EnumAbsenceAssignmentType value)
        {
            switch (value)
            {
                case EnumAbsenceAssignmentType.H:
                    return "Hadir";

                case EnumAbsenceAssignmentType.HKE:
                    return "Hadir Kurang dari Sehari";

                case EnumAbsenceAssignmentType.D:
                    return "Pengajuan Dinas";

                case EnumAbsenceAssignmentType.D1:
                    return "Deklarasi Dinas";

                case EnumAbsenceAssignmentType.M:
                    return "Mangkir";

                case EnumAbsenceAssignmentType.S:
                    return "Sakit Sehari Penuh";

                case EnumAbsenceAssignmentType.SP:
                    return "Sakit Setengah Hari Pagi";

                case EnumAbsenceAssignmentType.SS:
                    return "Sakit Setengah Hari Sore";

                case EnumAbsenceAssignmentType.P:
                    return "Ijin Sehari Penuh";

                case EnumAbsenceAssignmentType.PJK:
                    return "Ijin Jam Khusus";

                case EnumAbsenceAssignmentType.PP:
                    return "Ijin Setengah Hari Pagi";

                case EnumAbsenceAssignmentType.PS:
                    return "Ijin Setengah Hari Sore";

                case EnumAbsenceAssignmentType.CT:
                    return "Cuti Tahunan Sehari Penuh";

                case EnumAbsenceAssignmentType.CTP:
                    return "Cuti Tahunan Setengah Hari Pagi";

                case EnumAbsenceAssignmentType.CTS:
                    return "Cuti Tahunan Setengah Hari Sore";

                case EnumAbsenceAssignmentType.CH:
                    return "Cuti Haid";

                case EnumAbsenceAssignmentType.CPA:
                    return "Cuti Pengkhinatan/Pembatisan Anak";

                case EnumAbsenceAssignmentType.CKA:
                    return "Cuti Perkawinan Anak";

                case EnumAbsenceAssignmentType.CAS:
                    return "Cuti Anak Sunat";

                case EnumAbsenceAssignmentType.CKN:
                    return "Cuti Kawin";

                case EnumAbsenceAssignmentType.CKG:
                    return "Cuti Istri Melahirkan/Keguguran";

                case EnumAbsenceAssignmentType.CKM:
                    return "Cuti Suami/Istri, Anak, Orang Tua/Mertua Meninggal Dunia";

                case EnumAbsenceAssignmentType.CIM:
                    return "Cuti Saudara kandung/ipar meninggal dunia";

                case EnumAbsenceAssignmentType.CM:
                    return "Cuti Melahirkan";

                case EnumAbsenceAssignmentType.CNH:
                    return "Cuti Naik Haji";

                case EnumAbsenceAssignmentType.CW:
                    return "Cuti Wisuda";

                case EnumAbsenceAssignmentType.CKK:
                    return "Cuti Keguguran";

                case EnumAbsenceAssignmentType.CB:
                    return "Cuti Dibayar";

                case EnumAbsenceAssignmentType.HS:
                    return "Hadir Susulan";

                case EnumAbsenceAssignmentType.HSI:
                    return "Hadir Susulan Jam Masuk";

                case EnumAbsenceAssignmentType.HSO:
                    return "Hadir Susulan Jam Keluar";

                default:
                    return string.Format("{0} Description", value);

            }

        }

        public static string EnumRecognitionToString(EnumRecognition value)
        {
            switch (value)
            {
                case EnumRecognition.Deteksi:
                    return "Deteksi";

                case EnumRecognition.SidikJari:
                    return "Sidik Jari";

                default:
                    return string.Format("{0} Description", value);

            }
        }


        public static string EnumTaxStatusToString(EnumTaxStatus value)
        {
            switch (value)
            {
                case EnumTaxStatus.K0:
                    return "Kawin";

                case EnumTaxStatus.K1:
                    return "Kawin Anak 1";

                case EnumTaxStatus.K2:
                    return "Kawin Anak 2";

                case EnumTaxStatus.K3:
                    return "Kawin Anak 3";

                case EnumTaxStatus.TK:
                    return "Tidak Kawin";

                case EnumTaxStatus.TK1:
                    return "Tidak Kawin Anak 1";

                case EnumTaxStatus.TK2:
                    return "Tidak Kawin Anak 2";

                case EnumTaxStatus.TK3:
                    return "Tidak Kawin Anak 3";

                default:
                    return string.Format("{0} Description", value);

            }
        }

        public static string EnumTransactionIndicatorToString(EnumTransactionIndicator value)
        {
            switch (value)
            {
                case EnumTransactionIndicator.Kredit:
                    return "Penerimaan";
                case EnumTransactionIndicator.Debit:
                    return "Pengeluaran";
                default:
                    return string.Format("{0} Description", value);
            }
        }
    }
}
