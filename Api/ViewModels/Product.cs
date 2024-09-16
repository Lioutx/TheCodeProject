using Domain.Enums;
using System.ComponentModel;
using Api.Extensions;

namespace Api.ViewModels
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? MeasurementValue { get; set; }
        public string MeasurementUnitDisplay => MeasurementUnit.ToDisplayString();
        public MeasurementUnit MeasurementUnit { get; set; }
        public bool BuyAlways { get; set; }
        public double? CookedToUncookedRatio { get; set; }
    }
}
