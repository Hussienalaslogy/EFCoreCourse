using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace App
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cts;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            

        }

        private async void view_Btn_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            string apiUrl = $"{Variables.APIHostSite}GetCustomer";
            HttpResponseMessage? response = null;
            try
            {
                response = await Methods.SendGetRequest(apiUrl , _cts.Token);
                if(response != null)
                {
                    string content = await response.Content.ReadAsStringAsync(_cts.Token);
                    if (!string.IsNullOrEmpty(content))
                    {
                        List<Customer>? customers = JsonConvert.DeserializeObject<List<Customer>>(content);
                        DGV_View.DataSource = customers;
                    }
                }
            }
            catch(HttpRequestException ex)
            {
                MessageBox.Show($"Connection Error:{ex.Message}");
            }
            catch(JsonException ex)
            {
                MessageBox.Show($"Json Error{ex.Message}");
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
            finally
            {
                response?.Dispose();
            }
        }
        
        public class Customer
        {
            public string? CustomerNo { get; set; }
            public string? CustomerName { get; set; }
        }


    }
}
