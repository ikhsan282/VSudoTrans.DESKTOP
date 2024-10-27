using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using Domain.Entities.Attendance;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace VSTS.DESKTOP.Utils
{
    public class SoapHelper
    {
        public static string PingConnectionMachine(string IpAddress)
        {
            string result = string.Empty;

            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(IpAddress);

            if (reply.Status == IPStatus.Success)
                result = "";
            else
                result = $"Ping ke {IpAddress} gagal. Status : {reply.Status}";

            return result;
        }
        public static string CheckConnectionMachine(string IpAddress)
        {
            string result = string.Empty;
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(IpAddress, 80);
                if (!client.Connected) { result += $"({IpAddress}) "; }
                client.Close();
            }
            catch (Exception)
            {
                result += $"({IpAddress})";
            }
            finally { client.Close(); }

            return result;
        }

        // Digunakan untuk refresh database mesin
        // When you upload ,delete data for assure the data was refresh,please use this command to refresh device’s database
        // Saat Anda mengunggah, hapus data untuk memastikan data telah disegarkan, harap gunakan perintah ini untuk menyegarkan database perangkat
        public static void RefreshDB(Machine machine)
        {
            string soapRequest = $"<RefreshDB><ArgComKey xsi:type=\"xsd:integer\">{machine.Code}</ArgComKey></RefreshDB>";

            byte[] requestBytes = Encoding.UTF8.GetBytes(soapRequest);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{machine.IpAddress}/iWsService");
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.ContentLength = requestBytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestBytes, 0, requestBytes.Length);
            }

            string buffer = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                buffer = reader.ReadToEnd();
            }
        }

        //Untuk download transaction per User ubah All yang ada di PIN menjadi PIN Usernya
        public static GetAttLogResponse DownloadTransactionAll(Machine machine)
        {
            GetAttLogResponse result = null;
            string soapRequest = $"<GetAttLog><ArgComKey xsi:type=\"xsd:integer\">{machine.Code}</ArgComKey><Arg><PIN xsi:type=\"xsd:integer\">All</PIN></Arg></GetAttLog>";

            byte[] requestBytes = Encoding.UTF8.GetBytes(soapRequest);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{machine.IpAddress}/iWsService");
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.ContentLength = requestBytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestBytes, 0, requestBytes.Length);
            }

            string buffer = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                buffer = reader.ReadToEnd();
            }

            buffer = RemoveUnrecognizedCharacters(buffer);

            // Serializer Response
            XmlSerializer serializer = new XmlSerializer(typeof(GetAttLogResponse));

            using (StringReader reader = new StringReader(buffer))
            {
                result = (GetAttLogResponse)serializer.Deserialize(reader);
            }

            return result;
        }

        static string RemoveUnrecognizedCharacters(string input)
        {
            return Regex.Replace(input, @"[^\x09\x0A\x0D\x20-\xD7FF\xE000-\xFFFD\x10000-x10FFFF]", string.Empty);
        }

        //Untuk download transaction per User ubah All yang ada di PIN menjadi PIN Usernya
        public static GetAttLogResponse DownloadTransactionByPIN(Machine machine, string pin)
        {
            GetAttLogResponse result = null;
            string soapRequest = $"<GetAttLog><ArgComKey xsi:type=\"xsd:integer\">{machine.Code}</ArgComKey><Arg><PIN xsi:type=\"xsd:integer\">{pin}</PIN></Arg></GetAttLog>";

            byte[] requestBytes = Encoding.UTF8.GetBytes(soapRequest);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{machine.IpAddress}/iWsService");
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.ContentLength = requestBytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestBytes, 0, requestBytes.Length);
            }

            string buffer = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                buffer = reader.ReadToEnd();
            }

            buffer = RemoveUnrecognizedCharacters(buffer);

            // Serializer Response
            XmlSerializer serializer = new XmlSerializer(typeof(GetAttLogResponse));

            using (StringReader reader = new StringReader(buffer))
            {
                result = (GetAttLogResponse)serializer.Deserialize(reader);
            }

            return result;
        }

        //Digunakan untuk delete semua data transaction absensi di mesin
        public static ClearDataResponse DeleteAllTransaction(Machine machine)
        {
            ClearDataResponse result = null;
            string soapRequest = $"<ClearData><ArgComKey xsi:type=\"xsd:integer\">{machine.Code}</ArgComKey><Arg><Value xsi:type=\"xsd:integer\">3</Value></Arg></ClearData>";

            byte[] requestBytes = Encoding.UTF8.GetBytes(soapRequest);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{machine.IpAddress}/iWsService");
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.ContentLength = requestBytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestBytes, 0, requestBytes.Length);
            }

            string buffer = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                buffer = reader.ReadToEnd();
            }

            // Serializer Response
            XmlSerializer serializer = new XmlSerializer(typeof(ClearDataResponse));

            using (StringReader reader = new StringReader(buffer))
            {
                result = (ClearDataResponse)serializer.Deserialize(reader);
            }
            return result;
        }

        //Untuk download data fingerprint di mesin
        public static GetUserTemplateResponse DownloadFingerprintByPIN(Machine machine, string pin)
        {
            GetUserTemplateResponse result = null;
            string soapRequest = $"<GetUserTemplate><ArgComKey xsi:type=\"xsd:integer\">{machine.Code}</ArgComKey><Arg><PIN xsi:type=\"xsd:integer\">{pin}</PIN><FingerID xsi:type=\"xsd:integer\">All</FingerID></Arg></GetUserTemplate>";

            byte[] requestBytes = Encoding.UTF8.GetBytes(soapRequest);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{machine.IpAddress}/iWsService");
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.ContentLength = requestBytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestBytes, 0, requestBytes.Length);
            }

            string buffer = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                buffer = reader.ReadToEnd();
            }

            // Serializer Response
            XmlSerializer serializer = new XmlSerializer(typeof(GetUserTemplateResponse));

            using (StringReader reader = new StringReader(buffer))
            {
                result = (GetUserTemplateResponse)serializer.Deserialize(reader);
            }
            return result;
        }

        //Untuk delete data fingerprint di mesin
        public static DeleteTemplateResponse DeleteFingerprintEmployeeByPIN(Machine machine, string pin)
        {
            DeleteTemplateResponse result = null;
            string soapRequest = $"<DeleteTemplate><ArgComKey xsi:type=\"xsd:integer\">{machine.Code}</ArgComKey><Arg><PIN xsi:type=\"xsd:integer\">{pin}</PIN></Arg></DeleteTemplate>";

            byte[] requestBytes = Encoding.UTF8.GetBytes(soapRequest);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{machine.IpAddress}/iWsService");
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.ContentLength = requestBytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestBytes, 0, requestBytes.Length);
            }

            string buffer = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                buffer = reader.ReadToEnd();
            }

            // Serializer Response
            XmlSerializer serializer = new XmlSerializer(typeof(DeleteTemplateResponse));

            using (StringReader reader = new StringReader(buffer))
            {
                result = (DeleteTemplateResponse)serializer.Deserialize(reader);
            }

            return result;
        }

        //Untuk delete data user di mesin
        public static DeleteUserResponse DeleteUserByPIN(Machine machine, string pin)
        {
            DeleteUserResponse result = null;
            string soapRequest = $"<DeleteUser><ArgComKey xsi:type=\"xsd:integer\">{machine.Code}</ArgComKey><Arg><PIN xsi:type=\"xsd:integer\">{pin}</PIN></Arg></DeleteUser>";

            byte[] requestBytes = Encoding.UTF8.GetBytes(soapRequest);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{machine.IpAddress}/iWsService");
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.ContentLength = requestBytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestBytes, 0, requestBytes.Length);
            }

            string buffer = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                buffer = reader.ReadToEnd();
            }

            // Serializer Response
            XmlSerializer serializer = new XmlSerializer(typeof(DeleteUserResponse));

            using (StringReader reader = new StringReader(buffer))
            {
                result = (DeleteUserResponse)serializer.Deserialize(reader);
            }

            return result;
        }

        //Digunakan untuk upload data fingerprint/foto fingerprint berdasarkan jarinya
        public static SetUserTemplateResponse SetFingerprintByPIN(Machine machine, string pin, int fIndex, string template)
        {
            SetUserTemplateResponse result = null;
            string soapRequest = $"<SetUserTemplate><ArgComKey xsi:type=\"xsd:integer\">{machine.Code}</ArgComKey><Arg><PIN xsi:type=\"xsd:integer\">{pin}</PIN><FingerID xsi:type=\"xsd:integer\">{fIndex}</FingerID><Size>{template.Length}</Size><Valid>1</Valid><Template>{template}</Template></Arg></SetUserTemplate>";

            byte[] requestBytes = Encoding.UTF8.GetBytes(soapRequest);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{machine.IpAddress}/iWsService");
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.ContentLength = requestBytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestBytes, 0, requestBytes.Length);
            }

            string buffer = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                buffer = reader.ReadToEnd();
            }

            // Serializer Response
            XmlSerializer serializer = new XmlSerializer(typeof(SetUserTemplateResponse));

            using (StringReader reader = new StringReader(buffer))
            {
                result = (SetUserTemplateResponse)serializer.Deserialize(reader);
            }

            return result;
        }

        //Untuk mengubah nama user by pin, biasa di gunakan untuk swap karyawan, nama di mesin perlu di sinkron
        public static SetUserInfoResponse SetNamaUserByPIN(Machine machine, string pin, string nama)
        {
            SetUserInfoResponse result = null;
            Console.WriteLine("Berhasil terhubung ke mesin ZKTeco S922!");
            string soapRequest = $"<SetUserInfo><ArgComKey Xsi:type=\"xsd:integer\">{machine.Code}</ArgComKey><Arg><PIN>{pin}</PIN><Name>{nama.Replace("'", "")}</Name></Arg></SetUserInfo>";

            byte[] requestBytes = Encoding.UTF8.GetBytes(soapRequest);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{machine.IpAddress}/iWsService");
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.ContentLength = requestBytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestBytes, 0, requestBytes.Length);
            }

            string buffer = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                buffer = reader.ReadToEnd();
            }

            // Serializer Response
            XmlSerializer serializer = new XmlSerializer(typeof(SetUserInfoResponse));

            using (StringReader reader = new StringReader(buffer))
            {
                result = (SetUserInfoResponse)serializer.Deserialize(reader);
            }
            return result;
        }

        //Untuk download transaction per User ubah All yang ada di PIN menjadi PIN Usernya
        public static GetAllUserInfoResponse GetAllUserInfo(Machine machine)
        {
            GetAllUserInfoResponse result = null;
            string soapRequest = $"<GetAllUserInfo><ArgComKey xsi:type=\"xsd:integer\">{machine.Code}</ArgComKey></GetAllUserInfo>";

            byte[] requestBytes = Encoding.UTF8.GetBytes(soapRequest);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://{machine.IpAddress}/iWsService");
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.ContentLength = requestBytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestBytes, 0, requestBytes.Length);
            }

            string buffer = "";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                buffer = reader.ReadToEnd();
            }

            // Serializer Response
            XmlSerializer serializer = new XmlSerializer(typeof(GetAllUserInfoResponse));

            using (StringReader reader = new StringReader(buffer))
            {
                result = (GetAllUserInfoResponse)serializer.Deserialize(reader);
            }

            return result;
        }
    }

    #region GetAllUserInfoResponse

    [XmlRoot(ElementName = "Row")]
    public class RowGetAllUserInfoResponse
    {

        [XmlElement(ElementName = "PIN")]
        public string PIN { get; set; }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Password")]
        public string Password { get; set; }

        [XmlElement(ElementName = "Group")]
        public string Group { get; set; }

        [XmlElement(ElementName = "Privilege")]
        public string Privilege { get; set; }

        [XmlElement(ElementName = "Card")]
        public string Card { get; set; }

        [XmlElement(ElementName = "PIN2")]
        public string PIN2 { get; set; }

        [XmlElement(ElementName = "TZ1")]
        public string TZ1 { get; set; }

        [XmlElement(ElementName = "TZ2")]
        public string TZ2 { get; set; }

        [XmlElement(ElementName = "TZ3")]
        public string TZ3 { get; set; }
    }

    [XmlRoot(ElementName = "GetAllUserInfoResponse")]
    public class GetAllUserInfoResponse
    {

        [XmlElement(ElementName = "Row")]
        public List<RowGetAllUserInfoResponse> RowGetAllUserInfoResponse { get; set; }
    }

    #endregion

    #region GetAttLogResponse
    public class LogAttendance
    {
        public int MachineId { get; set; }
        public int CompanyId { get; set; }
        public string PIN { get; set; }
        public string PCName { get; set; } // Absen menggunakan openfinger dari pc submission
        public List<RowAttLogResponse> RowAttLogResponse { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class RowAttLogResponse
    {
        [XmlElement(ElementName = "PIN")]
        public string PIN { get; set; }

        [XmlElement(ElementName = "DateTime")]
        public string DateTime { get; set; }
        public long IDateTime { get; set; }

        [XmlElement(ElementName = "Verified")]
        public string Verified { get; set; }

        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }

        [XmlElement(ElementName = "WorkCode")]
        public string WorkCode { get; set; }
    }

    [XmlRoot(ElementName = "GetAttLogResponse")]
    public class GetAttLogResponse
    {

        [XmlElement(ElementName = "Row")]
        public List<RowAttLogResponse> Row { get; set; }
    }
    #endregion

    #region ClearDataResponse

    [XmlRoot(ElementName = "Row")]
    public class RowClearDataResponse
    {

        [XmlElement(ElementName = "Result")]
        public int Result { get; set; }

        [XmlElement(ElementName = "Information")]
        public string Information { get; set; }
    }

    [XmlRoot(ElementName = "ClearDataResponse")]
    public class ClearDataResponse
    {

        [XmlElement(ElementName = "Row")]
        public RowClearDataResponse Row { get; set; }
    }
    #endregion

    #region GetUserTemplateResponse

    [XmlRoot(ElementName = "Row")]
    public class RowUserTemplateResponse
    {
        public int EmployeeId { get; set; }
        [XmlElement(ElementName = "PIN")]
        public string PIN { get; set; }

        [XmlElement(ElementName = "FingerID")]
        public int FingerID { get; set; }

        [XmlElement(ElementName = "Size")]
        public string Size { get; set; }

        [XmlElement(ElementName = "Valid")]
        public int Valid { get; set; }

        [XmlElement(ElementName = "Template")]
        public string Template { get; set; }
    }

    [XmlRoot(ElementName = "GetUserTemplateResponse")]
    public class GetUserTemplateResponse
    {

        [XmlElement(ElementName = "Row")]
        public List<RowUserTemplateResponse> Row { get; set; }
    }
    #endregion

    #region DeleteTemplateResponse

    [XmlRoot(ElementName = "Row")]
    public class RowDeleteTemplateResponse
    {

        [XmlElement(ElementName = "Result")]
        public int Result { get; set; }

        [XmlElement(ElementName = "Information")]
        public string Information { get; set; }
    }

    [XmlRoot(ElementName = "DeleteTemplateResponse")]
    public class DeleteTemplateResponse
    {

        [XmlElement(ElementName = "Row")]
        public RowDeleteTemplateResponse Row { get; set; }
    }
    #endregion

    #region DeleteUserResponse

    [XmlRoot(ElementName = "Row")]
    public class RowDeleteUserResponse
    {

        [XmlElement(ElementName = "Result")]
        public int Result { get; set; }

        [XmlElement(ElementName = "Information")]
        public string Information { get; set; }
    }

    [XmlRoot(ElementName = "DeleteUserResponse")]
    public class DeleteUserResponse
    {

        [XmlElement(ElementName = "Row")]
        public RowDeleteUserResponse Row { get; set; }
    }
    #endregion

    #region SetUserTemplateResponse

    [XmlRoot(ElementName = "Row")]
    public class RowSetUserTemplateResponse
    {

        [XmlElement(ElementName = "Result")]
        public int Result { get; set; }

        [XmlElement(ElementName = "Information")]
        public string Information { get; set; }
    }

    [XmlRoot(ElementName = "SetUserTemplateResponse")]
    public class SetUserTemplateResponse
    {

        [XmlElement(ElementName = "Row")]
        public RowSetUserTemplateResponse Row { get; set; }
    }
    #endregion

    #region SetUserInfoResponse

    [XmlRoot(ElementName = "Row")]
    public class RowSetUserInfoResponse
    {

        [XmlElement(ElementName = "Result")]
        public int Result { get; set; }

        [XmlElement(ElementName = "Information")]
        public string Information { get; set; }
    }

    [XmlRoot(ElementName = "SetUserInfoResponse")]
    public class SetUserInfoResponse
    {

        [XmlElement(ElementName = "Row")]
        public RowSetUserInfoResponse Row { get; set; }
    }
    #endregion
}
