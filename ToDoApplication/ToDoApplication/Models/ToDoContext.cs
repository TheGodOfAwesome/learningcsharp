using System.Data.Entity;

namespace ToDoApplication.Models
{

    public class ToDoContext : DbContext
    {
        public ToDoContext() : base()
        {

        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}