using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace App
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            

        }

        private async void view_Btn_Click(object sender, EventArgs e)
        {
            string apiUrl = $"{Variables.APIHostSite}GetCustomer";
            var response = await Methods.SendGetRequest(apiUrl);
            if(response != null)
            {
                try
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        List<Customer>? customers = JsonConvert.DeserializeObject<List<Customer>>(content);
                        DGV_View.DataSource = customers;
                    }
                }
                finally
                {
                    response.Dispose();
                }
            }
        }
        
        public class Customer
        {
            public string? CustomerNo { get; set; }
            public string? CustomerName { get; set; }
        }


    }
}
