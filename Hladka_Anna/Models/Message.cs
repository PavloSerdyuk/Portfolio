using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnnaHladkaPortfolio.Models
{
	public class Message
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public Chat Chat { get; set; }
		public int ChatId { get; set; }
	}
}
