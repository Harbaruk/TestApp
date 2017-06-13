using Newtonsoft.Json;
using System;

namespace TestApp.Models.Phones
{
    public class PhoneGetModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        [JsonProperty("last_change")]
        public DateTimeOffset LastChange { get; set; }
    }
}
