using System;

namespace domain
{
    public class Stay
    {
        public DateTime Arrival { get; set; }
        public DateTime Derparture { get; set; }
        public int Id { get; set; }
        public int Day { get; set; }
        public  int Month { get; set; }
        public int DayOfWeek { get; set; }
        
    }
}