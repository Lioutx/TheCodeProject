using Domain.Enums;
using System.ComponentModel;
using WebUI.Extensions;

namespace WebUI.ViewModels
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [DisplayName("Measurement Value")]
        public int? MeasurementValue { get; set; }
        [DisplayName("Measurement Unit")]
        public string MeasurementUnitDisplay => MeasurementUnit.ToDisplayString();
        public MeasurementUnit MeasurementUnit { get; set; }
        [DisplayName("Always Buy This")] 
        public bool BuyAlways { get; set; }
        [DisplayName("Cooked-to-Uncooked Ratio")] 
        public double? CookedToUncookedRatio { get; set; }
    }
}
