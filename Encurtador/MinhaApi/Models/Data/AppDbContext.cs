using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<LinksModel> Link { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlServer("");

    }


}