using System;
namespace proyecto_iic2113.Models
{
    public class AttendanceView
    {
            public int ConferenceId { get; set; }
            public string Name { get; set; }
            public string Venue { get; set; }
            public DateTime EndDate { get; set; }
            public DateTime DateTime { get; set; }
            public string ApplicationUserId { get; set; }
    }
}
