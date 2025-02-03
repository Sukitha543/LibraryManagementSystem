using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class Librarian : User //Inheritance present as Librarain inherits from the User
    {
        public string StaffId { get; set; }
        public string Department { get; set; }
        public DateTime HireDate { get; set; }

        public Librarian()
        {
            AccessLevel = AccessLevel.Administrator; 
        }
    }
}
