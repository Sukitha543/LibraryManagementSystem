﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Book
    {  
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }

        // Constructor to initialize a new book object
        public Book(int id, string title, string author, string genre, string isbn)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            ISBN = isbn;
        }

        // Default constructor (no parameters)
        public Book() { }
    }

}

