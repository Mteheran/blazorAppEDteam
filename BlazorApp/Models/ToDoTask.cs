using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blazorApp.Models
{
    public class ToDoTask
    {
        public Guid TaskId {get;set;}
        [Required(ErrorMessage="Task is required")]
        [StringLength(20)]
        public string Description {get;set;}
        public TaskState TaskState {get;set;}
        public DateTime DateCreated {get;set;} = DateTime.Now;

    }

    public enum TaskState
    {
        Active,
        Hold,
        Removed
    }
}