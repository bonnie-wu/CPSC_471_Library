using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_471_Library.Shared
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public int Copies { get; set; }
        public string Publisher { get; set; } = String.Empty;
        public string Distribution { get; set; } = String.Empty;
        public string Genre { get; set; } = String.Empty;
    }
}
