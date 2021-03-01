using MyTunes.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTunes.Models
{
    public class Customer:Person
    {  
        public int CustomerId { get; set; } //pk 
        public int SupportRepId { get; set; } //fk EmployeeId
        public string Company { get; set; }
     
    }
}
