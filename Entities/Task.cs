using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;

namespace ToDoList.Entities
{
    public class Task
    {

         public int Id { get; set; }
    
        public string Name { get; set; } 
        public string Status { get; set; }

        public string Priority { get; set; }

         public Task()
        {
            
        }

        public Task(int Id, string Name, string Status, string Priority)
        {
            this.Id = Id;
            this.Name = Name;
            this.Status = Status;
            this.Priority = Priority;
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }

    }
}