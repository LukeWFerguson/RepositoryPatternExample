using Microsoft.EntityFrameworkCore;
using Queries.Core.Domain;
using Queries.Persistence.EntityConfigurations;

namespace Queries.Persistence
{
    public class PlutoContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        public PlutoContext(DbContextOptions<PlutoContext> options)
            : base(options)
        {

        }
    }
}
