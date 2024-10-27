using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using static VSudoTrans.DESKTOP.Utils.ExceptionMiddlewareHelper;
using DevExpress.Data.Filtering;
using DevExpress.Data;
using System.Text.Json;
using System.Text;
using Brotli;
using System.Windows.Forms;
using System.IO;
using Microsoft.OData.Edm;

namespace VSudoTrans.DESKTOP.Utils
{
    //https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to?pivots=dotnet-6-0
    //https://stackoverflow.com/questions/70945956/how-to-serialize-a-timespan-as-hhmmss-with-system-text-json-jsonserializer
    //https://stackoverflow.com/questions/58283761/net-core-3-0-timespan-deserialization-error-fixed-in-net-5-0
    public class TimeSpanJsonConverter : Newtonsoft.Json.JsonConverter<TimeSpan>
    {
        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            return TimeSpan.Parse(reader.Value.ToString() ?? "");
        }

        public override void WriteJson(JsonWriter writer, TimeSpan value, Newtonsoft.Json.JsonSerializer serializer)
        {
            //writer.WriteStringValue(timeSpanValue.ToString(@"hh\:mm\:ss"));
            writer.WriteValue(value.ToString(@"hh\:mm\:ss"));
        }
    }

    public class TimeOfDayJsonConverter : Newtonsoft.Json.JsonConverter<TimeOfDay>
    {
        public override TimeOfDay ReadJson(JsonReader reader, Type objectType, TimeOfDay existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            return TimeSpan.Parse(reader.Value.ToString() ?? "");
        }

        public override void WriteJson(JsonWriter writer, TimeOfDay value, Newtonsoft.Json.JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }

    public class TimeOfDayNullableJsonConverter : Newtonsoft.Json.JsonConverter<TimeOfDay?>
    {
        public override TimeOfDay? ReadJson(JsonReader reader, Type objectType, TimeOfDay? existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.Value != null)
            {
                return TimeSpan.Parse(reader.Value.ToString() ?? "");
            }
            else
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, TimeOfDay? value, Newtonsoft.Json.JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }

    public class TimeSpanNullableJsonConverter : Newtonsoft.Json.JsonConverter<TimeSpan?>
    {
        public override TimeSpan? ReadJson(JsonReader reader, Type objectType, TimeSpan? existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.Value != null)
            {
                return TimeSpan.Parse(reader.Value.ToString() ?? "");
            }
            else
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, TimeSpan? value, Newtonsoft.Json.JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
    public enum FileType
    {
        Unknown,
        PDF,
        JPEG,
        PNG,
        BMP,
        Excel,
        Word
    }
    public class ResponseODataRestSharpList<T>
    {
        [JsonProperty("@odata.context")]
        public string odatacontext { get; set; }
        [JsonProperty("@odata.count")]
        public long count { get; set; }
        [JsonProperty("@odata.nextLink")]
        public string nextLink { get; set; }
        public List<T> value { get; set; }
    }

    public static class HelperRestSharp
    {
        public static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            Converters =
                    {
                        new TimeSpanJsonConverter(), // Convert TimeSpan
                        new TimeOfDayJsonConverter(), // Convert TimeOfDay
                        new TimeOfDayNullableJsonConverter() // Convert TimeOfDay Nullable
                    }
        };

        #region CheckFileType
        public static FileType CheckFileType(byte[] fileBytes)
        {
            if (fileBytes == null || fileBytes.Length < 8)
            {
                return FileType.Unknown; // Jika array byte kosong atau tidak memiliki cukup byte untuk menentukan tipe file
            }

            if (fileBytes[0] == 0x25 && fileBytes[1] == 0x50 && fileBytes[2] == 0x44 && fileBytes[3] == 0x46)
            {
                return FileType.PDF; // Magic number untuk PDF
            }
            else if (fileBytes[0] == 0xFF && fileBytes[1] == 0xD8)
            {
                return FileType.JPEG; // Magic number untuk JPEG
            }
            else if (fileBytes[0] == 0x89 && fileBytes[1] == 0x50 && fileBytes[2] == 0x4E && fileBytes[3] == 0x47)
            {
                return FileType.PNG; // Magic number untuk PNG
            }
            else if (fileBytes[0] == 0x42 && fileBytes[1] == 0x4D)
            {
                return FileType.BMP; // Magic number untuk BMP
            }
            else if (fileBytes[0] == 0x50 && fileBytes[1] == 0x4B && fileBytes[2] == 0x03 && fileBytes[3] == 0x04 &&
                     fileBytes[6] == 0x06 && fileBytes[7] == 0x00)
            {
                return FileType.Excel; // Signature untuk file Excel
            }
            else if (fileBytes[0] == 0xD0 && fileBytes[1] == 0xCF && fileBytes[2] == 0x11 && fileBytes[3] == 0xE0 &&
                     fileBytes[4] == 0xA1 && fileBytes[5] == 0xB1 && fileBytes[6] == 0x1A && fileBytes[7] == 0xE1)
            {
                return FileType.Word; // Signature untuk file Word
            }
            else
            {
                return FileType.Unknown; // Tipe file tidak dikenali
            }
        }
        #endregion

        public static void SaveFileDialog(byte[] fileBytes, string saveFileDefault = "")
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            var fileType = CheckFileType(fileBytes);

            string filter = "";
            string defaultExtension = "";

            switch (fileType)
            {
                case FileType.PDF:
                    filter = "PDF files (*.pdf)|*.pdf";
                    defaultExtension = ".pdf";
                    break;
                case FileType.JPEG:
                case FileType.PNG:
                case FileType.BMP:
                    filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                    break;
                case FileType.Excel:
                    filter = "Excel files (*.xlsx)|*.xlsx";
                    defaultExtension = ".xlsx";
                    break;
                case FileType.Word:
                    filter = "Word files (*.docx)|*.docx";
                    defaultExtension = ".docx";
                    break;
                default:
                    // Tipe file tidak dikenali, atau tidak ada filter yang cocok
                    break;
            }

            saveFileDialog.DefaultExt = defaultExtension;
            saveFileDialog.Filter = filter;
            saveFileDialog.Title = "Save File";

            if (!string.IsNullOrEmpty(saveFileDefault))
                saveFileDialog.FileName = saveFileDefault;

            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
                File.WriteAllBytes(saveFileDialog.FileName, fileBytes);
        }

        public static byte[] DownloadFile(string container, string fileName, bool fAuth = true)
        {
            var options = new RestClientOptions(ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api")
            {
                ThrowOnAnyError = false,
                MaxTimeout = 300000  // 5 Minute.
            };

            using (RestClient restClient = new RestClient(options))
            {
                var request = new RestRequest("/Storages/DownloadFile", Method.Post);

                if (!string.IsNullOrEmpty(ApplicationSettings.Instance.UriHelper.UrlToken))
                {
                    request.AddHeader("Authorization", "Bearer " + ApplicationSettings.Instance.UriHelper.UrlToken);
                    // request.AddHeader("Company", CompanyId.ToString()); // Jika perlu header tambahan
                }

                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("ContainerName", container);
                request.AddParameter("FileName", fileName);

                var response = restClient.Execute(request);

                if (response.IsSuccessful)
                {
                    return response.RawBytes;
                }
                else
                {
                    var err = GetRestResponseErrorMessage(response);
                    throw new Exception(err);
                }
            }
        }

        public static string UploadFile(byte[] file, string fileName, string subFolder = "", string keyName = "Data", bool fAuth = true)
        {
            return PostFile(file, fileName, "VSudoTrans", subFolder: subFolder, keyName: keyName, fAuth: fAuth);
        }

        public static string PostFile(byte[] file, string fileName, string container, string subFolder = "", string keyName = "Data", bool fAuth = true)
        {
            var options = new RestClientOptions(ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api")
            {
                ThrowOnAnyError = false,
                MaxTimeout = 300000  // 5 Minute.
            };

            using (RestClient restClient = new RestClient(options))
            {
                var request = new RestRequest("/Storages/UploadFile", Method.Post);

                if (!string.IsNullOrEmpty(ApplicationSettings.Instance.UriHelper.UrlToken))
                {
                    request.AddHeader("Authorization", "Bearer " + ApplicationSettings.Instance.UriHelper.UrlToken);
                    // request.AddHeader("Company", CompanyId.ToString()); // Jika perlu header tambahan
                }

                request.AddHeader("Content-Type", "multipart/form-data");
                request.AddFile(keyName, file, fileName);
                request.AddParameter("ContainerName", container);
                request.AddParameter("SubFolder", subFolder);

                var response = restClient.Execute(request);

                if (response.IsSuccessful)
                {
                    var responseBody = response.Content.ToString().Replace('"', ' ').Trim();
                    return responseBody;
                }
                else
                {
                    var err = GetRestResponseErrorMessage(response);
                    throw new Exception(err);
                }
            }
        }

        public static T UploadFileImport<T>(byte[] file, string fileName, string url, string keyName = "Data", bool fAuth = true)
        {
            var options = new RestClientOptions(ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api")
            {
                ThrowOnAnyError = false,
                MaxTimeout = 300000  // 5 Minute.
            };

            using (RestClient restClient = new RestClient(options))
            {
                var request = new RestRequest(url, Method.Post);

                if (!string.IsNullOrEmpty(ApplicationSettings.Instance.UriHelper.UrlToken))
                {
                    request.AddHeader("Authorization", "Bearer " + ApplicationSettings.Instance.UriHelper.UrlToken);
                    // request.AddHeader("Company", CompanyId.ToString()); // Jika perlu header tambahan
                }

                request.AddHeader("Content-Type", "multipart/form-data");
                request.AddFile(keyName, file, fileName);

                var response = restClient.Execute(request);

                if (response.IsSuccessful)
                {
                    var result = JsonConvert.DeserializeObject<T>(response.Content, jsonSerializerSettings);
                    return result;
                }
                else
                {
                    var err = GetRestResponseErrorMessage(response);
                    throw new Exception(err);
                }
            }
        }

        public static List<T> GetListOdata<T>(string fEndPoint, string fSelect = "", string fExpand = "", string fFilter = "", string fOrder = "", string msgLoading = "Memuat ...", object fJson = null, Method fMethod = Method.Get)
        {
            var result = new List<T>();
            int top = 20; // Jumlah item yang akan diambil dalam satu halaman, sesuaikan sesuai kebutuhan Anda
            int skip = 0;
            long totalCount = 0;

            // Bisa check peforma
            var urlCheck = BuildQuery(fEndPoint, fSelect: "Id", fFilter: fFilter);
            var checkCount = ExecuteGet(urlCheck, fJsonBody: fJson, fMethod: fMethod);
            if (checkCount.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<List<T>>(checkCount.Content, jsonSerializerSettings);
                totalCount = res.Count;
            }
            int totalPageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalCount) / top));
            do
            {
                string fResource = BuildQuery(fEndPoint, fSelect: fSelect, fExpand: fExpand, fFilter: fFilter, fOrder: fOrder);
                fResource += $"&$top={top}&$skip={skip}"; // Tambahkan $top dan $skip ke URL

                var response = ExecuteGet(fResource, fJsonBody: fJson, fMethod: fMethod);

                if (response.IsSuccessStatusCode)
                {
                    var res = JsonConvert.DeserializeObject<List<T>>(response.Content, jsonSerializerSettings);
                    result.AddRange(res);

                    skip += top; // Tingkatkan nilai $skip untuk halaman berikutnya

                    int pageCount = skip / top;

                    MessageHelper.UpdateProgressWaitFormShow("", $"{msgLoading} {pageCount}/{totalPageCount}");
                }
                else
                {
                    var err = GetRestResponseErrorMessage(response);
                    throw new Exception(err);
                }
            }
            while (skip < totalCount);

            return result;
        }

        public static T GetOdata<T>(string fEndPoint, string fSelect = "", string fExpand = "", string fFilter = "", object fJson = null, Method fMethod = Method.Get)
        {
            var result = new List<T>();

            var query = BuildQuery(fEndPoint, fSelect, fExpand, fFilter: fFilter);

            var response = ExecuteGet(query, fJsonBody: fJson, fMethod: fMethod);
            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<List<T>>(response.Content, jsonSerializerSettings);
                result.AddRange(res);
            }

            return result.FirstOrDefault();
        }

        //public static List<T> GetListOdata<T>(string fEndPoint, string fSelect = "", string fExpand = "", string fFilter = "", string msgLoading = "Memuat ...", object fJson = null, Method fMethod = Method.Get)
        //{
        //    var result = new List<T>();

        //    string fResource = BuildQuery(fEndPoint, fSelect: fSelect, fExpand: fExpand, fFilter: fFilter);
        //    fResource += "&$count=true";

        //    var response = ExecuteGet(fResource, fJsonBody: fJson, fMethod: fMethod);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var res = JsonConvert.DeserializeObject<ResponseODataRestSharpList<T>>(response.Content);
        //        string nextLink = res.nextLink;
        //        result.AddRange(res.value);

        //        int pageCount = 0;
        //        long totalCount = res.count;
        //        long totalpage = 0;

        //        if (result.Count > 0)
        //            totalpage = (totalCount / result.Count);

        //        do
        //        {
        //            if (totalpage != 0)
        //            {
        //                MessageHelper.UpdateProgressWaitFormShow("", $"{msgLoading} {pageCount++}/{totalpage}");
        //            }

        //            if (nextLink != null)
        //            {
        //                response = ExecuteGet(nextLink);
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    res = JsonConvert.DeserializeObject<ResponseODataRestSharpList<T>>(response.Content);
        //                    nextLink = res.nextLink;

        //                    result.AddRange(res.value);
        //                }
        //                else
        //                {
        //                    var err = GetRestResponseErrorMessage(response);
        //                    throw new Exception(err);
        //                }
        //            }
        //        }
        //        while (nextLink != null);
        //    }
        //    else
        //    {
        //        var err = GetRestResponseErrorMessage(response);
        //        throw new Exception(err);
        //    }

        //    if (result == null)
        //        return null;
        //    else
        //        return result;
        //}

        public static T Get<T>(string endPoint = "")
        {
            if (!string.IsNullOrEmpty(endPoint))
                endPoint = endPoint.TrimStart('/');

            try
            {
                var response = ExecuteGet(endPoint);

                if (response.IsSuccessful)
                {
                    var responseBody = response.Content;
                    var responseObject = JsonConvert.DeserializeObject<ResponseHttpClientList<T>>(responseBody, jsonSerializerSettings);
                    var result = responseObject.data.FirstOrDefault();
                    return result;
                }
                else
                {
                    Console.WriteLine($"An error occurred: {response.ErrorMessage}");
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return default(T);
            }
        }

        public static async Task<T> GetByIdAsync<T>(dynamic id, string endPoint = "")
        {
            var restClient = new RestClient(ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api");

            if (!string.IsNullOrEmpty(endPoint))
                endPoint = endPoint.TrimStart('/');

            try
            {
                var request = new RestRequest($"{endPoint}/{id}", Method.Get);

                if (!string.IsNullOrEmpty(ApplicationSettings.Instance.UriHelper.UrlToken))
                {
                    request.AddHeader("Authorization", "Bearer " + ApplicationSettings.Instance.UriHelper.UrlToken);
                    // request.AddHeader("Company", CompanyId.ToString()); // Jika perlu header tambahan
                }

                var response = await restClient.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var responseBody = response.Content;
                    var result = JsonConvert.DeserializeObject<T>(responseBody, jsonSerializerSettings);
                    return result;
                }
                else
                {
                    Console.WriteLine($"An error occurred: {response.ErrorMessage}");
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return default(T);
            }
        }

        public static T GetById<T>(dynamic id, string endPoint = "")
        {
            var restClient = new RestClient(ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api");

            if (!string.IsNullOrEmpty(endPoint))
                endPoint = endPoint.TrimStart('/');

            try
            {
                var request = new RestRequest($"{endPoint}/{id}", Method.Get);

                if (!string.IsNullOrEmpty(ApplicationSettings.Instance.UriHelper.UrlToken))
                {
                    request.AddHeader("Authorization", "Bearer " + ApplicationSettings.Instance.UriHelper.UrlToken);
                    // request.AddHeader("Company", CompanyId.ToString()); // Jika perlu header tambahan
                }

                var response = restClient.Execute(request);

                if (response.IsSuccessful)
                {
                    var responseBody = response.Content;
                    var result = JsonConvert.DeserializeObject<T>(responseBody);
                    return result;
                }
                else
                {
                    Console.WriteLine($"An error occurred: {response.ErrorMessage}");
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return default(T);
            }
        }

        public static async Task<string> DeleteAsync(dynamic id, string endPoint = "")
        {
            var restClient = new RestClient(ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api");

            if (!string.IsNullOrEmpty(endPoint))
                endPoint = endPoint.TrimStart('/');

            try
            {
                var request = new RestRequest($"{endPoint}/{id}", Method.Delete);

                if (!string.IsNullOrEmpty(ApplicationSettings.Instance.UriHelper.UrlToken))
                {
                    request.AddHeader("Authorization", "Bearer " + ApplicationSettings.Instance.UriHelper.UrlToken);
                    // request.AddHeader("Company", CompanyId.ToString()); // Jika perlu header tambahan
                }

                var response = await restClient.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var responseBody = response.Content;
                    return responseBody;
                }
                else
                {
                    Console.WriteLine($"An error occurred: {response.ErrorMessage}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        
        public static string Delete(dynamic id, string endPoint = "")
        {
            var restClient = new RestClient(ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api");

            if (!string.IsNullOrEmpty(endPoint))
                endPoint = endPoint.TrimStart('/');

            try
            {
                var request = new RestRequest($"{endPoint}/{id}", Method.Delete);

                if (!string.IsNullOrEmpty(ApplicationSettings.Instance.UriHelper.UrlToken))
                {
                    request.AddHeader("Authorization", "Bearer " + ApplicationSettings.Instance.UriHelper.UrlToken);
                    // request.AddHeader("Company", CompanyId.ToString()); // Jika perlu header tambahan
                }

                var response = restClient.Execute(request);

                if (response.IsSuccessful)
                {
                    var responseBody = response.Content;
                    return responseBody;
                }
                else
                {
                    Console.WriteLine($"An error occurred: {response.ErrorMessage}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public static string DeleteRange(string endPoint = "", string jsonBody = "")
        {
            var restClient = new RestClient(ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api");

            if (!string.IsNullOrEmpty(endPoint))
                endPoint = endPoint.TrimStart('/');

            try
            {
                var request = new RestRequest($"{endPoint}", Method.Delete);

                if (!string.IsNullOrEmpty(ApplicationSettings.Instance.UriHelper.UrlToken))
                {
                    request.AddHeader("Authorization", "Bearer " + ApplicationSettings.Instance.UriHelper.UrlToken);
                    // request.AddHeader("Company", CompanyId.ToString()); // Jika perlu header tambahan
                }

                if (jsonBody != null)
                {
                    request.AddJsonBody(jsonBody);
                    request.AddHeader("Content-type", "application/json");
                }

                var response = restClient.Execute(request);

                if (response.IsSuccessful)
                {
                    var responseBody = response.Content;
                    return responseBody;
                }
                else
                {
                    var err = GetRestResponseErrorMessage(response);
                    throw new Exception(err);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.WaitFormClose();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, MessageHelper.MessageAppTitle, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public static string Post(string endPoint = "", string jsonBody = "", List<Parameter> fParameters = null)
        {
            var restClient = new RestClient(ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api");

            try
            {
                var request = new RestRequest(endPoint, Method.Post);

                if (!string.IsNullOrEmpty(ApplicationSettings.Instance.UriHelper.UrlToken))
                {
                    request.AddHeader("Authorization", "Bearer " + ApplicationSettings.Instance.UriHelper.UrlToken);
                    // request.AddHeader("Company", CompanyId.ToString()); // Jika perlu header tambahan
                }

                if (jsonBody != null)
                {
                    request.AddJsonBody(jsonBody);
                    request.AddHeader("Content-type", "application/json");
                }
                if (fParameters != null) request.Parameters.AddParameters(fParameters);


                var response = restClient.Execute(request);

                if (response.IsSuccessful)
                {
                    var responseBody = response.Content;
                    return responseBody;
                }
                else
                {
                    var err = GetRestResponseErrorMessage(response);
                    throw new Exception(err);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.WaitFormClose();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, MessageHelper.MessageAppTitle, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<string> PostAsync(string endPoint = "", string jsonBody = "")
        {
            var restClient = new RestClient(ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api");

            if (!string.IsNullOrEmpty(endPoint))
                endPoint = endPoint.TrimStart('/');

            try
            {
                var request = new RestRequest(endPoint, Method.Post);

                if (!string.IsNullOrEmpty(ApplicationSettings.Instance.UriHelper.UrlToken))
                {
                    request.AddHeader("Authorization", "Bearer " + ApplicationSettings.Instance.UriHelper.UrlToken);
                    // request.AddHeader("Company", CompanyId.ToString()); // Jika perlu header tambahan
                }

                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(jsonBody);

                var response = await restClient.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var responseBody = response.Content;
                    return responseBody;
                }
                else
                {
                    Console.WriteLine($"An error occurred: {response.ErrorMessage}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public static async Task<string> PutAsync(dynamic id, string endPoint = "", string jsonBody = "")
        {
            var restClient = new RestClient(ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api");

            if (!string.IsNullOrEmpty(endPoint))
                endPoint = endPoint.TrimStart('/');

            try
            {
                var request = new RestRequest($"{endPoint}/{id}", Method.Put);

                if (!string.IsNullOrEmpty(ApplicationSettings.Instance.UriHelper.UrlToken))
                {
                    request.AddHeader("Authorization", "Bearer " + ApplicationSettings.Instance.UriHelper.UrlToken);
                    // request.AddHeader("Company", CompanyId.ToString()); // Jika perlu header tambahan
                }

                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(jsonBody);

                var response = await restClient.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    var responseBody = response.Content;
                    return responseBody;
                }
                else
                {
                    Console.WriteLine($"An error occurred: {response.ErrorMessage}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public static string Put(dynamic id, string endPoint = "", string jsonBody = "")
        {
            var restClient = new RestClient(ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api");

            if (!string.IsNullOrEmpty(endPoint))
                endPoint = endPoint.TrimStart('/');

            try
            {
                var request = new RestRequest($"{endPoint}/{id}", Method.Put);

                if (!string.IsNullOrEmpty(ApplicationSettings.Instance.UriHelper.UrlToken))
                {
                    request.AddHeader("Authorization", "Bearer " + ApplicationSettings.Instance.UriHelper.UrlToken);
                    // request.AddHeader("Company", CompanyId.ToString()); // Jika perlu header tambahan
                }

                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(jsonBody);

                var response = restClient.Execute(request);

                if (response.IsSuccessful)
                {
                    var responseBody = response.Content;
                    return responseBody;
                }
                else
                {
                    var err = GetRestResponseErrorMessage(response);
                    throw new Exception(err);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.WaitFormClose();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, MessageHelper.MessageAppTitle, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public static string GetRestResponseErrorMessage(RestResponse restResponse)
        {
            string errMessage = "";
            string errInner;
            string errDefault = @", deskripsi ""error"" sebagai berikut : ";

            // Gagal untuk meng-eksekusi API
            if (restResponse.IsSuccessStatusCode == false)
            {
                if (restResponse.Request.Method == Method.Get)
                {
                    errMessage = "Gagal untuk mendapatkan data, ";
                }
                else
                {
                    errMessage = "Gagal untuk menyimpan data, ";
                }

                switch (restResponse.ResponseStatus)
                {
                    case ResponseStatus.TimedOut:
                        errMessage += "dikarenakan koneksi terputus (TimeOut), silahkan untuk mencoba kembali, atau hubungi IT Region setempat";
                        break;

                    case ResponseStatus.Aborted:
                        errMessage += "dikarenakan koneksi terputus (Response Time Too Long), silahkan untuk mencoba kembali, atau hubungi IT Region setempat";
                        break;

                    default:
                        switch (restResponse.StatusCode)
                        {
                            case HttpStatusCode.Unauthorized:
                                if (restResponse.Content != null)
                                {
                                    errMessage += "dikarenakan anda tidak memiliki Otorisasi meng-akses API, ";
                                    errInner = JsonConvert.DeserializeObject<ExceptionMiddlewareErrorUnauthorized>(restResponse.Content).value;
                                    errMessage += errDefault + errInner;
                                }
                                break;
                            //case HttpStatusCode.Unauthorized:
                            //    if (restResponse.Content != null)
                            //    {
                            //        errMessage += "dikarenakan anda tidak memiliki Otorisasi meng-akses API, ";
                            //        var msg = JsonConvert.DeserializeObject<ExceptionMiddlewareErrorUnauthorized>(restResponse.Content, jsonSerializerSettings);
                            //        errMessage += errDefault + $"{msg.name}, {msg.message}";
                            //    }
                            //    break;

                            case HttpStatusCode.BadRequest:
                                if (restResponse.StatusCode == HttpStatusCode.BadRequest && restResponse.Content != null)
                                {
                                    if (restResponse.ContentEncoding.Count > 0)
                                    {
                                        try
                                        {
                                            var bytes = restResponse.RawBytes.DecompressFromBrotli();
                                            //var bytes = DataCompression.Decompress(restResponse.RawBytes);
                                            //var bytes = Brotli.DecompressBuffer(restResponse.RawBytes, 0, restResponse.RawBytes.Length);
                                            string asciiString = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                                            restResponse.Content = asciiString;
                                        }
                                        catch (Exception ex)
                                        {
                                            restResponse.Content = "Gagal saat melakukan DecompressFromBrotli, dan error yang ada didalam content terenkripsi, coba lakukan pengecekan di " + restResponse.ErrorException.Message;
                                            restResponse.ErrorMessage = restResponse.Content;
                                            restResponse.IsSuccessStatusCode = false;
                                        }
                                    }

                                    errInner = ExceptionMiddlewareHelper.GetExceptionErrorMessage(restResponse.Content);
                                    errMessage += errDefault + errInner;
                                }
                                else
                                {
                                    if (restResponse.ErrorException != null)
                                    {
                                        if (restResponse.ErrorException.InnerException != null)
                                        {
                                            errInner = restResponse.ErrorException.InnerException.Message;
                                        }
                                        else
                                        {
                                            errInner = restResponse.ErrorException.Message;
                                        }
                                    }
                                    else
                                    {
                                        errInner = restResponse.ErrorMessage;
                                    }
                                    errMessage += errDefault + errInner;
                                }
                                break;
                            case HttpStatusCode.NotFound:
                                if (restResponse.StatusCode == HttpStatusCode.NotFound && restResponse.Content != null)
                                {
                                    if (restResponse.ContentEncoding.Count > 0)
                                    {
                                        try
                                        {
                                            var bytes = restResponse.RawBytes.DecompressFromBrotli();
                                            string asciiString = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                                            restResponse.Content = asciiString;
                                        }
                                        catch (Exception ex)
                                        {
                                            restResponse.Content = "Gagal saat melakukan DecompressFromBrotli, dan error yang ada didalam content terenkripsi, coba lakukan pengecekan di " + restResponse.ErrorException.Message;
                                            restResponse.ErrorMessage = restResponse.Content;
                                            restResponse.IsSuccessStatusCode = false;
                                        }
                                    }

                                    errInner = ExceptionMiddlewareHelper.GetExceptionErrorMessage(restResponse.Content);
                                    errMessage += errDefault + errInner;
                                }
                                else
                                {
                                    if (restResponse.ErrorException != null)
                                    {
                                        if (restResponse.ErrorException.InnerException != null)
                                        {
                                            errInner = restResponse.ErrorException.InnerException.Message;
                                        }
                                        else
                                        {
                                            errInner = restResponse.ErrorException.Message;
                                        }
                                    }
                                    else
                                    {
                                        errInner = restResponse.ErrorMessage;
                                    }
                                    errMessage += errDefault + errInner;
                                }
                                break;
                            default:
                                if (restResponse.ErrorException != null)
                                {
                                    if (restResponse.ErrorException.InnerException != null)
                                    {
                                        errInner = restResponse.ErrorException.InnerException.Message;
                                    }

                                    else
                                    {
                                        errInner = restResponse.ErrorException.Message;
                                    }
                                }
                                else
                                {
                                    errInner = restResponse.ErrorMessage;
                                }
                                if (errInner.Contains("The remote name could not be resolved"))
                                {
                                    errInner += ", silahkan untuk mengecek jaringan atau hubungi IT Region setempat";
                                }
                                errMessage += errDefault + errInner;
                                break;
                        }

                        break;
                }
            }

            return errMessage;
        }

        public static string BuildQuery(string fEndPoint, string fSelect = "", string fExpand = "", string fFilter = "", int fTop = 0, int fSkip = 0, string fOrder = "")
        {
            string fResource = $"{fEndPoint}?";

            if (!string.IsNullOrEmpty(fSelect))
                fResource += $"$select={fSelect}";
            else
                fResource += "$select=*";

            if (!string.IsNullOrEmpty(fFilter))
                fResource += $"&$filter={fFilter}";

            if (!string.IsNullOrEmpty(fExpand))
                fResource += $"&$expand={fExpand}";

            if (fTop > 0)
                fResource += $"&$top={fTop}";

            if (fSkip > 0)
                fResource += $"&$skip={fSkip}";

            if (!string.IsNullOrEmpty(fOrder))
                fResource += $"&$orderby={fOrder}";

            return fResource;
        }

        public static RestResponse ExecuteGet(string fResource, bool fAuth = true, bool fAllowEncoding = true, object fJsonBody = null, List<Parameter> fParameters = null, Method fMethod = Method.Get)
        {
            const string encoding = "br";

            using (RestClient restClient = new RestClient(ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api"))
            {
                var request = new RestRequest(fResource, Method.Get);
                if (fAllowEncoding == true) request.AddHeader("Accept-Encoding", encoding);
                if (fAuth == true) request.AddHeader("Authorization", $"Bearer {ApplicationSettings.Instance.UriHelper.UrlToken}");
                if (fJsonBody != null)
                {
                    request.AddJsonBody(fJsonBody);
                    request.AddHeader("Content-type", "application/json");
                }
                if (fParameters != null) request.Parameters.AddParameters(fParameters);

                RestResponse response = restClient.Execute(request, fMethod);

                DecompressedRestResponse(response);

                return response;
            }
        }

        public static void DecompressedRestResponse(RestResponse response)
        {
            if (response != null)
            {
                //if (response.IsSuccessStatusCode)
                //{
                    if (response.ContentEncoding.Count > 0)
                    {
                        try
                        {
                            var bytes = response.RawBytes.DecompressFromBrotli();
                            string asciiString = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                            response.Content = asciiString;
                        }
                        catch (Exception ex)
                        {
                            response.Content = "Gagal saat melakukan DecompressFromBrotli";
                            response.ErrorMessage = ex.InnerException.Message;
                            response.IsSuccessStatusCode = false;
                        }
                    }
                //}
            }
        }

        public static List<T> GetVirtualMode<T>(string fEndPoint, string fSelect = "", string fExpand = "", string fFilter = "", int fTop = 0, int fSkip = 0, string fOrder = "")
        {
            var result = new List<T>();

            string fResource = HelperRestSharp.BuildQuery(fEndPoint, fSelect, fExpand, fFilter, fTop, fSkip, fOrder);

            var response = ExecuteGet(fResource);
            if (response.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<List<T>>(response.Content, jsonSerializerSettings);

                result.AddRange(res);
            }
            else
            {
                var err = GetRestResponseErrorMessage(response);
                throw new Exception(err);
            }

            if (result == null)
                return null;
            else
                return result;
        }

        public static List<T> LoadMoreDatas<T>(VirtualServerModeConfigurationInfo configuration, string _endpoint, string _select, string _expand, string _filter, string _sort, int _top, int _skip, string _cascade = "")
        {
            var results = new List<T>();

            try
            {
                // Applying Sorting
                string sort = "";

                if (configuration.SortInfo != null && configuration.SortInfo.Length > 0)
                {
                    foreach (var item in configuration.SortInfo)
                    {
                        if (sort == "")
                            sort = item.ToString();
                        else
                            sort = sort + "," + item.ToString();
                    }
                    sort = sort.Replace("[", "");
                    sort = sort.Replace("]", "");
                    sort = sort.Replace(".", "/");
                    sort = sort.Replace("=", "eq");
                }

                // Dicoment dahulu, ketika memakai sort bawaan, ditambah ini akan error
                //// order that coming from constructor
                //if (string.IsNullOrEmpty(_sort) == false)
                //{
                //    if (sort != "")
                //        sort = _sort + ", " + sort;
                //    else
                //        sort = _sort;
                //}

                // Applying Filter
                string filter = "";

                // filter that coming from constructor
                if (string.IsNullOrEmpty(_filter) == false)
                {
                    filter = _filter;
                }
                // filter that coming from constructor
                if (string.IsNullOrEmpty(_cascade) == false)
                {
                    if (string.IsNullOrEmpty(filter) == false)
                    {
                        filter += $" and ({_cascade})";
                    }
                    else
                    {
                        filter = _cascade;
                    }
                }

                // this one is filter from SourceOnConfigurationChanged 
                if (!ReferenceEquals(configuration.Filter, null))
                {
                    string tmpfilter = "";
                    string operandtype = "";
                    string criteria = "";

                    // Logic blm sempurna 
                    // tolong di riset lebih lanjut
                    // untuk kombinasi filter lebih dari satu column
                    // untuk filter date

                    if (configuration.Filter.GetType() == typeof(GroupOperator))
                    {
                        var groupOperator = (GroupOperator)configuration.Filter;
                        tmpfilter = "";

                        foreach (var operand in groupOperator.Operands)
                        {
                            operandtype = operand.GetType().Name;

                            // dibatasin hanya mengambil 2 kata yang paling depan saja utk menghindari lewat nodelimit pada odata (100)
                            if (groupOperator.Operands.Count > 2 && operandtype == "GroupOperator")
                                if (operand.Equals(groupOperator.Operands[2]))
                                    break;

                            switch (operandtype)
                            {
                                case "FunctionOperator":
                                    criteria = GetOdataCriteria(operand as FunctionOperator);
                                    break;

                                case "BinaryOperator":
                                    criteria = GetOdataCriteria(operand as BinaryOperator);
                                    break;

                                case "GroupOperator":
                                    criteria = GetOdataCriteria(operand as GroupOperator);
                                    break;
                            }
                            if (tmpfilter == "")
                                tmpfilter = $"{criteria}";
                            else
                            {
                                if (operandtype == "GroupOperator")
                                    tmpfilter += $" or {criteria}";
                                else
                                    tmpfilter += $" {groupOperator.OperatorType} {criteria}";

                            }
                        }
                        tmpfilter = $"({tmpfilter})";
                    }
                    else
                    {
                        operandtype = configuration.Filter.GetType().Name;
                        switch (operandtype)
                        {
                            case "FunctionOperator":
                                criteria = GetOdataCriteria(configuration.Filter as FunctionOperator);
                                break;

                            case "BinaryOperator":
                                criteria = GetOdataCriteria(configuration.Filter as BinaryOperator);
                                break;

                            case "InOperator":
                                criteria = GetOdataCriteria(configuration.Filter as InOperator);
                                break;
                        }
                        if (tmpfilter == "") tmpfilter = $"{criteria}";
                        tmpfilter = $"({tmpfilter})";
                    }

                    if (string.IsNullOrEmpty(filter) == false)
                    {
                        filter = filter + " and (" + tmpfilter + ")";
                    }
                    else
                    {
                        filter = tmpfilter == "()" ? "" : tmpfilter;
                    }
                }

                results = HelperRestSharp.GetVirtualMode<T>(_endpoint, fSelect: _select, fExpand: _expand, fFilter: filter, fTop: _top, fSkip: _skip, fOrder: sort);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return results;
        }

        private static string GetOdataOperandProperty(string groupOperator, string cast, string edm)
        {
            string tmp = "";
            tmp = groupOperator.Replace("[", $"{cast}(").Replace(".", "/").Replace("]", $",{edm})");
            return tmp;
        }

        private static string GetOdataOperandProperty(OperandProperty operandProperty)
        {
            string tmpLeft = "";
            tmpLeft = operandProperty.PropertyName.ToString().Replace("[", "").Replace("]", "").Replace(".", "/");
            return tmpLeft;
        }

        private static string GetOdataOperatorType(DevExpress.Data.Filtering.BinaryOperatorType binaryOperatorType)
        {
            string operatorType = "";

            switch (binaryOperatorType)
            {
                case DevExpress.Data.Filtering.BinaryOperatorType.Equal:
                    operatorType = "eq";
                    break;
                case DevExpress.Data.Filtering.BinaryOperatorType.NotEqual:
                    operatorType = "ne";
                    break;
                case DevExpress.Data.Filtering.BinaryOperatorType.Greater:
                    operatorType = "gt";
                    break;
                case DevExpress.Data.Filtering.BinaryOperatorType.Less:
                    operatorType = "lt";
                    break;
                case DevExpress.Data.Filtering.BinaryOperatorType.LessOrEqual:
                    operatorType = "le";
                    break;
                case DevExpress.Data.Filtering.BinaryOperatorType.GreaterOrEqual:
                    operatorType = "ge";
                    break;
                case DevExpress.Data.Filtering.BinaryOperatorType.Like:
                    operatorType = "substringof";
                    break;
                case DevExpress.Data.Filtering.BinaryOperatorType.BitwiseAnd:
                    break;
                case DevExpress.Data.Filtering.BinaryOperatorType.BitwiseOr:
                    break;
                case DevExpress.Data.Filtering.BinaryOperatorType.BitwiseXor:
                    break;
                case DevExpress.Data.Filtering.BinaryOperatorType.Divide:
                    break;
                case DevExpress.Data.Filtering.BinaryOperatorType.Modulo:
                    break;
                case DevExpress.Data.Filtering.BinaryOperatorType.Multiply:
                    break;
                case DevExpress.Data.Filtering.BinaryOperatorType.Plus:
                    break;
                case DevExpress.Data.Filtering.BinaryOperatorType.Minus:
                    break;
                default:
                    break;
            }
            return operatorType;
        }
        private static string GetOdataCriteria(GroupOperator fOperator)
        {
            string tmp = "";
            string cast = "cast";
            string edm = "'Edm.String'";
            var propertyvalue = "";

            for (var i = 0; i < fOperator.Operands.Count; i++)
            {
                var propertyname = GetOdataOperandProperty(fOperator.Operands[i].ToString(), cast, edm);
                if (i == 0) tmp = propertyname;
                else tmp += $" or {propertyname}";
            }

            return tmp;
        }
        private static string GetOdataCriteria(BinaryOperator fOperator)
        {
            string tmp = "";
            var operandValue = ((OperandValue)fOperator.RightOperand);
            var operandProperty = ((OperandProperty)fOperator.LeftOperand);

            var operatorType = GetOdataOperatorType(fOperator.OperatorType);

            var tmpLeft = GetOdataOperandProperty(operandProperty);

            var tmpRight = "";
            if (operandValue.Value.GetType() == typeof(string))
            {
                tmpRight = $"'{operandValue.Value}'";
            }
            else
            {
                tmpRight = operandValue.Value.ToString();
            }
            tmp = $"{tmpLeft} {operatorType} {tmpRight}";

            return tmp;
        }

        private static string GetOdataCriteria(FunctionOperator functionOperator)
        {
            string tmp = "";
            string cast = "cast";
            string edm = "'Edm.String'";
            var propertyvalue = "";

            var operandProperty = ((OperandProperty)functionOperator.Operands[0]);
            var propertyname = GetOdataOperandProperty(operandProperty);

            var operandValue = ((OperandValue)functionOperator.Operands[1]);
            if (propertyvalue == "") propertyvalue = $"'{operandValue.Value}'"; else propertyvalue += $",'{operandValue.Value}'";
            var operatorType = functionOperator.OperatorType.ToString();

            tmp = $"{operatorType}({cast}({propertyname},{edm}),{propertyvalue})";

            return tmp;
        }

        private static string GetOdataCriteria(InOperator inOperator)
        {
            string tmp = "";

            var operandProperty = ((OperandProperty)inOperator.LeftOperand);
            var tmpLeft = GetOdataOperandProperty(operandProperty);
            var operatorType = "in";

            var tmpRight = "";
            foreach (var item in inOperator.Operands)
            {
                var operandValue = ((OperandValue)item);
                if (operandValue.Value.GetType() == typeof(string))
                {
                    if (tmpRight == "") tmpRight = $"'{operandValue.Value}'"; else tmpRight += $",'{operandValue.Value}'";
                }
                else
                {
                    if (tmpRight == "") tmpRight = $"{operandValue.Value}"; else tmpRight += $",{operandValue.Value}";
                }
            }
            tmp = $"{tmpLeft} {operatorType} ({tmpRight})";
            return tmp;
        }

    }


    public static class ExceptionMiddlewareHelper
    {

        public class RestShapeErrorDetail
        {
            public string code { get; set; }
            public string target { get; set; }
            public string message { get; set; }
        }

        public class RestShapeErrorItem
        {
            public string code { get; set; }
            public string message { get; set; }
            public List<RestShapeErrorDetail> details { get; set; }
        }

        public class RestShapeErrorRoot
        {
            public RestShapeErrorItem error { get; set; }
        }


        public class ExceptionMiddlewareError
        {
            public string error { get; set; }
            public string ErrorType { get; set; }
            public string ErrorMessage { get; set; }
        }

        public class ExceptionMiddlewareErrorUnauthorized
        {
            [JsonProperty("@odata.context")]
            public string odatacontext { get; set; }
            public string value { get; set; }
        }

        public class ExceptionMiddlewareErrorModel
        {
            public string type { get; set; }
            public string title { get; set; }
            public int status { get; set; }
            public string traceId { get; set; }
            public object errors { get; set; }
        }

        public static string GetExceptionErrorMessage(string errormessage)
        {
            string err = "";
            if (errormessage.ToString().Contains("ExceptionMiddleware"))
            {
                err = GetExceptionMiddlewareErrorMessage(errormessage);
            }
            else
            {
                err = GetExceptionRestSharpErrorMessage(errormessage);
            }

            return err;
        }

        public static string GetExceptionMiddlewareErrorMessage(string errormessage)
        {
            string err = "";

            var myDeserializedClass = JsonConvert.DeserializeObject<ExceptionMiddlewareError>(errormessage);
            if (myDeserializedClass != null)
            {
                err = myDeserializedClass.ErrorMessage;
                if (myDeserializedClass.ErrorMessage == null)
                    err = myDeserializedClass.error;
            }
            else
                err = errormessage;

            if (err == null)
            {
                var r = JsonConvert.DeserializeObject<ExceptionMiddlewareErrorUnauthorized>(errormessage);
                err = r.value;
            }
            return err;
        }

        public static string GetExceptionRestSharpErrorMessage(string errormessage)
        {
            string err = "";

            try
            {
                var myDeserializedClass = JsonConvert.DeserializeObject<ExceptionMiddlewareErrorModel>(errormessage);
                if (myDeserializedClass != null)
                {
                    if (myDeserializedClass.errors != null)
                    {
                        Dictionary<string, List<string>> errorDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(myDeserializedClass.errors.ToString());
                        string msgErr = "";
                        // Menampilkan nilai dalam dictionary
                        foreach (var keyValuePair in errorDictionary)
                        {
                            msgErr += $"{keyValuePair.Key} : ";
                            msgErr += $"  {string.Join(", ", keyValuePair.Value)}";
                            msgErr += Environment.NewLine;
                        }

                        err = msgErr;
                    }
                }
                else
                    err = errormessage;

                if (err == null)
                {
                    var r = JsonConvert.DeserializeObject<ExceptionMiddlewareErrorUnauthorized>(errormessage);
                    err = r.value;
                }
            }
            catch (Exception)
            {
                err = errormessage;
            }

            return err;
        }
    }
}
