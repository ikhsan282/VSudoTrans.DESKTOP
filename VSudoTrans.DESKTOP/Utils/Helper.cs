using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPrinting.Drawing;
using Domain.Entities.Demography;
using Domain.Entities.Identity;
using Domain.Entities.Organization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace VSudoTrans.DESKTOP.Utils
{
    public class HelperConvert
    {
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        public static Image UrlToImage(string imageUrl)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] data = webClient.DownloadData(imageUrl);
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream(data))
                {
                    return Image.FromStream(stream);
                }
            }
        }

        public static ImageSource UrlToImageSource(string imageUrl)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] data = webClient.DownloadData(imageUrl);
                return ConvertBytesToImageSource(data);
            }
        }

        public static ImageSource ConvertBytesToImageSource(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return null;

            try
            {
                using (MemoryStream stream = new MemoryStream(bytes))
                {
                    Image image = Image.FromStream(stream);

                    return new ImageSource(image);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the conversion
                Console.WriteLine("Error converting byte[] to ImageSource: " + ex.Message);
                return null;
            }
        }

        public static string FormatRupiah(object amount)
        {
            CultureInfo indonesianCulture = CultureInfo.GetCultureInfo("id-ID");
            return string.Format(indonesianCulture, "{0:N0}", amount);
        }

        static string[] bilangan = { "", "Satu", "Dua", "Tiga", "Empat", "Lima", "Enam", "Tujuh", "Delapan", "Sembilan" };
        static string[] belasan = { "Sepuluh", "Sebelas", "Dua Belas", "Tiga Belas", "Empat Belas", "Lima Belas", "Enam Belas", "Tujuh Belas", "Delapan Belas", "Sembilan Belas" };
        static string[] puluhan = { "", "Sepuluh", "Dua Puluh", "Tiga Puluh", "Empat Puluh", "Lima Puluh", "Enam Puluh", "Tujuh Puluh", "Delapan Puluh", "Sembilan Puluh" };
        static string[] ribuan = { "", "Ribu", "Juta", "Miliar", "Triliun" };

        public static string Terbilang(long angka)
        {
            TextInfo textInfo = new CultureInfo("id-ID", false).TextInfo;

            if (angka < 10)
                return textInfo.ToTitleCase(bilangan[angka].ToLower());
            if (angka < 20)
                return textInfo.ToTitleCase(belasan[angka - 10].ToLower());
            if (angka < 100)
                return textInfo.ToTitleCase((puluhan[angka / 10] + " " + bilangan[angka % 10]).ToLower());
            if (angka < 1000)
                return textInfo.ToTitleCase((bilangan[angka / 100] + " Ratus " + Terbilang(angka % 100)).ToLower());
            for (int i = 0; i < ribuan.Length; i++)
            {
                if (angka < Math.Pow(10, 3 * (i + 1)))
                    return textInfo.ToTitleCase((Terbilang(angka / (long)Math.Pow(10, 3 * i)) + " " + ribuan[i] + " " + Terbilang(angka % (long)Math.Pow(10, 3 * i))).ToLower());
            }
            return "";
        }

        public static void FormatSpinEdit(SpinEdit spintEdit, string format = "n0", long minValue = 0, long maxValue = 100)
        {
            FormatSpinEdit(spintEdit.Properties, format, minValue, maxValue);
        }

        public static void FormatSpinEdit(RepositoryItemSpinEdit spintEdit, string format = "n0", long minValue = 0, long maxValue = 100)
        {
            spintEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            spintEdit.Mask.EditMask = format;
            spintEdit.Mask.UseMaskAsDisplayFormat = true;
            spintEdit.UseMaskAsDisplayFormat = true;
            spintEdit.CharacterCasing = CharacterCasing.Normal;
            spintEdit.MinValue = minValue;
            spintEdit.MaxValue = maxValue;
        }

        public static void FormatTimeSpanEdit(TimeSpanEdit timeSpanEdit, string format = "HH:mm")
        {
            timeSpanEdit.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            timeSpanEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.TimeSpan;
            timeSpanEdit.Properties.Mask.EditMask = format;
            timeSpanEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            timeSpanEdit.Properties.UseMaskAsDisplayFormat = true;
            timeSpanEdit.Properties.CharacterCasing = CharacterCasing.Normal;
        }

        public static void FormatDateEdit(DateTimeOffsetEdit dateEdit, string format = "dd-MMM-yyyy")
        {
            dateEdit.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dateEdit.Properties.Mask.EditMask = format;
            dateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateEdit.Properties.UseMaskAsDisplayFormat = true;
            dateEdit.Properties.CharacterCasing = CharacterCasing.Normal;
        }

        public static void FormatDateTextEdit(TextEdit textEdit, string format = "dd-MMM-yyyy HH:mm")
        {
            FormatDateTextEdit(textEdit.Properties, format);
        }

        public static void FormatDateTextEdit(RepositoryItemTextEdit textEdit, string format = "dd-MMM-yyyy HH:mm")
        {
            //textEdit.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            textEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            textEdit.Mask.EditMask = format;
            textEdit.Mask.UseMaskAsDisplayFormat = true;
            textEdit.UseMaskAsDisplayFormat = true;
            textEdit.CharacterCasing = CharacterCasing.Normal;
        }

        public static void FormatDateTimeEdit(DateEdit dateEdit, string format = "dd-MMM-yyyy HH:mm")
        {
            FormatDateEdit(dateEdit, format);
        }

        public static void FormatDateEdit(RepositoryItemDateEdit dateEdit, string format = "dd-MMM-yyyy")
        {
            dateEdit.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dateEdit.Mask.EditMask = format;
            dateEdit.Mask.UseMaskAsDisplayFormat = true;
            dateEdit.UseMaskAsDisplayFormat = true;
            dateEdit.CharacterCasing = CharacterCasing.Normal;
        }

        public static void FormatDateEdit(DateEdit dateEdit, string format = "dd-MMM-yyyy")
        {
            FormatDateEdit(dateEdit.Properties, format);
        }

        public static void FormatTimeEdit(RepositoryItemDateEdit dateEdit, string format = "HH:mm")
        {
            FormatDateEdit(dateEdit, format);
        }

        public static void FormatTimeEdit(DateEdit dateEdit, string format = "HH:mm")
        {
            FormatDateEdit(dateEdit.Properties, format);
        }

        public static void FormatDecimalTextEdit(TextEdit textEdit, string format = "n0", HorzAlignment horzAlignment = HorzAlignment.Near)
        {
            FormatDecimalTextEdit(textEdit.Properties, format, horzAlignment);
        }
        public static void FormatDecimalTextEdit(RepositoryItemTextEdit textEdit, string format = "n0", HorzAlignment horzAlignment = HorzAlignment.Near)
        {
            textEdit.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            textEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            textEdit.Mask.EditMask = format;
            textEdit.Mask.UseMaskAsDisplayFormat = true;
            textEdit.UseMaskAsDisplayFormat = true;
            textEdit.CharacterCasing = CharacterCasing.Normal;
            textEdit.Appearance.TextOptions.HAlignment = horzAlignment;
        }

        public static int TotalDays(DateTime fromDate, DateTime toDate)
        {
            return (toDate.Date - fromDate.Date).Days + 1;
        }

        public static string monthKuartal(int bln)
        {
            if (bln < 4)
                return "I";
            else if (bln < 7)
                return "II";
            else if (bln < 10)
                return "III";
            else
                return "IV";
        }
        public static string monthRomawi(int bln)
        {
            switch (bln)
            {
                case 1:
                    return "I";
                case 2:
                    return "II";
                case 3:
                    return "III";
                case 4:
                    return "IV";
                case 5:
                    return "V";
                case 6:
                    return "VI";
                case 7:
                    return "VII";
                case 8:
                    return "VIII";
                case 9:
                    return "IX";
                case 10:
                    return "X";
                case 11:
                    return "XI";
                case 12:
                    return "XII";
            }
            return null;
        }

        public static string MonthText(int month)
        {
            switch (month)
            {
                case 1:
                    return "Januari";
                case 2:
                    return "Februari";
                case 3:
                    return "Maret";
                case 4:
                    return "April";
                case 5:
                    return "Mei";
                case 6:
                    return "Juni";
                case 7:
                    return "Juli";
                case 8:
                    return "Agustus";
                case 9:
                    return "September";
                case 10:
                    return "Oktober";
                case 11:
                    return "November";
                case 12:
                    return "Desember";
                default:
                    return "Bulan tidak valid";
            }
        }

        public static string MonthText(string month)
        {
            int iMonth = Int(month);
            switch (iMonth)
            {
                case 1:
                    return "Januari";
                case 2:
                    return "Februari";
                case 3:
                    return "Maret";
                case 4:
                    return "April";
                case 5:
                    return "Mei";
                case 6:
                    return "Juni";
                case 7:
                    return "Juli";
                case 8:
                    return "Agustus";
                case 9:
                    return "September";
                case 10:
                    return "Oktober";
                case 11:
                    return "November";
                case 12:
                    return "Desember";
                default:
                    return "Bulan tidak valid";
            }
        }

        public static int MonthNumber(string monthName)
        {
            switch (monthName.ToLower())
            {
                case "january":
                    return 1;
                case "february":
                    return 2;
                case "march":
                    return 3;
                case "april":
                    return 4;
                case "may":
                    return 5;
                case "june":
                    return 6;
                case "july":
                    return 7;
                case "august":
                    return 8;
                case "september":
                    return 9;
                case "october":
                    return 10;
                case "november":
                    return 11;
                case "december":
                    return 12;
                default:
                    return 0; // Jika nama bulan tidak valid
            }
        }

        public static string String(object pos)
        {
            try
            {
                if (pos == null)
                    return "";
                else
                    return pos.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static double Double(object pos)
        {
            try
            {
                double value = 0;
                if (pos == null || pos == "")
                    return value;
                else
                    value = double.Parse(pos.ToString());

                if (IsNaN(value) == true)
                    value = 0;

                return value;
            }
            catch
            {
                return 0;
            }
        }

        public static bool IsNaN(double? d)
        {
            return (d != d);
        }

        public static decimal Decimal(object pos)
        {
            try
            {
                if (pos == null || pos == "")
                    return 0;
                else
                    return decimal.Parse(pos.ToString() == "Infinity" ? "0" : pos.ToString());
            }
            catch
            {
                return 0;
            }
        }

        public static int Int(object pos)
        {
            try
            {
                if (pos == null || pos == "")
                    return 0;
                else
                    return int.Parse(pos.ToString());
            }
            catch
            {
                return 0;
            }
        }

        public static long Long(object pos)
        {
            try
            {
                if (pos == null || pos.ToString() == "")
                    return 0;
                else
                    return long.Parse(pos.ToString());
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime Date(object pos)
        {
            DateTime result = DateTime.MinValue;
            try
            {
                if (pos != null)
                {
                    DateTime.TryParse(pos.ToString(), out result);
                    if (result == DateTime.MinValue)
                    {
                        if (DateTime.TryParse(pos.ToString(), out result))// Check apakah date?
                            result = (DateTime)pos;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                DateTimeOffset res = DateTimeOffset.MinValue;
                if (DateTimeOffset.TryParse(pos.ToString(), out res))// Check apakah date?
                    result = ((DateTimeOffset)pos).DateTime;
                return result;
            }
        }
    }


    [XmlRoot(ElementName = "UriConnection")]
    public class UriConnection
    {

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Url")]
        public string Url { get; set; }

        [XmlElement(ElementName = "Default")]
        public bool Default { get; set; }
    }

    [XmlRoot(ElementName = "Urls")]
    public class Urls
    {

        [XmlElement(ElementName = "Url")]
        public List<UriConnection> Url { get; set; }
    }

    [XmlRoot(ElementName = "ConfigNTM")]
    public class ConfigNTM
    {

        [XmlElement(ElementName = "Urls")]
        public Urls Urls { get; set; }
    }

    public class UriHelper
    {
        public string UrlApiDefault { get; set; }
        public string UrlToken { get; set; }
        public string UrlRefreshToken { get; set; }
    }
    public sealed class ApplicationSettings
    {
        private static readonly Lazy<ApplicationSettings> Lazy = new Lazy<ApplicationSettings>(() => new ApplicationSettings());

        public DevExpress.Skins.Skin CurrentSkin { get; set; } = DevExpress.Skins.CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default);
        public DevExpress.Skins.SkinColors SkinColor
        {
            get
            {
                return CurrentSkin.Colors;
            }
        }

        /// <summary>
        /// Access point to methods and properties
        /// </summary>
        public static ApplicationSettings Instance => Lazy.Value;
        public string DateFormat { get; set; } = "dd-MMM-yyyy";
        public UriHelper UriHelper { get; set; } = new UriHelper();
        public string PathMyDocument { get; set; } = "";


        public ApplicationUser ApplicationUser { get; set; }
        public Guid UserApplicationId { get; set; }
        public List<Company> UserCompanys { get; set; } = new List<Company>();
        public List<ApplicationRole> UserRoles { get; set; } = new List<ApplicationRole>();
        public List<ApplicationRoleClaim> UserRoleClaims { get; set; } = new List<ApplicationRoleClaim>();
        public List<NavigationRole> NavigationRoles { get; set; } = new List<NavigationRole>();
        public int? ControllerId { get; set; }
    }
}
