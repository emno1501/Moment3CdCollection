using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moment3CdCollection.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public DateTime LoanDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User User { get; set; }
        public int CdId { get; set; }
        public Cd Cd { get; set; }
        public Loan()
        {

        }
    }
}
