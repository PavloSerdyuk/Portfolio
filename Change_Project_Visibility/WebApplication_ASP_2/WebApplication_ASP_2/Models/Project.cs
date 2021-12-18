using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_ASP_2.Models
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string repository { get; set; }
        public int price { get; set; }

        public int visibility_id { get; set; }
        public int user_id { get; set; }

    }
}
