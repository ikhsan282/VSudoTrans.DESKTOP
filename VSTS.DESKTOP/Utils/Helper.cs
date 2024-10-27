using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraRichEdit.Model;
using Domain.Entities.Demography;
using Domain.Entities.EducationPayment;
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

namespace VSTS.DESKTOP.Utils
{
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
                    Id = "02",
                    Code = "02",
                    Name = "Indonesia",
                    Example = "02123456789"
                },
                new CountryCode()
                {
                    Id = "62",
                    Code = "62",
                    Name = "Indonesia",
                    Example = "6281234567890"
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
