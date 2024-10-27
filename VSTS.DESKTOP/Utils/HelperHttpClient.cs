using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSTS.DESKTOP.Utils
{
    public class ResponseHttpClientList<T>
    {
        public int statusCode { get; set; }
        public string respCode { get; set; }
        public string respDescp { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string firstPage { get; set; }
        public string lastPage { get; set; }
        public int totalPages { get; set; }
        public int totalRecords { get; set; }
        public string nextPage { get; set; }
        public List<T> data { get; set; }
    }

    public static class HelperHttpClientExecute
    {
        public static List<T> GetList<T>(string fResource, object fJsonBody = null, string msgLoading = "Memuat ...")
        {
            var result = new List<T>();
            var httpClient = new HelperHttpClient(fResource);

            try
            {
                var jsonString = JsonConvert.SerializeObject(fJsonBody);
                return httpClient.GetList<T>(fResource, jsonString);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return result;
            }
        }

        public static async Task<List<T>> GetListAsync<T>(string fResource, object fJsonBody = null, string msgLoading = "Memuat ...")
        {
            var result = new List<T>();
            var httpClient = new HelperHttpClient(fResource);

            try
            {
                var jsonString = JsonConvert.SerializeObject(fJsonBody);
                return await httpClient.GetListAsync<T>(fResource, msgLoading);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return result;
            }
        }

        public static async Task<T> GetAsync<T>(string fResource, object fJsonBody = null, string msgLoading = "Memuat ...")
        {
            var result = default(T);
            var httpClient = new HelperHttpClient(fResource);

            try
            {
                var jsonString = JsonConvert.SerializeObject(fJsonBody);
                return await httpClient.GetAsync<T>(fResource, msgLoading);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return result;
            }
        }

        public static async Task<HttpResponseMessage> ExecutePostAsync(string fResource, object fJsonBody = null)
        {
            var httpClient = new HelperHttpClient(fResource);

            try
            {
                var jsonString = JsonConvert.SerializeObject(fJsonBody);
                HttpResponseMessage response = await httpClient.PostResponseAsync(fResource, jsonString);

                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new HttpResponseMessage();
            }
        }
    }

    public class HelperHttpClient
    {
        private string _url = ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api";
        private string _BaseUrl = ApplicationSettings.Instance.UriHelper.UrlApiDefault + "api";
        private string _token = ApplicationSettings.Instance.UriHelper.UrlToken;
        private readonly HttpClient _httpClient;
        private string EndPoint = "";


        public HelperHttpClient(string defaultEndPoint)
        {
            this.EndPoint = defaultEndPoint;
            _httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromMinutes(5)
            };

            if (!string.IsNullOrEmpty(_token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                //_httpClient.DefaultRequestHeaders.Remove("Company");//Remove Company Header biar ga double
                //_httpClient.DefaultRequestHeaders.Add("Company", CompanyId.ToString());
            }
        }

        public async Task<HttpResponseMessage> PostResponseAsync(string endPoint = "", string jsonBody = "")
        {
            try
            {
                _BaseUrl = _url;

                if (!string.IsNullOrEmpty(endPoint))
                    this.EndPoint = endPoint;

                _BaseUrl += EndPoint;
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(_BaseUrl, content);

                return response;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> GetAsync<T>(string endPoint = "", string msgLoading = "Memuat ...")
        {
            var result = default(T);
            try
            {
                _BaseUrl = _url;

                if (!string.IsNullOrEmpty(endPoint))
                    this.EndPoint = endPoint;

                _BaseUrl += EndPoint;
                HttpResponseMessage res = await _httpClient.GetAsync(_BaseUrl);

                string responseBody = await res.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ResponseHttpClientList<T>>(responseBody);

                result = response.data.FirstOrDefault();

                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return default(T);
            }
        }
        public List<T> GetList<T>(string endPoint = "", string msgLoading = "Memuat ...")
        {
            var result = new List<T>();
            try
            {
                _BaseUrl = _url;

                if (!string.IsNullOrEmpty(endPoint))
                    this.EndPoint = endPoint;

                _BaseUrl += EndPoint;
                HttpResponseMessage res = _httpClient.GetAsync(_BaseUrl).Result;

                string responseBody = res.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<ResponseHttpClientList<T>>(responseBody);

                if (response.statusCode == 200 || response.statusCode == 201 || response.statusCode == 204)
                {
                    string nextLink = response.nextPage;
                    result.AddRange(response.data);

                    int pageCount = 0;
                    long totalCount = response.totalRecords;
                    long totalpage = (totalCount / 20);

                    do
                    {
                        if (totalpage != 0)
                            MessageHelper.UpdateProgressWaitFormShow("", $"{msgLoading} {pageCount++}/{totalpage}");
                        if (nextLink != null)
                        {
                            res = _httpClient.GetAsync(nextLink).Result;

                            responseBody = res.Content.ReadAsStringAsync().Result;
                            response = JsonConvert.DeserializeObject<ResponseHttpClientList<T>>(responseBody);
                            nextLink = response.nextPage;
                            result.AddRange(response.data);
                        }
                    } while (nextLink != null);
                }

                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return default(List<T>);
            }
        }

        public async Task<List<T>> GetListAsync<T>(string endPoint = "", string msgLoading = "Memuat ...")
        {
            var result = new List<T>();
            try
            {
                _BaseUrl = _url;

                if (!string.IsNullOrEmpty(endPoint))
                    this.EndPoint = endPoint;

                _BaseUrl += EndPoint;
                HttpResponseMessage res = await _httpClient.GetAsync(_BaseUrl);

                string responseBody = await res.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ResponseHttpClientList<T>>(responseBody);

                if (response.statusCode == 200 || response.statusCode == 201 || response.statusCode == 204)
                {
                    string nextLink = response.nextPage;
                    result.AddRange(response.data);

                    int pageCount = 0;
                    long totalCount = response.totalRecords;
                    long totalpage = (totalCount / 20);

                    do
                    {
                        if (totalpage != 0)
                            MessageHelper.UpdateProgressWaitFormShow("", $"{msgLoading} {pageCount++}/{totalpage}");
                        if (nextLink != null)
                        {
                            res = await _httpClient.GetAsync(nextLink);

                            responseBody = await res.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<ResponseHttpClientList<T>>(responseBody);
                            nextLink = response.nextPage;
                            result.AddRange(response.data);
                        }
                    }

                    while (nextLink != null);
                }

                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return default(List<T>);
            }
        }

        public async Task<T> GetByIdAsync<T>(dynamic id, string endPoint = "")
        {
            try
            {
                _BaseUrl = _url;

                if (!string.IsNullOrEmpty(endPoint))
                    this.EndPoint = endPoint;

                _BaseUrl += EndPoint;
                HttpResponseMessage response = await _httpClient.GetAsync($"{_BaseUrl}/{id}");

                ShowErrorByStatusCode(endPoint, response);

                string responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(responseBody);
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return default(T);
            }
        }
        public class ErrorResponse
        {
            public string Message { get; set; }
            public int ErrorCode { get; set; }
            // Properti lain yang relevan dengan informasi error
        }


        public async Task<string> PostAsync(string endPoint = "", string jsonBody = "")
        {
            try
            {
                _BaseUrl = _url;

                if (!string.IsNullOrEmpty(endPoint))
                    this.EndPoint = endPoint;

                _BaseUrl += EndPoint;
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(_BaseUrl, content);

                ShowErrorByStatusCode(endPoint, response);

                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }


        public async Task<string> PutAsync(dynamic id, string endPoint = "", string jsonBody = "")
        {
            try
            {
                _BaseUrl = _url;

                if (!string.IsNullOrEmpty(endPoint))
                    this.EndPoint = endPoint;

                _BaseUrl += EndPoint;
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync($"{_BaseUrl}/{id}", content);

                ShowErrorByStatusCode(endPoint, response);

                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<string> DeleteAsync(dynamic id, string endPoint = "")
        {
            try
            {
                _BaseUrl = _url;

                if (!string.IsNullOrEmpty(endPoint))
                    this.EndPoint = endPoint;

                _BaseUrl += EndPoint;
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_BaseUrl}/{id}");

                ShowErrorByStatusCode(endPoint, response);

                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        private static void ShowErrorByStatusCode(string endPoint, HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                MessageHelper.ShowMessageError(null, "Unauthorized Access");
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.NotFound || response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                MessageHelper.ShowMessageError(null, $"Error when hit {endPoint.Replace("/", "")}");
        }
    }
}
