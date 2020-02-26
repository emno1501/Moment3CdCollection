using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moment3CdCollection.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public User()
        {

        }
    }
}
