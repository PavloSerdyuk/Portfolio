using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApp.Model
{
    class News
    {
        [Key]
        public int Id { get; set; }
        public string ArticleTitle { get; set; }

        public string ArticleInfo { get; set; }

        public string Author_Name { get; set; }

        public string Author_Surname { get; set; }
    }
}
