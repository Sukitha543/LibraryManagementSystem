using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Book
    {
        private int id;
        private string title;
        private string author;
        private string genre;
        private string isbn;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public string ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public Book(int id, string title, string author, string genre, string isbn)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.isbn = isbn;
        }
    }
}



