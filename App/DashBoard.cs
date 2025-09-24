using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static App.DashBoard;

namespace App
{
    public class SalesSummary
    {
        public string SalesMan { get; set; }
        public int OrdersCount { get; set; }
        public decimal OrdersAmount { get; set; }
        public string TopOrderNo { get; set; }
        public decimal TopOrderValue { get; set; }
        public decimal NewCustomers { get; set; }

    }

    public class CustomerSummary
    {
        public string CustomerName { get; set; }
        public string SalesMan { get; set; }
        public int OrdersCount { get; set; }
        public decimal OrdersAmount { get; set; }
        public decimal TopOrderValue { get; set; }
    }

    public class CustomerTires
    {
        public string SalesMan { get; set; }

        [DisplayName("Customers")]
        public int CustomersCount { get; set; }

        [DisplayName("<1K")]
        public int Tier1 { get; set; }

        [DisplayName("1K–9K")]
        public int Tier2 { get; set; }

        [DisplayName("10K–99K")]
        public int Tier3 { get; set; }

        [DisplayName("100K+")]
        public int Tier4 { get; set; }
    }
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private async void DashBoard_Load(object sender, EventArgs e)
        {
            DTPFrom.Value = new DateTime(2025, 7, 1);
            DTPTo.Value = DateTime.Now;

            await GetSalesSummary(DTPFrom.Value , DTPTo.Value);
            await GetCustomerSummary(DTPFrom.Value, DTPTo.Value);
            await GetCustomerTires(DTPFrom.Value, DTPTo.Value);
        }
        private async void Refresh_Btn_Click(object sender, EventArgs e)
        {
            await GetSalesSummary(DTPFrom.Value, DTPTo.Value);
            await GetCustomerSummary(DTPFrom.Value, DTPTo.Value);
            await GetCustomerTires(DTPFrom.Value, DTPTo.Value);
        }



        private async Task GetSalesSummary(DateTime start , DateTime end)
        {
            string apiUrl = $"{Variables.APIHostSite}SalesSummary?start={start}&end={end}";
            using var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            using var response = await Variables.client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(result))
                {
                    var salesSummary = JsonConvert.DeserializeObject<List<SalesSummary>>(result)
                    .OrderByDescending(e => e.OrdersAmount)
                    .ToList();
                    DGV1.DataSource = salesSummary;

                    totalOrderLbl.Text = salesSummary.Sum(e => e.OrdersCount).ToString("N0");
                    totalSalesLbl.Text = salesSummary.Sum(e => e.OrdersAmount).ToString("N2");
                    
                    
                    CreateChart(salesSummary);
                }
            }
            else
            {
                string errorData = $"{response.StatusCode} - {response.Content.ReadAsStringAsync()}";
                MessageBox.Show(errorData);
            }
        }
        private async Task GetCustomerSummary(DateTime start, DateTime end)
        {
            string apiUrl = $"{Variables.APIHostSite}CustomerSummary?start={start}&end={end}";
            using var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            using var response = await Variables.client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(result))
                {
                    var CustomerSummary = JsonConvert.DeserializeObject<List<CustomerSummary>>(result)
                    .OrderByDescending(e => e.OrdersAmount)
                    .ToList();
                    DGV2.DataSource = CustomerSummary;

                }
            }
            else
            {
                string errorData = $"{response.StatusCode} - {response.Content.ReadAsStringAsync()}";
                MessageBox.Show(errorData);
            }
        }
        private async Task GetCustomerTires(DateTime start, DateTime end)
        {
            string apiUrl = $"{Variables.APIHostSite}CustomerTires?start={start}&end={end}";
            using var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            using var response = await Variables.client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(result))
                {
                    var CustomerTires = JsonConvert.DeserializeObject<List<CustomerTires>>(result)
                    .OrderByDescending(e => e.CustomersCount)
                    .ToList();
                    DGV3.DataSource = CustomerTires;

                }
            }
            else
            {
                string errorData = $"{response.StatusCode} - {response.Content.ReadAsStringAsync()}";
                MessageBox.Show(errorData);
            }
        }


        private void CreateChart(List<SalesSummary> salesSummary)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            chart1.ChartAreas.Add(new ChartArea());

            

            foreach (var item in salesSummary)
            {
                var s = new Series(item.SalesMan)
                {
                    ChartType = SeriesChartType.RangeColumn,
                    XValueType = ChartValueType.String,
                    YValueType = ChartValueType.Double
                };
                s.Points.AddXY(item.SalesMan, item.OrdersAmount);
                chart1.Series.Add(s);
            }

            // تحسين العرض
            chart1.ChartAreas[0].AxisX.Title = "SalesMan";
            chart1.ChartAreas[0].AxisY.Title = "Orders Amount";
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

       





    }
}
