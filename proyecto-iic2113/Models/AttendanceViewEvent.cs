using System;
namespace proyecto_iic2113.Models
{
    public class AttendanceViewEvent
    {
            public int EventId { get; set; }
            public int ConferenceId { get; set; }
            public string Name { get; set; }
            public DateTime EndDate { get; set; }
            public DateTime StartDate { get; set; }
            public string ApplicationUserId { get; set; }
    }
}
