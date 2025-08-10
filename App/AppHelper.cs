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
        public static async Task<HttpResponseMessage> SendGetRequest(string apiUrl)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);


                HttpResponseMessage response = await Variables.client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                else
                {
                    string errorData = await response.Content.ReadAsStringAsync();

                    string message = $"[{DateTime.Now}]--[Reuest Sent But Got Failed Response]--" +
                                     $"[Failed Code:{response.StatusCode}]--[Details:{errorData}]";

                    MessageBox.Show(message);
                }
            }
            catch(JsonException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
            
        }
    }

    public class Variables
    {
        public static readonly HttpClient client = new HttpClient() { Timeout = TimeSpan.FromSeconds(1000) };
    }
    
}
