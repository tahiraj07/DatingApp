using datingapp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace datingapp.API.Data
{
    public class datacontext : DbContext
    {
        public datacontext(DbContextOptions<datacontext> options) : base (options) {}
        public DbSet<value> Values {get; set;}
        public DbSet<User> Users {get; set;}
    }
}