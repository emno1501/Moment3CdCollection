using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moment3CdCollection.Models
{
    public class Cd
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; } //navigeringsproperty
        public string Genre { get; set; }
        public int Year { get; set; }
        public int NumberOfSongs { get; set; }
        public TimeSpan PlayTime { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }

        public Cd()
        {

        }
    }
}
