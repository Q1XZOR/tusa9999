using Microsoft.EntityFrameworkCore;
using Party.WebApi.Model;


namespace Party.WebApi.Infrastruture.Data
{
    public class GuestDbContext : DbContext
    {

        public DbSet<Guest> Guests => Set<Guest>();
        public GuestDbContext(DbContextOptions options) : base(options) { }


    }
}

