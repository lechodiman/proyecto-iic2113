using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_iic2113.Models
{
	public class Event
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required(ErrorMessage = "Name cannot be blank")]
		public string Name { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime StartDate { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime EndDate { get; set; }

		public string Description { get; set; }

		public int ConferenceId { get; set; }
		public Conference Conference { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

		public IEnumerable<Review> Reviews { get; set; }
		public IEnumerable<EventUserAttendee> EventUserAttendees { get; set; }

		[Required]
		public int Capacity { get; set; }
	}
}
