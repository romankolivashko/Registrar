using System.Collections.Generic;
using System;

namespace Registrar.Models
{
    public class Student
    {
        public Student()
        {
            this.JoinEntities = new HashSet<CourseStudent>();
            this.Completed = false;
        }

        public int StudentId { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime Enrollement {get;set;}

        public virtual ICollection<CourseStudent> JoinEntities { get; set; }
    }
}