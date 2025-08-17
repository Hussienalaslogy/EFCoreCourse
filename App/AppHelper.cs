using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App.Form1;

namespace App
{
    public static class Methods
    {
        public static async Task<Api_Response> SendGetRequest(string apiUrl , CancellationToken token)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
                var response = await Variables.client.SendAsync(request,token);
                return new Api_Response
                {
                    response = response,
                    Ex = ""
                } ;
            }
            catch (HttpRequestException ex)
            {
                return new Api_Response
                {
                    response = null,
                    Ex = $"Connection Errro : {ex.Message}"
                };
            }
            catch (OperationCanceledException)
            {

            }
            catch (Exception ex)
            {
                return new Api_Response
                {
                    response = null,
                    Ex = $"Unexpected Error : {ex.Message}"
                };
            }

            return null;
        }

        public static async Task<Api_Response> SendPostRequest(string apiUrl, CancellationToken token, string customer)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
                request.Content = new StringContent(customer, Encoding.UTF8, "application/json");
                var response = await Variables.client.SendAsync(request, token);
                return new Api_Response
                {
                    response = response,
                    Ex = ""

                };
            }
            catch (HttpRequestException ex)
            {
                return new Api_Response
                {
                    response = null,
                    Ex = $"Connection Errro : {ex.Message}"
                };
            }
            catch (OperationCanceledException)
            {

            }
            catch (Exception ex)
            {
                return new Api_Response
                {
                    response = null,
                    Ex = $"Unexpected Error : {ex.Message}"
                };
            }

            return null;
        }

        public static async Task<Api_Response> SendPutRequest(string apiUrl, CancellationToken token)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Put, apiUrl);
                var response = await Variables.client.SendAsync(request, token);
                return new Api_Response
                {
                    response = response,
                    Ex = ""
                };
            }
            catch (HttpRequestException ex)
            {
                return new Api_Response
                {
                    response = null,
                    Ex = $"Connection Errro : {ex.Message}"
                };
            }
            catch (OperationCanceledException)
            {

            }
            catch (Exception ex)
            {
                return new Api_Response
                {
                    response = null,
                    Ex = $"Unexpected Error : {ex.Message}"
                };
            }

            return null;
        }

    }

    public class Variables
    {
        public static readonly HttpClient client = new HttpClient() { Timeout = TimeSpan.FromSeconds(1000) };
        public static string APIHostSite = "https://localhost:7121/";
    }

    public class Api_Response
    {
        public HttpResponseMessage? response { get; set; }
        public string? Ex { get; set; }
        public int StatusCode => response?.StatusCode.GetHashCode() ?? 0;
    }

    public class Customer
    {
        public string? CustomerNo { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEname { get; set; }
        public string? SalesMan { get; set; }
        public string? MobileNo { get; set; }

    }

   

    
    
}
