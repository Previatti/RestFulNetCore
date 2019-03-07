using Microsoft.EntityFrameworkCore;

namespace RestFulNetCore.Model.Context
{
    public class MySQLContext : DbContext
    {
        //public MySqlContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
