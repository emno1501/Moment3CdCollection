using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moment3CdCollection.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Cd> Cds { get; set; }
        public Artist()
        {

        }
    }
}
