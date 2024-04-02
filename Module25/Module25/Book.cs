using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25
{
    public class Book
    {
        public int Id {  get; set; }
        public string? Title { get; set; }
        public DateTime YearOfRelease { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }

        public User Users { get; set; }
    }
}
