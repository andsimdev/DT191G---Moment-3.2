using DT191G___Moment_3._2.Models;
using Microsoft.EntityFrameworkCore;

namespace DT191G___Moment_3._2.Data
{
    public class CdContext : DbContext
    {
        public CdContext(DbContextOptions<CdContext> options) : base(options)
        {

        }

        public DbSet<Cd> Cds { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
    }
}
