using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ToDoApplication.Enums;

namespace ToDoApplication.Models
{
    
    public class ToDoItem
    {
        [Required]
        public long Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Priorities Priority { get; set; }
        public int IsComplete { get; set; }
    }
}