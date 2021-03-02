using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorApp.Models
{
    public class ToDoTask
    {
        public Guid TaskId {get;set;}
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