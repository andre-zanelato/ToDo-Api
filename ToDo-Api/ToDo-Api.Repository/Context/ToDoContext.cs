using Microsoft.EntityFrameworkCore;
using ToDo_Api.Domain.Entities;

namespace ToDo_Api.Repository.Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().ToTable("todo");
        }
    }
}
