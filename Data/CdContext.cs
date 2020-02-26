using Microsoft.EntityFrameworkCore;
using Moment3CdCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moment3CdCollection.Data
{
    public class CdContext : DbContext
    {
        public CdContext(DbContextOptions<CdContext> options) : base(options)
        {

        }
        public DbSet<Cd> Cd { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Loan> Loan { get; set; }
    }
}
