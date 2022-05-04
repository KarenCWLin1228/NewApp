using Newtonsoft.Json;

namespace NewApp.ViewModels
{
    [JsonObject]
    public class Product
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
    }
}