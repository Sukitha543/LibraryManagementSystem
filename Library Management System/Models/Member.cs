using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Member : User // Inheriting from user
    {
        public string MembershipId { get; set; }
        public MembershipType MembershipType { get; set; }
        public DateTime MembershipStartDate { get; set; }
        public DateTime MembershipEndDate { get; set; }
        public decimal OutstandingFines { get; set; }
        public bool IsBlacklisted { get; set; }
        public List<BorrowingRecord> BorrowingHistory { get; set; }
        public List<Reservation> Reservations { get; set; }
    }

}

