using System;
using System.Collections.Generic;
using System.Text;

namespace MyTunes.Models.User
{
    public class Employee: Person
    {  
        public int EmployeeId { get; set; }
        public int ReportsTo { get; set; } 
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }

    }
}
