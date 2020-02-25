using Microsoft.EntityFrameworkCore;
using PyxisBackend.Entities.Models;

namespace PyxisBackend.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Pet> Pets { get; set; }

    }
}
