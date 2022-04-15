using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_471_Library.Shared
{
    public class Loan
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Card_number { get; set; } = String.Empty;
        public string Curr_date { get; set; } = String.Empty;
        public string Due_date { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
    }
}
