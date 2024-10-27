using System.ComponentModel.DataAnnotations;

namespace Domain
{
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

    public enum EnumEducationType : short
    {
        [Display(Name = "Tunggakan Biaya Sekolah")]
        TunggakanBiayaSekolah = -1, // SPP, Pembangunan
        [Display(Name = "Biaya Sekolah")]
        BiayaSekolah = 0, // SPP, Pembangunan
        [Display(Name = "Formulir Pendaftaran")]
        FormulirPendaftaran = 1, // Formulir Penerima Peserta Didik Baru
        [Display(Name = "Evaluasi Pendidikan")]
        EvaluasiPendidikan = 2, // Penilaian Tengah Semester, Penilaian Akhir Semester
        [Display(Name = "Buku dan Bahan Belajar")]
        BukudanBahanBelajar = 3, // Perpustakaan, Buku Teks, Alat Tulis, Bahan Belajar Lainnya
        [Display(Name = "Kegiatan Ekstrakurikuler")]
        KegiatanEkstrakurikuler = 4, // Organisasi Siswa Intra Sekolah, Pramuka
        [Display(Name = "Kegiatan Khusus")]
        KegiatanKhusus = 5, // Studi Tour, Acara Musik, Seni, Festival Sekolah
        [Display(Name = "Transportasi/Akomodasi")]
        TransportasiAkomodasi = 6, // Biaya Transportasi, Biaya Akomodasi
        [Display(Name = "Transportasi/Akomodasi")]
        PeralatandanSarana = 7, // Peralatan Laboratorium, Komputer, Proyektor
        [Display(Name = "Konseling/Dukungan")]
        KonselingDukungan = 8, // Layanan Konseling, Layanan Dukungan
        [Display(Name = "Perlindungan/Keamanan")]
        PerlindunganKeamanan = 9, // Asuransi Siswa, Keamanan Fisik di Sekolah
    }
    public enum EnumPaymentMethod : short
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
    }

    public enum EnumTypeEducation : short
    {
        [Display(Name = "Kelompok Bermain")]
        KP,
        [Display(Name = "Taman Kanak-Kanak")]
        TK,
        [Display(Name = "Sekolah Dasar")]
        SD,
        [Display(Name = "Sekolah Dasar Islam Terpadu")]
        SDIT,
        [Display(Name = "Sekolah Menengah Pertama")]
        SMP,
        [Display(Name = "Madrasah Tsanawiyah")]
        MTS,
        [Display(Name = "Sekolah Menengah Atas")]
        SMA,
        [Display(Name = "Madrasah Aliyah")]
        MA,
        [Display(Name = "Sekolah Menengah Kejuruan")]
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
        [Display(Name = "Belum Dibayar")]
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

    public enum EnumPriceType : short
    {
        [Display(Name = "Reguler")]
        Regular = 0,
        [Display(Name = "Reguler Premium")]
        RegularPremium = 1,
        [Display(Name = "Private")]
        Private = 2,
        [Display(Name = "Private Premium")]
        PrivatePremium = 3,
        [Display(Name = "Elf Pendek")]
        ElfShort = 4,
        [Display(Name = "Elf Panjang")]
        ElfLong = 5,
        [Display(Name = "Hiace")]
        Hiace = 6,
        [Display(Name = "Bus Sedang")]
        MediumBus = 7,
        [Display(Name = "Bus Besar")]
        BigBus = 8
    }

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
        FailedPickup = 5
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
        L = 7 // Libur
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
        Lakilaki,
        [Display(Name = "Perempuan")]
        Perempuan,
        [Display(Name = "Laki-laki dan Perempuan")]
        LakiLakiPerempuan
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
    public enum EnumUserType : short
    {
        [Display(Name = "Karyawan")]
        Employee = 0,
        [Display(Name = "Murid")]
        Student = 1
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

}
