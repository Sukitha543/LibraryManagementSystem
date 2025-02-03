using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Member : User //Members inherit from user
    {
        public DateTime MembershipStartDate { get; set; }
        public decimal OutstandingFines { get; set; }
        public bool IsBlacklisted { get; set; }
        public List<BorrowingRecord> BorrowingHistory { get; set; }
        public List<Reservation> Reservations { get; set; }

        public Member()
        {
            AccessLevel = AccessLevel.Basic; 
        }
    }

}

