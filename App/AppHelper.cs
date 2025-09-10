using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App.Form1;

namespace App
{
    

    public class Variables
    {
        public static readonly HttpClient client = new HttpClient() { Timeout = TimeSpan.FromSeconds(1000) };
        public static string APIHostSite = "https://localhost:7121/";
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
