using CRUD_Operations.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operations.Data
{
    public class ContactsApiDbContext : DbContext
    {
        public ContactsApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}
