using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
    public class Talk : Event
    {
        public string Subject { get; set; }

        public IEnumerable<TalkLecturer> TalkLecturers { get; set; }
    }
}
