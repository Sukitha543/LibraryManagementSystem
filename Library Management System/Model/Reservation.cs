using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Reservation
    {
        private string customerName;
        private string bookTitle;
        private DateTime reservationDate;

        // Constructor
        public Reservation(string customerName, string bookTitle, DateTime reservationDate)
        {
            this.customerName = customerName;
            this.bookTitle = bookTitle;
            this.reservationDate = reservationDate;
        }

        // Getters and Setters
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string BookTitle
        {
            get { return bookTitle; }
            set { bookTitle = value; }
        }

        public DateTime ReservationDate
        {
            get { return reservationDate; }
            set { reservationDate = value; }
        }
    }
}
    



