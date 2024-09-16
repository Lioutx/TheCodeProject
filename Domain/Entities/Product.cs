using Domain.Enums;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? MeasurementValue { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }
        public bool BuyAlways { get; set; }
        public double? CookedToUncookedRatio { get; set; }
    }
}
