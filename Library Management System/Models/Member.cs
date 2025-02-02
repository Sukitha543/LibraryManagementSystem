using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }


        public Member(int id, string name, string address, string telephone, string password)
        {
            Id = id;
            Name = name;
            Address = address;
            Telephone = telephone;
            Password = password;
        }


        public Member() { }
    }
}

