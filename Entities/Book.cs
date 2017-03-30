using DataBase.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Entities
{
    
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Author { get; set; }
    }
}
