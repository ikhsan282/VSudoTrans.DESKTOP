using Domain.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public enum EnumPassengerType : short
    {
        [Display(Name = "Orang")]
        Person = 0,
        [Display(Name = "Hewan")]
        Animal = 1,
        [Display(Name = "Makanan")]
        Food = 2,
        [Display(Name = "Paket Barang")]
        Package = 3,
        [Display(Name = "Others")]
        Others = 4
    }

    public enum EnumStatusBooking : short
    {
        [Display(Name = "Baru")]
        New = 0,
        [Display(Name = "Dijadwalkan")]
        Scheduled = 1,
        [Display(Name = "Penjemputan")]
        Pickup = 2,
        [Display(Name = "Pengantaran")]
        Delivery = 3,
        [Display(Name = "Dibatalkan")]
        Canceled = 4,
        [Display(Name = "Penjemputan Gagal")]
        FailedPickup = 5,
        [Display(Name = "Sukses")]
        Success = 6
    }

    public enum EnumPaymentType : short
    {
        [Display(Name = "Quick Response Code Indonesian Standard (QRIS) by Shopee Pay")]
        QRISShopeePay = 0,
        [Display(Name = "Quick Response Code Indonesian Standard (QRIS) by Gopay")]
        QRISGopay = 1,
        [Display(Name = "BCA Virtual Account")]
        BCA = 2,
        [Display(Name = "BRI Virtual Account")]
        BRI = 3,
        [Display(Name = "BNI Virtual Account")]
        BNI = 4,
        [Display(Name = "Permata Virtual Account")]
        Permata = 5,
        [Display(Name = "CIMB Niaga Virtual Account")]
        CIMB = 6,
        [Display(Name = "Mandiri Bill Payment")]
        Mandiri = 7,
        [Display(Name = "Uang Tunai")]
        Cash = 8,
        [Display(Name = "Transfer")]
        Transfer = 9
    }

    public enum EnumParentalStatus : short
    {
        [Display(Name = "Lengkap")]
        Complete = 0,    // Both parents are alive
        [Display(Name = "Yatim")]
        Yatim = 1,       // Father is deceased
        [Display(Name = "Piatu")]
        Piatu = 2,       // Mother is deceased
        [Display(Name = "Yatim Piatu")]
        YatimPiatu = 3   // Both parents are deceased
    }

    public enum EnumClass : short
    {
        [Display(Name = "Kelompok Bermain")]
        KelasMin2 = -2,
        [Display(Name = "TK A")]
        KelasMin1 = -1,
        [Display(Name = "TK B")]
        Kelas0 = 0,
        [Display(Name = "SD Kelas 1")]
        Kelas1 = 1,
        [Display(Name = "SD Kelas 2")]
        Kelas2 = 2,
        [Display(Name = "SD Kelas 3")]
        Kelas3 = 3,
        [Display(Name = "SD Kelas 4")]
        Kelas4 = 4,
        [Display(Name = "SD Kelas 5")]
        Kelas5 = 5,
        [Display(Name = "SD Kelas 6")]
        Kelas6 = 6,
        [Display(Name = "SMP Kelas 1")]
        Kelas7 = 7,
        [Display(Name = "SMP Kelas 2")]
        Kelas8 = 8,
        [Display(Name = "SMP Kelas 3")]
        Kelas9 = 9,
        [Display(Name = "SMA Kelas 1")]
        Kelas10 = 10,
        [Display(Name = "SMA Kelas 2")]
        Kelas11 = 11,
        [Display(Name = "SMA Kelas 3")]
        Kelas12 = 12
    }

    // Enum di C# value nya hanya bisa angka
    public static class EnumStatusImport
    {
        public const string Failed = "Failed";
        public const string Success = "Success";
        public const string SuccessfullyValidated = "Successfully Validated";
    }

    public enum EnumPaymentMethod : short
    {
        [Display(Name = "Uang Tunai")]
        Cash = 0,
        [Display(Name = "Transfer")]
        Transfer = 1,
    }

    public enum EnumTypeEducation : short
    {
        [Display(Name = "Kelompok Bermain")]
        KP = 0,
        [Display(Name = "Taman Kanak-Kanak")]
        TK,
        [Display(Name = "Perusahaan Dasar")]
        SD,
        [Display(Name = "Perusahaan Dasar Islam Terpadu")]
        SDIT,
        [Display(Name = "Perusahaan Menengah Pertama")]
        SMP,
        [Display(Name = "Madrasah Tsanawiyah")]
        MTS,
        [Display(Name = "Perusahaan Menengah Atas")]
        SMA,
        [Display(Name = "Madrasah Aliyah")]
        MA,
        [Display(Name = "Perusahaan Menengah Kejuruan")]
        SMK,
        [Display(Name = "Diploma 1")]
        D1,
        [Display(Name = "Diploma 2")]
        D2,
        [Display(Name = "Diploma 3")]
        D3,
        [Display(Name = "Diploma 4")]
        D4,
        [Display(Name = "Sarjana (S1)")]
        S1,
        [Display(Name = "Magister (S2)")]
        S2,
        [Display(Name = "Doktor (S3)")]
        S3,
        [Display(Name = "Profesor")]
        Prof
    }

    public enum EnumPaymentStatus : short
    {
        [Display(Name = "Tagihan")]
        Unpaid,
        [Display(Name = "Dibayar Sebagian")]
        PartiallyPaid,
        [Display(Name = "Lunas")]
        Paid,
        [Display(Name = "Dibatalkan")]
        Canceled, // Dibatalkan 
        [Display(Name = "Pengembalian Dana")]
        Refund, // Mengganti "Refund"
        [Display(Name = "Kelebihan Bayar")]
        Overpaid, // Menyesuaikan dengan "Kelebihan Bayar"
    }

    public enum EnumRecognition : short
    {
        [Display(Name = "Pendeteksian Wajah")]
        Deteksi,
        [Display(Name = "Sidik Jari")]
        SidikJari
    }

    public enum EnumDayType : short
    {
        [Display(Name = "Hari Kerja")]
        HariKerja,
        [Display(Name = "Hari Kerja Pendek")]
        HariKerjaPendek,
        [Display(Name = "Hari Libur")]
        HariLibur,
        [Display(Name = "Hari Libur Nasional")]
        HariLiburNasional,
        [Display(Name = "Hari Libur Wilayah")]
        HariLiburWilayah,
        [Display(Name = "Hari Cuti Bersama")]
        HariCutiBersama
    }

    public enum EnumAbsenceType : short
    {
        [Display(Name = "Cuti Tahunan")]
        CT = 0, // Cuti Tahunan
        [Display(Name = "Cuti Khusus")]
        CK = 1, // Cuti Khusus
        [Display(Name = "Sakit")]
        S = 2, // Sakit
        [Display(Name = "Ijin")]
        P = 3, // Ijin
        [Display(Name = "Dinas")]
        D = 4, // Dinas
        [Display(Name = "Hadir")]
        H = 5, // Hadir Kerja
        [Display(Name = "Mangkir")]
        M = 6, // Mangkir
        [Display(Name = "Libur")]
        L = 7, // Libur
    }

    public enum EnumAbsenceAssignmentType : short
    {
        //Hadir Kerja
        [Display(Name = "Hadir Kerja")]
        H,
        [Display(Name = "Hadir kurang dari sehari")]
        HKE,

        //Dinas
        [Display(Name = "Pengajuan Dinas")]
        D,
        [Display(Name = "Deklarasi Dinas")]
        D1,

        //Mangkir
        [Display(Name = "Mangkir (Tidak bekerja tanpa pemberitahuan terlebih dahulu)")]
        M,

        //Sakit
        [Display(Name = "Sakit Sehari Penuh")]
        S,
        [Display(Name = "Sakit Setengah Hari Pagi")]
        SP,
        [Display(Name = "Sakit Setengah Hari Sore")]
        SS,

        //Ijin
        [Display(Name = "Ijin Sehari Penuh")]
        P,
        [Display(Name = "Ijin Jam Khusus")]
        PJK,
        [Display(Name = "Ijin Setengah Hari Pagi")]
        PP,
        [Display(Name = "Ijin Setengah Hari Sore")]
        PS,

        //Cuti Tahunan
        [Display(Name = "Cuti Tahunan Sehari Penuh")]
        CT,
        [Display(Name = "Cuti Tahunan Setengah Hari Pagi")]
        CTP,
        [Display(Name = "Cuti Tahunan Setengah Hari Sore")]
        CTS,

        //Cuti Khusus
        [Display(Name = "Cuti Haid")]
        CH,
        [Display(Name = "Cuti Pengkhitanan/Pembabtisan Anak")]
        CPA,
        [Display(Name = "Cuti Perkawinan Anak")]
        CKA,
        [Display(Name = "Cuti Anak Sunat")]
        CAS,
        [Display(Name = "Cuti Kawin")]
        CKN,
        [Display(Name = "Cuti Istri Melahirkan/Keguguran")]
        CKG,
        [Display(Name = "Cuti Suami/Istri, Anak, Orang Tua/Mertua Meninggal Dunia")]
        CKM,
        [Display(Name = "Cuti Saudara kandung/ipar meninggal dunia")]
        CIM,
        [Display(Name = "Cuti Melahirkan")]
        CM,
        [Display(Name = "Cuti Naik Haji")]
        CNH,
        [Display(Name = "Cuti Wisuda")]
        CW,
        [Display(Name = "Cuti Keguguran")]
        CKK,
        [Display(Name = "Cuti Dibayar")]
        CB,

        //Hadir Kerja
        [Display(Name = "Hadir Susulan")]
        HS,
        [Display(Name = "Hadir Susulan Jam Masuk")]
        HSI,
        [Display(Name = "Hadir Susulan Jam Keluar")]
        HSO,

        //Hadir Kerja Libur
        [Display(Name = "Hadir Kerja Libur")]
        KL = 31,

        //Hari Libur
        [Display(Name = "Hari Libur")]
        HL = 32,
        [Display(Name = "Hari Libur Nasional")]
        HLN = 33,
        [Display(Name = "Hari Libur Wilayah")]
        HLW = 34,


        //Hadir Kerja
        [Display(Name = "Hadir Kerja Open Fingerprint")]
        KOF = 35,

        //Hadir Kerja
        [Display(Name = "Koreksi Kehadiran Masuk")]
        KCI = 36,
        [Display(Name = "Koreksi Kehadiran Keluar")]
        KCO = 37,
    }

    public enum EnumApprovalStatus : short
    {
        [Display(Name = "Menunggu Persetujuan")]
        WaitingApproval = 0,
        [Display(Name = "Disetujui")]
        Approved = 1,
        [Display(Name = "Ditolak")]
        Reject = 2,
        [Display(Name = "Disetujui Sepenuhnya")]
        FullyApproved = 3
    }

    public enum EnumGender : short
    {
        [Display(Name = "Laki-laki")]
        Lakilaki = 0,
        [Display(Name = "Perempuan")]
        Perempuan = 1,
        [Display(Name = "Laki-laki dan Perempuan")]
        LakiLakiPerempuan = 2
    }

    public enum EnumReligion : short
    {
        [Display(Name = "Islam")]
        Islam = 0,
        [Display(Name = "Katholik")]
        Katholik = 1,
        [Display(Name = "Protestan")]
        Protestan = 2,
        [Display(Name = "Hindu")]
        Hindu = 3,
        [Display(Name = "Budha")]
        Budha = 4,
        [Display(Name = "Konghucu")]
        Konghucu = 5
    }

    public enum EnumTaxStatus : short
    {
        [Display(Name = "Kawin")]
        K0 = 0,
        [Display(Name = "Kawin Anak 1")]
        K1 = 1,
        [Display(Name = "Kawin Anak 2")]
        K2 = 2,
        [Display(Name = "Kawin Anak 3")]
        K3 = 3,
        [Display(Name = "Tidak Kawin")]
        TK = 4,
        [Display(Name = "Tidak Kawin Anak 1")]
        TK1 = 5,
        [Display(Name = "Tidak Kawin Anak 2")]
        TK2 = 6,
        [Display(Name = "Tidak Kawin Anak 3")]
        TK3 = 7
    }

    public enum EnumMaritalStatus : short
    {
        [Display(Name = "Belum Menikah")]
        Single = 0,

        [Display(Name = "Menikah")]
        Married = 1,

        [Display(Name = "Cerai")]
        Divorced = 2
    }

    public enum EnumBloodType : short
    {
        [Display(Name = "A")]
        A = 0,
        [Display(Name = "B")]
        B = 1,
        [Display(Name = "AB")]
        AB = 2,
        [Display(Name = "O")]
        O = 3,
        [Display(Name = "A+")]
        AP = 4,
        [Display(Name = "B+")]
        BP = 5,
        [Display(Name = "AB+")]
        ABP = 6,
        [Display(Name = "O+")]
        OP = 7,
        [Display(Name = "A-")]
        AN = 8,
        [Display(Name = "B-")]
        BN = 9,
        [Display(Name = "AB-")]
        ABN = 10,
        [Display(Name = "O-")]
        ON = 11,
    }

    public enum EnumTransactionIndicator : short
    {
        [Display(Name = "Penerimaan")]
        Kredit = 0,
        [Display(Name = "Pengeluaran")]
        Debit = 1
    }

    public class CountryCode
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Example { get; set; }
    }

    public static class DataCountryCodes
    {
        public static List<CountryCode> GetCountryCodes()
        {
            var countryCodeList = new List<CountryCode>()
            {
                //new CountryCode()
                //{
                //    Id = 93,
                //    Code = "93",
                //    Name = "Afghanistan",
                //    Example = "931234567890"
                //},
                //new CountryCode()
                //{
                //    Id = 355,
                //    Code = "355",
                //    Name = "Albania",
                //    Example = "35542123456"
                //},
                //new CountryCode()
                //{
                //    Id = 213,
                //    Code = "213",
                //    Name = "Algeria",
                //    Example = "213234567890"
                //},
                //new CountryCode()
                //{
                //    Id = 376,
                //    Code = "376",
                //    Name = "Andorra",
                //    Example = "376601234"
                //},
                //new CountryCode()
                //{
                //    Id = 244,
                //    Code = "244",
                //    Name = "Angola",
                //    Example = "244923123456"
                //},
                //new CountryCode()
                //{
                //    Id = 54,
                //    Code = "54",
                //    Name = "Argentina",
                //    Example = "5491123456789"
                //},
                //new CountryCode()
                //{
                //    Id = 374,
                //    Code = "374",
                //    Name = "Armenia",
                //    Example = "37491234567"
                //},
                //new CountryCode()
                //{
                //    Id = 61,
                //    Code = "61",
                //    Name = "Australia",
                //    Example = "61212345678"
                //},
                //new CountryCode()
                //{
                //    Id = 43,
                //    Code = "43",
                //    Name = "Austria",
                //    Example = "436601234567"
                //},
                //new CountryCode()
                //{
                //    Id = 994,
                //    Code = "994",
                //    Name = "Azerbaijan",
                //    Example = "994501234567"
                //},
                //new CountryCode()
                //{
                //    Id = 1242,
                //    Code = "1242",
                //    Name = "Bahamas",
                //    Example = "12425551234"
                //},
                //new CountryCode()
                //{
                //    Id = 973,
                //    Code = "973",
                //    Name = "Bahrain",
                //    Example = "97333331234"
                //},
                //new CountryCode()
                //{
                //    Id = 880,
                //    Code = "880",
                //    Name = "Bangladesh",
                //    Example = "8801712345678"
                //},
                //new CountryCode()
                //{
                //    Id = 1246,
                //    Code = "1246",
                //    Name = "Barbados",
                //    Example = "12462531234"
                //},
                //new CountryCode()
                //{
                //    Id = 375,
                //    Code = "375",
                //    Name = "Belarus",
                //    Example = "375291234567"
                //},
                //new CountryCode()
                //{
                //    Id = 32,
                //    Code = "32",
                //    Name = "Belgium",
                //    Example = "32471234567"
                //},
                //new CountryCode()
                //{
                //    Id = 501,
                //    Code = "501",
                //    Name = "Belize",
                //    Example = "5016666666"
                //},
                //new CountryCode()
                //{
                //    Id = 229,
                //    Code = "229",
                //    Name = "Benin",
                //    Example = "22997123456"
                //},
                //new CountryCode()
                //{
                //    Id = 975,
                //    Code = "975",
                //    Name = "Bhutan",
                //    Example = "97517123456"
                //},
                //new CountryCode()
                //{
                //    Id = 591,
                //    Code = "591",
                //    Name = "Bolivia",
                //    Example = "59171234567"
                //},
                //new CountryCode()
                //{
                //    Id = 387,
                //    Code = "387",
                //    Name = "Bosnia and Herzegovina",
                //    Example = "38761123456"
                //},
                //new CountryCode()
                //{
                //    Id = 267,
                //    Code = "267",
                //    Name = "Botswana",
                //    Example = "26771123456"
                //},
                //new CountryCode()
                //{
                //    Id = 55,
                //    Code = "55",
                //    Name = "Brazil",
                //    Example = "5511987654321"
                //},
                //new CountryCode()
                //{
                //    Id = 673,
                //    Code = "673",
                //    Name = "Brunei",
                //    Example = "6738234567"
                //},
                //new CountryCode()
                //{
                //    Id = 359,
                //    Code = "359",
                //    Name = "Bulgaria",
                //    Example = "359881234567"
                //},
                //new CountryCode()
                //{
                //    Id = 226,
                //    Code = "226",
                //    Name = "Burkina Faso",
                //    Example = "22670123456"
                //},
                //new CountryCode()
                //{
                //    Id = 257,
                //    Code = "257",
                //    Name = "Burundi",
                //    Example = "25779123456"
                //},
                //new CountryCode()
                //{
                //    Id = 855,
                //    Code = "855",
                //    Name = "Cambodia",
                //    Example = "85512345678"
                //},
                //new CountryCode()
                //{
                //    Id = 237,
                //    Code = "237",
                //    Name = "Cameroon",
                //    Example = "237671234567"
                //},
                //new CountryCode()
                //{
                //    Id = 1,
                //    Code = "1",
                //    Name = "Canada",
                //    Example = "14165551234"
                //},
                //new CountryCode()
                //{
                //    Id = 238,
                //    Code = "238",
                //    Name = "Cape Verde",
                //    Example = "2389666666"
                //},
                //new CountryCode()
                //{
                //    Id = 236,
                //    Code = "236",
                //    Name = "Central African Republic",
                //    Example = "23670123456"
                //},
                //new CountryCode()
                //{
                //    Id = 235,
                //    Code = "235",
                //    Name = "Chad",
                //    Example = "23566123456"
                //},
                //new CountryCode()
                //{
                //    Id = 56,
                //    Code = "56",
                //    Name = "Chile",
                //    Example = "56912345678"
                //},
                //new CountryCode()
                //{
                //    Id = 86,
                //    Code = "86",
                //    Name = "China",
                //    Example = "8613123456789"
                //},
                //new CountryCode()
                //{
                //    Id = 57,
                //    Code = "57",
                //    Name = "Colombia",
                //    Example = "573211234567"
                //},
                //new CountryCode()
                //{
                //    Id = 269,
                //    Code = "269",
                //    Name = "Comoros",
                //    Example = "26977123456"
                //},
                //new CountryCode()
                //{
                //    Id = 242,
                //    Code = "242",
                //    Name = "Congo (Brazzaville)",
                //    Example = "242061234567"
                //},
                //new CountryCode()
                //{
                //    Id = 243,
                //    Code = "243",
                //    Name = "Congo (Kinshasa)",
                //    Example = "243991234567"
                //},
                //new CountryCode()
                //{
                //    Id = 506,
                //    Code = "506",
                //    Name = "Costa Rica",
                //    Example = "50683123456"
                //},
                //new CountryCode()
                //{
                //    Id = 385,
                //    Code = "385",
                //    Name = "Croatia",
                //    Example = "385912345678"
                //},
                //new CountryCode()
                //{
                //    Id = 53,
                //    Code = "53",
                //    Name = "Cuba",
                //    Example = "5351234567"
                //},
                //new CountryCode()
                //{
                //    Id = 357,
                //    Code = "357",
                //    Name = "Cyprus",
                //    Example = "35796123456"
                //},
                //new CountryCode()
                //{
                //    Id = 420,
                //    Code = "420",
                //    Name = "Czech Republic",
                //    Example = "420601123456"
                //},
                //new CountryCode()
                //{
                //    Id = 45,
                //    Code = "45",
                //    Name = "Denmark",
                //    Example = "4512345678"
                //},
                //new CountryCode()
                //{
                //    Id = 253,
                //    Code = "253",
                //    Name = "Djibouti",
                //    Example = "25377123456"
                //},
                //new CountryCode()
                //{
                //    Id = 1767,
                //    Code = "1767",
                //    Name = "Dominica",
                //    Example = "17672251234"
                //},
                //new CountryCode()
                //{
                //    Id = 1809,
                //    Code = "1809",
                //    Name = "Dominican Republic",
                //    Example = "18095551234"
                //},
                //new CountryCode()
                //{
                //    Id = 670,
                //    Code = "670",
                //    Name = "East Timor (Timor-Leste)",
                //    Example = "67077234567"
                //},
                //new CountryCode()
                //{
                //    Id = 593,
                //    Code = "593",
                //    Name = "Ecuador",
                //    Example = "593991234567"
                //},
                //new CountryCode()
                //{
                //    Id = 20,
                //    Code = "20",
                //    Name = "Egypt",
                //    Example = "201012345678"
                //},
                //new CountryCode()
                //{
                //    Id = 503,
                //    Code = "503",
                //    Name = "El Salvador",
                //    Example = "50370123456"
                //},
                //new CountryCode()
                //{
                //    Id = 240,
                //    Code = "240",
                //    Name = "Equatorial Guinea",
                //    Example = "240333123456"
                //},
                //new CountryCode()
                //{
                //    Id = 291,
                //    Code = "291",
                //    Name = "Eritrea",
                //    Example = "2917123456"
                //},
                //new CountryCode()
                //{
                //    Id = 372,
                //    Code = "372",
                //    Name = "Estonia",
                //    Example = "37251234567"
                //},
                //new CountryCode()
                //{
                //    Id = 251,
                //    Code = "251",
                //    Name = "Ethiopia",
                //    Example = "251911234567"
                //},
                //new CountryCode()
                //{
                //    Id = 679,
                //    Code = "679",
                //    Name = "Fiji",
                //    Example = "6799991234"
                //},
                //new CountryCode()
                //{
                //    Id = 358,
                //    Code = "358",
                //    Name = "Finland",
                //    Example = "358501234567"
                //},
                //new CountryCode()
                //{
                //    Id = 33,
                //    Code = "33",
                //    Name = "France",
                //    Example = "33612345678"
                //},
                //new CountryCode()
                //{
                //    Id = 241,
                //    Code = "241",
                //    Name = "Gabon",
                //    Example = "24106123456"
                //},
                //new CountryCode()
                //{
                //    Id = 220,
                //    Code = "220",
                //    Name = "Gambia",
                //    Example = "2207712345"
                //},
                //new CountryCode()
                //{
                //    Id = 995,
                //    Code = "995",
                //    Name = "Georgia",
                //    Example = "995595123456"
                //},
                //new CountryCode()
                //{
                //    Id = 49,
                //    Code = "49",
                //    Name = "Germany",
                //    Example = "4915112345678"
                //},
                //new CountryCode()
                //{
                //    Id = 233,
                //    Code = "233",
                //    Name = "Ghana",
                //    Example = "233201234567"
                //},
                //new CountryCode()
                //{
                //    Id = 30,
                //    Code = "30",
                //    Name = "Greece",
                //    Example = "306912345678"
                //},
                //new CountryCode()
                //{
                //    Id = 1473,
                //    Code = "1473",
                //    Name = "Grenada",
                //    Example = "14734401234"
                //},
                //new CountryCode()
                //{
                //    Id = 502,
                //    Code = "502",
                //    Name = "Guatemala",
                //    Example = "50251234567"
                //},
                //new CountryCode()
                //{
                //    Id = 224,
                //    Code = "224",
                //    Name = "Guinea",
                //    Example = "224620123456"
                //},
                //new CountryCode()
                //{
                //    Id = 245,
                //    Code = "245",
                //    Name = "Guinea-Bissau",
                //    Example = "245955123456"
                //},
                //new CountryCode()
                //{
                //    Id = 592,
                //    Code = "592",
                //    Name = "Guyana",
                //    Example = "5926211234"
                //},
                //new CountryCode()
                //{
                //    Id = 509,
                //    Code = "509",
                //    Name = "Haiti",
                //    Example = "50934123456"
                //},
                //new CountryCode()
                //{
                //    Id = 504,
                //    Code = "504",
                //    Name = "Honduras",
                //    Example = "50499991234"
                //},
                //new CountryCode()
                //{
                //    Id = 36,
                //    Code = "36",
                //    Name = "Hungary",
                //    Example = "36301234567"
                //},
                //new CountryCode()
                //{
                //    Id = 354,
                //    Code = "354",
                //    Name = "Iceland",
                //    Example = "3546111234"
                //},
                //new CountryCode()
                //{
                //    Id = 91,
                //    Code = "91",
                //    Name = "India",
                //    Example = "919876543210"
                //},
                new CountryCode()
                {
                    Id = "62",
                    Code = "62",
                    Name = "Indonesia",
                    Example = "6281234567890"
                },
                new CountryCode()
                {
                    Id = "02",
                    Code = "02",
                    Name = "Indonesia",
                    Example = "021215556"
                },
                //new CountryCode()
                //{
                //    Id = 98,
                //    Code = "98",
                //    Name = "Iran",
                //    Example = "989121234567"
                //},
                //new CountryCode()
                //{
                //    Id = 964,
                //    Code = "964",
                //    Name = "Iraq",
                //    Example = "9647701234567"
                //},
                //new CountryCode()
                //{
                //    Id = 353,
                //    Code = "353",
                //    Name = "Ireland",
                //    Example = "353861234567"
                //},
                //new CountryCode()
                //{
                //    Id = 972,
                //    Code = "972",
                //    Name = "Israel",
                //    Example = "972501234567"
                //},
                //new CountryCode()
                //{
                //    Id = 39,
                //    Code = "39",
                //    Name = "Italy",
                //    Example = "393331234567"
                //},
                //new CountryCode()
                //{
                //    Id = 225,
                //    Code = "225",
                //    Name = "Ivory Coast",
                //    Example = "2250912345678"
                //},
                //new CountryCode()
                //{
                //    Id = 1876,
                //    Code = "1876",
                //    Name = "Jamaica",
                //    Example = "18765551234"
                //},
                //new CountryCode()
                //{
                //    Id = 81,
                //    Code = "81",
                //    Name = "Japan",
                //    Example = "819012345678"
                //},
                //new CountryCode()
                //{
                //    Id = 962,
                //    Code = "962",
                //    Name = "Jordan",
                //    Example = "962790123456"
                //},
                //new CountryCode()
                //{
                //    Id = 7,
                //    Code = "7",
                //    Name = "Kazakhstan",
                //    Example = "77011234567"
                //},
                //new CountryCode()
                //{
                //    Id = 254,
                //    Code = "254",
                //    Name = "Kenya",
                //    Example = "254712123456"
                //},
                //new CountryCode()
                //{
                //    Id = 686,
                //    Code = "686",
                //    Name = "Kiribati",
                //    Example = "68673012345"
                //},
                //new CountryCode()
                //{
                //    Id = 383,
                //    Code = "383",
                //    Name = "Kosovo",
                //    Example = "38344123456"
                //},
                //new CountryCode()
                //{
                //    Id = 965,
                //    Code = "965",
                //    Name = "Kuwait",
                //    Example = "96550012345"
                //},
                //new CountryCode()
                //{
                //    Id = 996,
                //    Code = "996",
                //    Name = "Kyrgyzstan",
                //    Example = "996770123456"
                //},
                //new CountryCode()
                //{
                //    Id = 856,
                //    Code = "856",
                //    Name = "Laos",
                //    Example = "8562012345678"
                //},
                //new CountryCode()
                //{
                //    Id = 371,
                //    Code = "371",
                //    Name = "Latvia",
                //    Example = "37129123456"
                //},
                //new CountryCode()
                //{
                //    Id = 961,
                //    Code = "961",
                //    Name = "Lebanon",
                //    Example = "9613123456"
                //},
                //new CountryCode()
                //{
                //    Id = 266,
                //    Code = "266",
                //    Name = "Lesotho",
                //    Example = "266512345678"
                //},
                //new CountryCode()
                //{
                //    Id = 231,
                //    Code = "231",
                //    Name = "Liberia",
                //    Example = "23161234567"
                //},
                //new CountryCode()
                //{
                //    Id = 218,
                //    Code = "218",
                //    Name = "Libya",
                //    Example = "218911234567"
                //},
                //new CountryCode()
                //{
                //    Id = 423,
                //    Code = "423",
                //    Name = "Liechtenstein",
                //    Example = "4236601234"
                //},
                //new CountryCode()
                //{
                //    Id = 370,
                //    Code = "370",
                //    Name = "Lithuania",
                //    Example = "37061234567"
                //},
                //new CountryCode()
                //{
                //    Id = 352,
                //    Code = "352",
                //    Name = "Luxembourg",
                //    Example = "352621123456"
                //},
                //new CountryCode()
                //{
                //    Id = 389,
                //    Code = "389",
                //    Name = "North Macedonia (formerly Macedonia)",
                //    Example = "38970123456"
                //},
                //new CountryCode()
                //{
                //    Id = 261,
                //    Code = "261",
                //    Name = "Madagascar",
                //    Example = "261321234567"
                //},
                //new CountryCode()
                //{
                //    Id = 265,
                //    Code = "265",
                //    Name = "Malawi",
                //    Example = "265991234567"
                //},
                //new CountryCode()
                //{
                //    Id = 60,
                //    Code = "60",
                //    Name = "Malaysia",
                //    Example = "60123456789"
                //},
                //new CountryCode()
                //{
                //    Id = 960,
                //    Code = "960",
                //    Name = "Maldives",
                //    Example = "9607771234"
                //},
                //new CountryCode()
                //{
                //    Id = 223,
                //    Code = "223",
                //    Name = "Mali",
                //    Example = "22376123456"
                //},
                //new CountryCode()
                //{
                //    Id = 356,
                //    Code = "356",
                //    Name = "Malta",
                //    Example = "35699123456"
                //},
                //new CountryCode()
                //{
                //    Id = 692,
                //    Code = "692",
                //    Name = "Marshall Islands",
                //    Example = "6922351234"
                //},
                //new CountryCode()
                //{
                //    Id = 222,
                //    Code = "222",
                //    Name = "Mauritania",
                //    Example = "22222123456"
                //},
                //new CountryCode()
                //{
                //    Id = 230,
                //    Code = "230",
                //    Name = "Mauritius",
                //    Example = "23051234567"
                //},
                //new CountryCode()
                //{
                //    Id = 52,
                //    Code = "52",
                //    Name = "Mexico",
                //    Example = "525512345678"
                //},
                //new CountryCode()
                //{
                //    Id = 691,
                //    Code = "691",
                //    Name = "Micronesia",
                //    Example = "6919201234"
                //},
                //new CountryCode()
                //{
                //    Id = 373,
                //    Code = "373",
                //    Name = "Moldova",
                //    Example = "37369123456"
                //},
                //new CountryCode()
                //{
                //    Id = 377,
                //    Code = "377",
                //    Name = "Monaco",
                //    Example = "37761234567"
                //},
                //new CountryCode()
                //{
                //    Id = 976,
                //    Code = "976",
                //    Name = "Mongolia",
                //    Example = "97688123456"
                //},
                //new CountryCode()
                //{
                //    Id = 382,
                //    Code = "382",
                //    Name = "Montenegro",
                //    Example = "38267123456"
                //},
                //new CountryCode()
                //{
                //    Id = 212,
                //    Code = "212",
                //    Name = "Morocco",
                //    Example = "212612345678"
                //},
                //new CountryCode()
                //{
                //    Id = 258,
                //    Code = "258",
                //    Name = "Mozambique",
                //    Example = "258821234567"
                //},
                //new CountryCode()
                //{
                //    Id = 95,
                //    Code = "95",
                //    Name = "Myanmar (Burma)",
                //    Example = "9591234567"
                //},
                //new CountryCode()
                //{
                //    Id = 264,
                //    Code = "264",
                //    Name = "Namibia",
                //    Example = "264811234567"
                //},
                //new CountryCode()
                //{
                //    Id = 674,
                //    Code = "674",
                //    Name = "Nauru",
                //    Example = "6745551234"
                //},
                //new CountryCode()
                //{
                //    Id = 977,
                //    Code = "977",
                //    Name = "Nepal",
                //    Example = "9779812345678"
                //},
                //new CountryCode()
                //{
                //    Id = 31,
                //    Code = "31",
                //    Name = "Netherlands",
                //    Example = "31612345678"
                //},
                //new CountryCode()
                //{
                //    Id = 64,
                //    Code = "64",
                //    Name = "New Zealand",
                //    Example = "64211234567"
                //},
                //new CountryCode()
                //{
                //    Id = 505,
                //    Code = "505",
                //    Name = "Nicaragua",
                //    Example = "50581234567"
                //},
                //new CountryCode()
                //{
                //    Id = 227,
                //    Code = "227",
                //    Name = "Niger",
                //    Example = "22793123456"
                //},
                //new CountryCode()
                //{
                //    Id = 234,
                //    Code = "234",
                //    Name = "Nigeria",
                //    Example = "2348123456789"
                //},
                //new CountryCode()
                //{
                //    Id = 850,
                //    Code = "850",
                //    Name = "North Korea",
                //    Example = "85021234567"
                //},
                //new CountryCode()
                //{
                //    Id = 47,
                //    Code = "47",
                //    Name = "Norway",
                //    Example = "4791234567"
                //},
                //new CountryCode()
                //{
                //    Id = 968,
                //    Code = "968",
                //    Name = "Oman",
                //    Example = "96892123456"
                //},
                //new CountryCode()
                //{
                //    Id = 923,
                //    Code = "923",
                //    Name = "Pakistan",
                //    Example = "923001234567"
                //},
                //new CountryCode()
                //{
                //    Id = 680,
                //    Code = "680",
                //    Name = "Palau",
                //    Example = "6806201234"
                //},
                //new CountryCode()
                //{
                //    Id = 970,
                //    Code = "970",
                //    Name = "Palestine",
                //    Example = "970591234567"
                //},
                //new CountryCode()
                //{
                //    Id = 507,
                //    Code = "507",
                //    Name = "Panama",
                //    Example = "50761234567"
                //},
                //new CountryCode()
                //{
                //    Id = 675,
                //    Code = "675",
                //    Name = "Papua New Guinea",
                //    Example = "67570123456"
                //},
                //new CountryCode()
                //{
                //    Id = 595,
                //    Code = "595",
                //    Name = "Paraguay",
                //    Example = "595981123456"
                //},
                //new CountryCode()
                //{
                //    Id = 51,
                //    Code = "51",
                //    Name = "Peru",
                //    Example = "51912345678"
                //},
                //new CountryCode()
                //{
                //    Id = 63,
                //    Code = "63",
                //    Name = "Philippines",
                //    Example = "639123456789"
                //},
                //new CountryCode()
                //{
                //    Id = 48,
                //    Code = "48",
                //    Name = "Poland",
                //    Example = "48512345678"
                //},
                //new CountryCode()
                //{
                //    Id = 351,
                //    Code = "351",
                //    Name = "Portugal",
                //    Example = "351912345678"
                //},
                //new CountryCode()
                //{
                //    Id = 974,
                //    Code = "974",
                //    Name = "Qatar",
                //    Example = "97433123456"
                //},
                //new CountryCode()
                //{
                //    Id = 40,
                //    Code = "40",
                //    Name = "Romania",
                //    Example = "40721123456"
                //},
                //new CountryCode()
                //{
                //    Id = 7,
                //    Code = "7",
                //    Name = "Russia",
                //    Example = "79011234567"
                //},
                //new CountryCode()
                //{
                //    Id = 250,
                //    Code = "250",
                //    Name = "Rwanda",
                //    Example = "250721234567"
                //},
                //new CountryCode()
                //{
                //    Id = 1869,
                //    Code = "1869",
                //    Name = "Saint Kitts and Nevis",
                //    Example = "18697651234"
                //},
                //new CountryCode()
                //{
                //    Id = 1758,
                //    Code = "1758",
                //    Name = "Saint Lucia",
                //    Example = "17582851234"
                //},
                //new CountryCode()
                //{
                //    Id = 1784,
                //    Code = "1784",
                //    Name = "Saint Vincent and the Grenadines",
                //    Example = "17844301234"
                //},
                //new CountryCode()
                //{
                //    Id = 685,
                //    Code = "685",
                //    Name = "Samoa",
                //    Example = "6857212345"
                //},
                //new CountryCode()
                //{
                //    Id = 378,
                //    Code = "378",
                //    Name = "San Marino",
                //    Example = "37866123456"
                //},
                //new CountryCode()
                //{
                //    Id = 239,
                //    Code = "239",
                //    Name = "Sao Tome and Principe",
                //    Example = "239981234"
                //},
                //new CountryCode()
                //{
                //    Id = 966,
                //    Code = "966",
                //    Name = "Saudi Arabia",
                //    Example = "966541234567"
                //},
                //new CountryCode()
                //{
                //    Id = 221,
                //    Code = "221",
                //    Name = "Senegal",
                //    Example = "221701234567"
                //},
                //new CountryCode()
                //{
                //    Id = 381,
                //    Code = "381",
                //    Name = "Serbia",
                //    Example = "381601234567"
                //},
                //new CountryCode()
                //{
                //    Id = 248,
                //    Code = "248",
                //    Name = "Seychelles",
                //    Example = "2482510123"
                //},
                //new CountryCode()
                //{
                //    Id = 232,
                //    Code = "232",
                //    Name = "Sierra Leone",
                //    Example = "23225123456"
                //},
                //new CountryCode()
                //{
                //    Id = 65,
                //    Code = "65",
                //    Name = "Singapore",
                //    Example = "6591234567"
                //},
                //new CountryCode()
                //{
                //    Id = 421,
                //    Code = "421",
                //    Name = "Slovakia",
                //    Example = "421912345678"
                //},
                //new CountryCode()
                //{
                //    Id = 386,
                //    Code = "386",
                //    Name = "Slovenia",
                //    Example = "38631234567"
                //},
                //new CountryCode()
                //{
                //    Id = 677,
                //    Code = "677",
                //    Name = "Solomon Islands",
                //    Example = "6777412345"
                //},
                //new CountryCode()
                //{
                //    Id = 252,
                //    Code = "252",
                //    Name = "Somalia",
                //    Example = "252907123456"
                //},
                //new CountryCode()
                //{
                //    Id = 27,
                //    Code = "27",
                //    Name = "South Africa",
                //    Example = "27831234567"
                //},
                //new CountryCode()
                //{
                //    Id = 82,
                //    Code = "82",
                //    Name = "South Korea",
                //    Example = "821012345678"
                //},
                //new CountryCode()
                //{
                //    Id = 211,
                //    Code = "211",
                //    Name = "South Sudan",
                //    Example = "211971234567"
                //},
                //new CountryCode()
                //{
                //    Id = 34,
                //    Code = "34",
                //    Name = "Spain",
                //    Example = "34612345678"
                //},
                //new CountryCode()
                //{
                //    Id = 94,
                //    Code = "94",
                //    Name = "Sri Lanka",
                //    Example = "94712345678"
                //},
                //new CountryCode()
                //{
                //    Id = 249,
                //    Code = "249",
                //    Name = "Sudan",
                //    Example = "249911234567"
                //},
                //new CountryCode()
                //{
                //    Id = 597,
                //    Code = "597",
                //    Name = "Suriname",
                //    Example = "5977412345"
                //},
                //new CountryCode()
                //{
                //    Id = 268,
                //    Code = "268",
                //    Name = "Eswatini",
                //    Example = "26876123456"
                //},
                //new CountryCode()
                //{
                //    Id = 46,
                //    Code = "46",
                //    Name = "Sweden",
                //    Example = "46701234567"
                //},
                //new CountryCode()
                //{
                //    Id = 41,
                //    Code = "41",
                //    Name = "Switzerland",
                //    Example = "41791234567"
                //},
                //new CountryCode()
                //{
                //    Id = 963,
                //    Code = "963",
                //    Name = "Syria",
                //    Example = "963911234567"
                //},
                //new CountryCode()
                //{
                //    Id = 886,
                //    Code = "886",
                //    Name = "Taiwan",
                //    Example = "886912345678"
                //},
                //new CountryCode()
                //{
                //    Id = 992,
                //    Code = "992",
                //    Name = "Tajikistan",
                //    Example = "992917123456"
                //},
                //new CountryCode()
                //{
                //    Id = 255,
                //    Code = "255",
                //    Name = "Tanzania",
                //    Example = "255621234567"
                //},
                //new CountryCode()
                //{
                //    Id = 66,
                //    Code = "66",
                //    Name = "Thailand",
                //    Example = "66812345678"
                //},
                //new CountryCode()
                //{
                //    Id = 670,
                //    Code = "670",
                //    Name = "Timor-Leste",
                //    Example = "67077234567"
                //},
                //new CountryCode()
                //{
                //    Id = 228,
                //    Code = "228",
                //    Name = "Togo",
                //    Example = "22890123456"
                //},
                //new CountryCode()
                //{
                //    Id = 676,
                //    Code = "676",
                //    Name = "Tonga",
                //    Example = "6767712345"
                //},
                //new CountryCode()
                //{
                //    Id = 1868,
                //    Code = "1868",
                //    Name = "Trinidad and Tobago",
                //    Example = "18681234567"
                //},
                //new CountryCode()
                //{
                //    Id = 216,
                //    Code = "216",
                //    Name = "Tunisia",
                //    Example = "21620123456"
                //},
                //new CountryCode()
                //{
                //    Id = 90,
                //    Code = "90",
                //    Name = "Turkey",
                //    Example = "905301234567"
                //},
                //new CountryCode()
                //{
                //    Id = 993,
                //    Code = "993",
                //    Name = "Turkmenistan",
                //    Example = "99365123456"
                //},
                //new CountryCode()
                //{
                //    Id = 688,
                //    Code = "688",
                //    Name = "Tuvalu",
                //    Example = "688901234"
                //},
                //new CountryCode()
                //{
                //    Id = 256,
                //    Code = "256",
                //    Name = "Uganda",
                //    Example = "256712345678"
                //},
                //new CountryCode()
                //{
                //    Id = 380,
                //    Code = "380",
                //    Name = "Ukraine",
                //    Example = "380501234567"
                //},
                //new CountryCode()
                //{
                //    Id = 971,
                //    Code = "971",
                //    Name = "United Arab Emirates",
                //    Example = "971501234567"
                //},
                //new CountryCode()
                //{
                //    Id = 44,
                //    Code = "44",
                //    Name = "United Kingdom",
                //    Example = "447912345678"
                //},
                //new CountryCode()
                //{
                //    Id = 1,
                //    Code = "1",
                //    Name = "United States",
                //    Example = "14155551234"
                //},
                //new CountryCode()
                //{
                //    Id = 598,
                //    Code = "598",
                //    Name = "Uruguay",
                //    Example = "59891234567"
                //},
                //new CountryCode()
                //{
                //    Id = 998,
                //    Code = "998",
                //    Name = "Uzbekistan",
                //    Example = "998911234567"
                //},
                //new CountryCode()
                //{
                //    Id = 678,
                //    Code = "678",
                //    Name = "Vanuatu",
                //    Example = "6785912345"
                //},
                //new CountryCode()
                //{
                //    Id = 379,
                //    Code = "379",
                //    Name = "Vatican City",
                //    Example = "3793123456789"
                //},
                //new CountryCode()
                //{
                //    Id = 58,
                //    Code = "58",
                //    Name = "Venezuela",
                //    Example = "582123456789"
                //},
                //new CountryCode()
                //{
                //    Id = 84,
                //    Code = "84",
                //    Name = "Vietnam",
                //    Example = "84901234567"
                //},
                //new CountryCode()
                //{
                //    Id = 967,
                //    Code = "967",
                //    Name = "Yemen",
                //    Example = "967771234567"
                //},
                //new CountryCode()
                //{
                //    Id = 260,
                //    Code = "260",
                //    Name = "Zambia",
                //    Example = "260955123456"
                //},
                //new CountryCode()
                //{
                //    Id = 263,
                //    Code = "263",
                //    Name = "Zimbabwe",
                //    Example = "263771234567"
                //}
            };

            return countryCodeList;
        }
    }

}
