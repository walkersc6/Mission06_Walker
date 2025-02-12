using Microsoft.EntityFrameworkCore;

namespace mission6.Models
{
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
