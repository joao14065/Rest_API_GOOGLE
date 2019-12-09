using api_google.Model;
using Microsoft.EntityFrameworkCore;

namespace api_google.Context
{
    public class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext()
        {

        }
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options) { }

        public DbSet<Person> Person { get; set; }

    }

}
