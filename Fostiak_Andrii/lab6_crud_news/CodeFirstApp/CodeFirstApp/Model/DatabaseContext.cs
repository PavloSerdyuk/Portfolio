using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApp.Model
{
    class DatabaseContext:DbContext
    {
        public DatabaseContext()
            : base("DatabaseContext")
        { }

        public DbSet<News> news { get; set; }
    }
}
