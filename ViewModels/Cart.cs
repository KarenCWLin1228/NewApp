using Newtonsoft.Json;

namespace NewApp.ViewModels
{
    [JsonObject]
    public class Cart
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Qty { get; set; } = 1;
    }
}