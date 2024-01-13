using Domain.Enums;

namespace Infrastructure.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }
        public int? Quantity { get; set; }
        public bool BuyAlways { get; set; }
        public double? CookedToUncookedRatio { get; set; }
    }
}