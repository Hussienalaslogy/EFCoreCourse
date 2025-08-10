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
        public static async Task<HttpResponseMessage> SendGetRequest(string apiUrl , CancellationToken token)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
                var response = await Variables.client.SendAsync(request,token);
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (OperationCanceledException)
            {
                return null;
            }
            catch (Exception ex) 
            {
                throw new HttpRequestException($"Failed To Get Data From API :{ex.Message} ");
            }
        }
    }

    public class Variables
    {
        public static readonly HttpClient client = new HttpClient() { Timeout = TimeSpan.FromSeconds(1000) };
        public static string APIHostSite = "https://localhost:7121/";
    }
    
}
