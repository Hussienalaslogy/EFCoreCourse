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
            string apiUrl = $"{Variables.APIHostSite}GetCustomer?param={customerId_Tb.Text}";
            HttpResponseMessage? response = null;
            try
            {
                var api_response = await Methods.SendGetRequest(apiUrl, _cts.Token);
                response = api_response?.response;
                if (response != null)
                {
                    string content = await response.Content.ReadAsStringAsync(_cts.Token);
                    if (!string.IsNullOrEmpty(content))
                    {
                        List<Customer>? customers = JsonConvert.DeserializeObject<List<Customer>>(content);
                        DGV_Add.DataSource = customers;
                    }
                }
                else
                {
                    MessageBox.Show(api_response?.Ex);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Connection Error:{ex.Message}");
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Json Error{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
            finally
            {
                response?.Dispose();
            }
        }

        private async void add_Btn_Click_1(object sender, EventArgs e)
        {
            //validate user inputs
            if (DGV_Add.Rows.Count == 0 || DGV_Add.Rows[0].IsNewRow)
            {
                MessageBox.Show("No Data To Save");
                return;
            }

            //Disable the button to avoid repeated clicks
            add_Btn.Enabled = false;

            //cancel previous request if exist[?]
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = new CancellationTokenSource();

            //prepare the data to send
            var customer = new Customer()
            {
                CustomerNo = DGV_Add.Rows[0].Cells[0].Value?.ToString(),
                CustomerName = DGV_Add.Rows[0].Cells[1].Value?.ToString(),
                CustomerEname = DGV_Add.Rows[0].Cells[2].Value?.ToString(),
                SalesMan = DGV_Add.Rows[0].Cells[3].Value?.ToString(),
                MobileNo = DGV_Add.Rows[0].Cells[4].Value?.ToString()
            };

            //create apiurl
            string apiUrl = $"{Variables.APIHostSite}AddCustomer";

            //create variable to store the response outside the try so you can dispose it
            HttpResponseMessage? response = null;

            try
            {
                //create the json string
                string customerJsonString = JsonConvert.SerializeObject(customer);

                //send the request
                var api_response = await Methods.SendPostRequest(apiUrl, _cts.Token, customerJsonString);
                response = api_response?.response;

                //check the response if it's not null
                if (response != null)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();

                    MessageBox.Show(
                        response.IsSuccessStatusCode ? "Customer Saved Successfully" : $"Data Not Saved \n{errorMessage}",
                        !response.IsSuccessStatusCode ? "Error Data Not Saved" : "",
                        MessageBoxButtons.OK,
                        !response.IsSuccessStatusCode ? MessageBoxIcon.Error : MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(api_response?.Ex);
                }
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"JsonError:{ex.Message}");
            }
            finally
            {
                response?.Dispose();
                add_Btn.Enabled = true;
            }
        }

        private void edit_Btn_Click(object sender, EventArgs e)
        {

        }
    }
}
