using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnnaHladkaPortfolio.Models
{
	public class Chat
	{
		public int Id { get; set; }
		
		public string From { get; set; }
		public string To { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
