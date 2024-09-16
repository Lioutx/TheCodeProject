namespace Domain.Aggregates
{
    public class ScheduleDay
    {
        public Recipe Breakfast { get; set; }
        public Recipe Launch { get; set; }
        public Recipe Dinner { get; set; }
        public DayOfWeek Day { get; set; }
    }
}
