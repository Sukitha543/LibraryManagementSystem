using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Member
    {
        private int id;
        private string name;
        private string address;
        private string telephone;
        private string password;

        // Constructor with parameters
        public Member(int id, string name, string address, string telephone, string password)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.telephone = telephone;
            this.password = password;
        }


        // Getters and Setters for each property
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
