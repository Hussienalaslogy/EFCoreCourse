using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
            InitializeDGV();

            string[] branches = { "Riyadh", "Khobar" };
            branch_Cb.Items.AddRange(branches);

        }





        private async void view_Btn_Click(object sender, EventArgs e)
        {
            ClearDGV();
            await ViewCustomer();
        }
        private async void delete_Btn_Click(object sender, EventArgs e)
        {
            await DeleteCustomer();
        }
        private async void save_Btn_Click(object sender, EventArgs e)
        {
            string? customerNo = DGV_Add.Rows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(customerNo))
            {
                string? prefix = branch_Cb.Text?.Substring(0, 1);
                if (!string.IsNullOrEmpty(prefix))
                {
                    string docNo = await GetLastNo(prefix);
                    DGV_Add.Rows[0].Cells[0].Value = docNo;
                }

                await AddNewCustomer();
            }
            else
            {
                await EditCustomer();
            }

        }
        private void new_Btn_Click(object sender, EventArgs e)
        {
            if (branch_Cb.SelectedIndex < 0)
            {
                MessageBox.Show("Branch Is required");
                return;
            }

            new_Btn.Enabled = false;
            DGV_Add.Enabled = false;


            ClearDGV();

            InitializeDGV();

            new_Btn.Enabled = true;
            DGV_Add.Enabled = true;
        }
        private async void customerId_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearDGV();
                await ViewCustomer();
            }
        }



        private async Task AddNewCustomer()
        {
            //validate user inputs
            if (DGV_Add.Rows.Count == 0 || DGV_Add.Rows[0].IsNewRow)
            {
                MessageBox.Show("No Data To Save");
                return;
            }

            //Disable the button to avoid repeated clicks
            save_Btn.Enabled = false;

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

            try
            {
                //create the json string
                string customerJsonString = JsonConvert.SerializeObject(customer);

                //send the request
                using var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
                request.Content = new StringContent(customerJsonString, Encoding.UTF8, "application/json");
                using var response = await Variables.client.SendAsync(request, _cts.Token);

                string errorMessage = await response.Content.ReadAsStringAsync();

                MessageBox.Show(
                    response.IsSuccessStatusCode ? "Customer Saved Successfully" : $"Data Not Saved \n{errorMessage}",
                    !response.IsSuccessStatusCode ? $"Error {(int)response.StatusCode.GetHashCode()} - Data Not Saved" : "",
                    MessageBoxButtons.OK,
                    !response.IsSuccessStatusCode ? MessageBoxIcon.Error : MessageBoxIcon.Information
                );
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Connection Error:{ex.Message}");
            }
            catch (OperationCanceledException)
            {

            }
            catch (JsonException ex)
            {
                MessageBox.Show($"JsonError:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
            finally
            {
                save_Btn.Enabled = true;
            }
        }

        private async Task EditCustomer()
        {
            //Validate Inputs
            if (DGV_Add.Rows.Count == 0 || DGV_Add.Rows[0].IsNewRow)
            {
                MessageBox.Show("Invalid Inputs");
                return;
            }

            //Disable the button to avoid multi clicks
            save_Btn.Enabled = false;

            //Cancel any previous requests
            _cts?.Cancel();
            _cts?.Dispose();

            //create new token
            _cts = new CancellationTokenSource();

            //prepare the data to send
            var customerData = new Customer
            {
                CustomerNo = DGV_Add.Rows[0].Cells[0].Value?.ToString(),
                CustomerName = DGV_Add.Rows[0].Cells[1].Value?.ToString(),
                CustomerEname = DGV_Add.Rows[0].Cells[2].Value?.ToString(),
                SalesMan = DGV_Add.Rows[0].Cells[3].Value?.ToString(),
                MobileNo = DGV_Add.Rows[0].Cells[4].Value?.ToString()
            };

            //create apiUrl
            string? custNo = DGV_Add.Rows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(custNo))
            {
                MessageBox.Show("Invalid Customer No");
                return;
            }
            string apiUrl = $"{Variables.APIHostSite}UpdateCustomer?customerNo={custNo}";

            try
            {
                //Create The JsonString
                string dataString = JsonConvert.SerializeObject(customerData);

                //Send The Request
                using var request = new HttpRequestMessage(HttpMethod.Put, apiUrl);
                request.Content = new StringContent(dataString, Encoding.UTF8, "application/json");
                using var response = await Variables.client.SendAsync(request, _cts.Token);

                string errMsg = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Customer Edited Successfully");
                }
                else
                {
                    MessageBox.Show($"Details : {errMsg}", $"Error Data Not Saved - {(int)response.StatusCode}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Connection Error:{ex.Message}");
            }
            catch (OperationCanceledException)
            {

            }
            catch (JsonException ex)
            {
                MessageBox.Show($"JsonError:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
            finally
            {
                save_Btn.Enabled = true;
            }
        }

        private async Task ViewCustomer()
        {
            customerId_Tb.Text = PaddingCustomerNo(customerId_Tb.Text);

            DGV_Add.DataSource = null;

            view_Btn.Enabled = false;

            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            try
            {
                string apiUrl = $"{Variables.APIHostSite}GetCustomer?param={customerId_Tb.Text}";
                using var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
                using var response = await Variables.client.SendAsync(request, _cts.Token);

                string content = await response.Content.ReadAsStringAsync(_cts.Token);

                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(content))
                    {
                        List<Customer>? customers = JsonConvert.DeserializeObject<List<Customer>>(content);
                        DGV_Add.DataSource = customers;
                    }
                }
                else
                {
                    string errMessage = $"Error : {(int)response.StatusCode}";
                    if (!string.IsNullOrEmpty(content))
                    {
                        errMessage += $" - {content}";
                    }
                    MessageBox.Show(errMessage);
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
            catch (OperationCanceledException)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
            finally
            {
                view_Btn.Enabled = true;
            }
        }

        private async Task DeleteCustomer()
        {
            string? doc_No = DGV_Add.Rows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(doc_No))
            {
                MessageBox.Show("Document No Is Required");

            }

            _cts.Cancel();
            _cts.Dispose();
            _cts = new CancellationTokenSource();
            delete_Btn.Enabled = false;

            string apiUrl = $"{Variables.APIHostSite}DeleteCustomer?customerNo={doc_No}";

            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Delete, apiUrl);
                using var response = await Variables.client.SendAsync(request, _cts.Token);

                string errorMessage = await response.Content.ReadAsStringAsync();

                MessageBox.Show(
                    response.IsSuccessStatusCode ? "Customer Deleted Successfully" : $"Error Deleting \n{errorMessage}",
                    !response.IsSuccessStatusCode ? $"Error {(int)response.StatusCode.GetHashCode()} - Error Deleting" : "",
                    MessageBoxButtons.OK,
                    !response.IsSuccessStatusCode ? MessageBoxIcon.Error : MessageBoxIcon.Information
                );
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Connection Error:{ex.Message}");
            }
            catch (OperationCanceledException)
            {

            }
            catch (JsonException ex)
            {
                MessageBox.Show($"JsonError:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }
            finally
            {
                ClearDGV();
                InitializeDGV();
                delete_Btn.Enabled = true;
            }
        }

        private async Task<string> GetLastNo(string prefix)
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = new CancellationTokenSource();

            string apiUrl = $"{Variables.APIHostSite}GetLastNo?prefix={prefix}";

            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
                using var response = await Variables.client.SendAsync(request, _cts.Token);

                if (response.IsSuccessStatusCode)
                {
                    string numericDocNoPart = await response.Content.ReadAsStringAsync(_cts.Token);
                    if (int.TryParse(numericDocNoPart, out int number))
                    {
                        string paddedNo = number.ToString("D8");
                        string docNo = prefix + paddedNo;
                        return docNo;
                    }
                }
                else
                {
                    MessageBox.Show($"Error-{response.StatusCode} While Generate New Document No");
                }

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Connection Error:{ex.Message}");
            }
            catch (OperationCanceledException)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}");
            }

            return null;
        }



        private void ClearDGV()
        {
            DGV_Add.DataSource = null;
            DGV_Add.Rows.Clear();
            DGV_Add.Columns.Clear();
        }

        private void InitializeDGV()
        {
            DGV_Add.Columns.Add("CustomerNo", "CustomerNo");
            DGV_Add.Columns.Add("CustomerName", "CustomerName");
            DGV_Add.Columns.Add("CustomerEname", "CustomerEname");
            DGV_Add.Columns.Add("SalesMan", "SalesMan");
            DGV_Add.Columns.Add("MobileNo", "MobileNo");

            DGV_Add.Rows.Add();

            DGV_Add.Rows[0].Cells[0].ReadOnly = true;

            DGV_Add.AllowUserToAddRows = false;
        }

        private string PaddingCustomerNo(string input)
        {
            string prefix = input.Substring(0, 1).ToUpper();
            string numericPart = int.Parse(input.Substring(1)).ToString("D8");
            return prefix + numericPart;
        }

        private async Task SendTemp()
        {
            var filePath = "D:\\Trash\\Test.json";
            var order = File.ReadAllText(filePath);
          
            //string orderJson = JsonConvert.SerializeObject(order);
            
            string apiUrl = $"{Variables.APIHostSite}TempPost";

            using var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
            request.Content = new StringContent(order, Encoding.UTF8, "application/json");
            using var response = await Variables.client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Success");
            }
            else
            {
                string msg = $"{response.StatusCode.ToString()} -  {response.Content.ReadAsStringAsync()}";

                MessageBox.Show(msg);
            }
        }
        private async Task GetTemp()
        {
            var now = DateTime.Now;
            var start = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
            var end = start.AddMonths(1);

            string apiUrl = $"{Variables.APIHostSite}LinqTraining?start={start}&end={end}";
            using var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            using var response = await Variables.client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                string errorData = $"{response.StatusCode} - {response.Content.ReadAsStringAsync()}";
            }
        }

        

        private async void button1_Click(object sender, EventArgs e)
        {
            await SendTemp();
            //await GetTemp();
        }
    }
}
