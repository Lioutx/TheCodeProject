namespace Api.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDisplayString(this Domain.Enums.MeasurementUnit measurementUnit)
        {
            switch (measurementUnit)
            {
                case Domain.Enums.MeasurementUnit.g:
                    return "grams";
                case Domain.Enums.MeasurementUnit.lt:
                    return "lt";
                case Domain.Enums.MeasurementUnit.ml:
                    return "ml";
                case Domain.Enums.MeasurementUnit.pieces:
                    return "Pieces / Slices";
                default:
                    return "not found";
            }
        }
    }
}