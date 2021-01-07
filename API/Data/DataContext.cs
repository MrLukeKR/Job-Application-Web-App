using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    /*
    Customised database access class, used with Entity Framework to create 
    and retrieve information, using Code-First, based on Applicant and Address
    domain classes.
    */
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Address> Address { get; set; }
    }
}