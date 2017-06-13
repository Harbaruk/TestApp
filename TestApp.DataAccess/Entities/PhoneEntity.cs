using System;

namespace TestApp.DataAccess.Entities
{
    public class PhoneEntity
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public DateTimeOffset LastChange { get; set; }
    }
}
