using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPiCoreCrudOperation.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public bool Permanent { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<Skill> Skills { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
