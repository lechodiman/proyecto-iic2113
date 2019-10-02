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

		[DataType(DataType.Date)]
		public DateTime DateTime { get; set; }

		public string Subject { get; set; }
		public string Description { get; set; }
	}
}