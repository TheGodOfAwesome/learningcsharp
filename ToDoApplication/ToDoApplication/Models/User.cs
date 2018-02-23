using System.Collections.Generic;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace ToDoApplication.Models
{
    public class User
    {
        public long Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}