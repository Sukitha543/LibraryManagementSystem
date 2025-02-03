using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Borrow
    {
        private int id;
        private string customerName;
        private string bookTitle;
        private DateTime borrowDate;
        private DateTime? returnDate;

        // Properties with getters and setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

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

        public DateTime BorrowDate
        {
            get { return borrowDate; }
            set { borrowDate = value; }
        }

        public DateTime? ReturnDate  // Nullable property
        {
            get { return returnDate; }
            set { returnDate = value; }
        }

        // Constructor
        public Borrow(string customerName, string bookTitle, DateTime borrowDate,DateTime? returnDate = null)
        {
            this.customerName = customerName;
            this.bookTitle = bookTitle;
            this.borrowDate = borrowDate;
            this.returnDate = returnDate;
        }
    }

}

    
    

